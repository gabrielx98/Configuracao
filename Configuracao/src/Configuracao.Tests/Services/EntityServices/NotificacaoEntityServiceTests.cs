namespace GxpConfiguracao.Tests.Services.EntityServices
{
	using System;
	using Autofac;
	using NUnit.Framework;
	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Parametro;
	using GxpConfiguracao.Services.EntityServices.Interfaces;
	using GxpCore.Infraestrutura.Services.Tos;
	using GxpCore.Infraestrutura.Tests;

	[TestFixture(0)]
	public class NotificacaoEntityServiceTests : BaseEntityServiceTest<INotificacaoMensagemEntityService, NotificacaoMensagem, int>
	{
		private INotificacaoMensagemEntityService _notificacaoMensagemEntityService;

		public NotificacaoEntityServiceTests(int entidadeId)
			: base(entidadeId)
		{
		}

		[Test, Ignore("Build server")]
		public override void Setup()
		{
			base.Setup();
			_notificacaoMensagemEntityService = Container.Resolve<INotificacaoMensagemEntityService>();
		}

		[Test, Ignore("Build server")]
		public void Testar()
		{
			PesquisaTo pesquisa = new PesquisaTo();
			pesquisa.TamanhoPagina = 10;

			try
			{
				var todos = _notificacaoMensagemEntityService.ObterNotificacaoMensagem(Models.Email.Enums.TipoNotificacao.Email, DateTime.Now, DateTime.Now, "MARCO", null, null, false, true, pesquisa);
			}
			catch (System.Exception ex)
			{
				var erro = ex.InnerException;
			}
		}
	}
}
