namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using GxpConfiguracao.Models.Email;

	using GxpCore.Infraestrutura.Services;

	public interface INotificacaoBizService : IGxpBizService
	{
		void ProcessarFila();

		void EnviarSincrono(NotificacaoMensagem notificacao);
	}
}
