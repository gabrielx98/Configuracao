namespace GxpConfiguracao.Models.Mensagem.Enums
{
	using System.ComponentModel;
	using GxpCore.Infraestrutura.Persistence.Attributes;

	[LookupTable]
	public enum Idioma
	{
		Indefinido = 0,

		[Description("Português")]
		Portugues = 1,

		[Description("Inglês")]
		Ingles = 2,

		[Description("Espanhol")]
		Espanhol = 3
	}
}