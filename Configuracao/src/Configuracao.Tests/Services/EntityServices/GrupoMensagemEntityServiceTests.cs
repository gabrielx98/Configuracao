namespace GxpConfiguracao.Tests.Services.EntityServices
{
	using NUnit.Framework;

	[TestFixture(0)]
	public class GrupoMensagemEntityServiceTests : BaseEntityServiceTest<IGrupoMensagemEntityService, GrupoMensagem, int>
	{
		public GrupoMensagemEntityServiceTests(int entidadeId)
			: base(entidadeId)
		{
		}

		[Test, Ignore("Build Server")]
		public override void TestarInserir()
		{
			EntidadeInserir.ApresentarCac = true;
			EntidadeInserir.ApresentarHelp = true;
			EntidadeInserir.Nivel = NivelMensagem.Erro;
			EntidadeInserir.Tipo = TipoMensagem.Janela;

			base.TestarInserir();
		}
	}
}
