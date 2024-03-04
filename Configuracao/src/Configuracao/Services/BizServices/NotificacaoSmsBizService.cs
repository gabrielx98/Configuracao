namespace GxpConfiguracao.Services.BizServices
{
	using System;
	using System.Net.Mail;
	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Email.Enums;
	using GxpConfiguracao.Services.BizServices.Interfaces;

	using GxpCore.Infraestrutura.Services;

	public class NotificacaoSmsBizService : GxpBizService, INotificacaoMensagemBizService
	{
		public TipoNotificacao TipoSuportado
		{
			get
			{
				return TipoNotificacao.Sms;
			}
		}

		public void EnviarNotificacao(NotificacaoMensagem notificacao)
		{
		}
	}
}
