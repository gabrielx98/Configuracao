namespace GxpConfiguracao.Services.BizServices
{
	using System;
	using System.Collections.Generic;
	using EntityServices.Interfaces;
	using Interfaces;
	using Models.Email;
	using GxpCore.Infraestrutura.Api;
	using GxpCore.Infraestrutura.Services;

	public class NotificacaoBizService : GxpBizService, INotificacaoBizService
	{
		private readonly INotificacaoMensagemEntityService _notificacaoMensagemEntityService;
		private readonly IList<INotificacaoMensagemBizService> _notificacaoMensagemBizServices;

		public NotificacaoBizService(INotificacaoMensagemEntityService notificacaoMensagemEntityService, IList<INotificacaoMensagemBizService> notificacaoMensagemBizServices)
		{
			_notificacaoMensagemEntityService = notificacaoMensagemEntityService;
			_notificacaoMensagemBizServices = notificacaoMensagemBizServices;
		}

		public void ProcessarFila()
		{
			IList<NotificacaoMensagem> pendentes = _notificacaoMensagemEntityService.ObterPendentes();

			foreach (NotificacaoMensagem mensagem in pendentes)
			{
				NotificarServicos(mensagem);
			}
		}

		public void EnviarSincrono(NotificacaoMensagem notificacao)
		{
			if (notificacao == null)
			{
				throw new GxpMensagemException("1");
			}

			NotificarServicos(notificacao);
		}

		private void NotificarServicos(NotificacaoMensagem mensagem)
		{
			foreach (INotificacaoMensagemBizService notificacaoService in _notificacaoMensagemBizServices)
			{
				if (notificacaoService.TipoSuportado == mensagem.Tipo)
				{
					try
					{
						try
						{
							notificacaoService.EnviarNotificacao(mensagem);

							mensagem.Sucesso = true;
						}
						catch (GxpMensagemException ex)
						{
							mensagem.Sucesso = false;

							string detalhes = ex.Message + " / " + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);

							if (ex.InnerException != null)
							{
								detalhes += "\n" + ex.InnerException.Message;
							}

							if (detalhes.Length > 255)
							{
								mensagem.Resultado = detalhes.Substring(0, 255);
							}
							else
							{
								mensagem.Resultado = detalhes;
							}
						}

						if (mensagem.Id > 0)
						{
							mensagem.Pendente = false;
							_notificacaoMensagemEntityService.AtualizarNotificacao(mensagem);
						}
					}
					catch (Exception ex)
					{
						Logger.Error(string.Format("Falha ao notificar mensagem ({0})", mensagem), ex);
					}
				}
			}
		}
	}
}
