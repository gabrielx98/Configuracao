// ParametroBizServiceTests.cs

namespace GxpConfiguracao.Tests.Services.BizServices
{
	using NUnit.Framework;
		
	[TestFixture]
	public class ParametroBizServiceTests : BaseBizServiceTest<IParametroBizService>
	{
		[Test, Ignore("Build server")]
		public void ObterPorValorTest()
		{
			var valor = Service.ObterValorAsNoTracking<bool>("WhatsApp", "SERVICO_ENVIO_MENSAGEM_WHATSAPP", false);
		}
	}
}