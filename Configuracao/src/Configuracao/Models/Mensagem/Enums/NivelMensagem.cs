namespace GxpConfiguracao.Models.Mensagem.Enums
{
	using System.ComponentModel;

	[LookupTable]
	public enum NivelMensagem
	{
		Indefinido = 0,

		[Description("Sucesso")]
		Sucesso = 1,

		[Description("Erro")]
		Erro = 2,

		[Description("Alerta")]
		Alerta = 3,

		[Description("Info")]
		Info = 4
	}
}