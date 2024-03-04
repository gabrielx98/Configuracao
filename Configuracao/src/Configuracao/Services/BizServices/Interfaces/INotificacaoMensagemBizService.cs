namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using System.Net.Mail;
	using GxpConfiguracao.Models.Email;
	using GxpConfiguracao.Models.Email.Enums;

	using GxpCore.Infraestrutura.Services;

	public interface INotificacaoMensagemBizService : IGxpBizService
	{
		TipoNotificacao TipoSuportado { get; }

		void EnviarNotificacao(NotificacaoMensagem notificacao);
	}
}