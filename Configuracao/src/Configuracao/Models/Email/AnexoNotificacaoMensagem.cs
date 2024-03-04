namespace GxpConfiguracao.Models.Email
{
	using System.IO;

	public class AnexoNotificacaoMensagem : EntidadeBaseIdAutomatico
	{
		public NotificacaoMensagem Notificacao { get; set; }

		public string Chave { get; set; }

		public string Caminho { get; set; }
	}
}
