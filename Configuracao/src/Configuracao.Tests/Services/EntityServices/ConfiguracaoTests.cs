namespace GxpConfiguracao.Tests.Services.EntityServices
{
	using NUnit.Framework;
		
	[TestFixture(0)]
	public class ConfiguracaoTests : BaseEntityServiceTest<IParametroEntityService, Parametro, int>
	{
		public ConfiguracaoTests(int entidadeId)
			: base(entidadeId)
		{
		}

		[Test, Ignore("Build server")]
		public void Testar()
		{
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.ServidorEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.PortaServidorEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.RemetenteEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.SenhaRemetenteEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.TituloRemetenteEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.UsuarioRemetenteEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.AutenticacaoServidorEmail;
			EntidadeInserir.Valor = "";
			TestarInserir();
		}

		[Test, Ignore("Build server")]
		public void TestarObterAsNoTracking()
		{
			var parametro = Service.ObterPorChaveAsNoTracking("WhatsApp", "SERVICO_ENVIO_MENSAGEM_WHATSAPP");
			var dados = parametro.Valor;
		}
	}
}
