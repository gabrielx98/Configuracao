namespace GxpConfiguracao.Models.Mensagem.Enums
{
	using System.ComponentModel;
	using GxpCore.Infraestrutura.Persistence.Attributes;

	[LookupTable]
	public enum TipoMensagem
	{
		Indefinido = 0,

		[Description("Janela")]
		Janela = 1,

		[Description("Notificação")]
		Notificacao = 2,

		[Description("Inline")]
		Inline = 3,

		[Description("Confirmação")]
		Confirmacao = 4,
			
		[Description("Modal")]
		Modal = 5
	}
}