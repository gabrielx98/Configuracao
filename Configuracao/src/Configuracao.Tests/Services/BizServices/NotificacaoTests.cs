namespace GxpConfiguracao.Tests.Services.BizServices
{
	using NUnit.Framework;
	

	[TestFixture]
	public class NotificacaoTests : BaseBizServiceTest<INotificacaoBizService>
	{
		[Test, Ignore("Build server")]
		public void Testar()
		{
			NotificacaoMensagem notificacao = new NotificacaoMensagem
			{
				Assunto = "teste",
				Destinatarios = "",
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
