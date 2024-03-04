namespace GxpConfiguracao.Tests.Services.BizServices
{
	using NUnit.Framework;

	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Email.Enums;
	using GxpConfiguracao.Services.BizServices.Interfaces;

	using GxpCore.Infraestrutura.Tests;

	[TestFixture]
	public class NotificacaoTests : BaseBizServiceTest<INotificacaoBizService>
	{
		[Test, Ignore("Build server")]
		public void Testar()
		{
			NotificacaoMensagem notificacao = new NotificacaoMensagem
			{
				Assunto = "teste",
				Destinatarios = "ext_jefferson.soares@Gxp.com.br",
				Mensagem = "teste",
				Tipo = TipoNotificacao.Email,
			};

			Service.EnviarSincrono(notificacao);
		}

		[Test, Ignore("Build server")]
		public void TestarEnvio()
		{
			Service.ProcessarFila();
		}
	}
}
