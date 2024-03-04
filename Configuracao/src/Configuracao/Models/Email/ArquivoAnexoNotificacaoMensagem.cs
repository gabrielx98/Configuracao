namespace GxpConfiguracao.Models.Email
{

	public class ArquivoAnexoNotificacaoMensagem : EntidadeBaseIdAutomatico
	{
		public NotificacaoMensagem Notificacao { get; set; }

		public string Nome { get; set; }

		public string Caminho { get; set; }

		public string ContentType { get; set; }
	}
}
