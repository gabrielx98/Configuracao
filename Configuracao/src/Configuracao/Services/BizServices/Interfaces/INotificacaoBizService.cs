namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using GxpConfiguracao.Models.Email;

	public interface INotificacaoBizService : INotificacaoBizService
	{
		void ProcessarFila();

		void EnviarSincrono(NotificacaoMensagem notificacao);
	}
}
