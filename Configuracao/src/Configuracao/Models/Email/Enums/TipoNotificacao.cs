namespace GxpConfiguracao.Models.Email.Enums
{
	using System.ComponentModel;

	[LookupTable]
	public enum TipoNotificacao
	{
		[Description("Indefinido")]
		Indefinido,

		[Description("Email")]
		Email,

		[Description("SMS")]
		Sms,

        [Description("EmailAutomacoes")]
        EmailAutomacoes
    }
}
