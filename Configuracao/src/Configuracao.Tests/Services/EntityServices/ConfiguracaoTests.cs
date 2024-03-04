namespace GxpConfiguracao.Tests.Services.EntityServices
{
	using NUnit.Framework;

	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Parametro;
	using GxpConfiguracao.Services.EntityServices.Interfaces;
	using GxpCore.Infraestrutura.Tests;

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
			EntidadeInserir.Valor = "192.168.1.21";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.PortaServidorEmail;
			EntidadeInserir.Valor = "25";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.RemetenteEmail;
			EntidadeInserir.Valor = "servicos_operacoes@Gxp.com.br";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.SenhaRemetenteEmail;
			EntidadeInserir.Valor = "rotina@#";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.TituloRemetenteEmail;
			EntidadeInserir.Valor = "Gxp";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.UsuarioRemetenteEmail;
			EntidadeInserir.Valor = "servicos_operacoes@Gxp.com.br";
			TestarInserir();

			EntidadeInserir = new Parametro();
			EntidadeInserir.Modulo = NotificacaoParametro.Modulo;
			EntidadeInserir.Chave = NotificacaoParametro.AutenticacaoServidorEmail;
			EntidadeInserir.Valor = "True";
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
