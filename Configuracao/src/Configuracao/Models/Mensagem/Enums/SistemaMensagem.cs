namespace GxpConfiguracao.Models.Mensagem.Enums
{
	using System.ComponentModel;

	[LookupTable]
	public enum SistemaMensagem
	{
		Indefinido = 0,

		[Description("Portal")]
		Portal = 1,

		[Description("Integra")]
		Integra = 2,

		[Description("API")]
		Api = 3,

		[Description("ESB")]
		Esb = 4,

		[Description("Groovy")]
		Groovy = 5
	}
}