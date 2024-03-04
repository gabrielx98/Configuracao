namespace GxpConfiguracao.Models.Mensagem.Enums
{
	using System.ComponentModel;
	using GxpCore.Infraestrutura.Persistence.Attributes;

	[LookupTable]
	public enum DestinoMensagem
	{
		Indefinido = 0,

		[Description("Portal")]
		Portal = 1,

		[Description("Integra")]
		Integra = 2,

		[Description("Portal / Integra")]
		PortalIntegra = 3,

		[Description("Outros")]
		Outros = 4,

		[Description("Não Informado")]
		NaoInformado = 99,
	}
}
