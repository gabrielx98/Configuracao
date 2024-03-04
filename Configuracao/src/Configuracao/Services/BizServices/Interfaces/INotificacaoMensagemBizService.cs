namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using System.Net.Mail;
	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Email.Enums;

	public interface INotificacaoMensagemBizService : INotificacaoMensagemBizService
	{
		TipoNotificacao TipoSuportado { get; }

		void EnviarNotificacao(NotificacaoMensagem notificacao);
	}
}