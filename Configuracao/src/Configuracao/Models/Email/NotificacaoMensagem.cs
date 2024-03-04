namespace GxpConfiguracao.Models.Email
{
	using System.Collections.Generic;
	using GxpConfiguracao.Models.Email.Enums;

	public class NotificacaoMensagem : EntidadeBaseIdAutomatico
	{
		public TipoNotificacao Tipo { get; set; }

		public string Destinatarios { get; set; }

		public string DestinatariosEmCC { get; set; }

        public string DestinatariosEmBCC { get; set; }

        public string Assunto { get; set; }

		public string Mensagem { get; set; }

		public bool Pendente { get; set; }

		public bool Sucesso { get; set; }

		public string Resultado { get; set; }

        public int? CodigoRoboAutomacao { get; set; }

        public string NomeRoboAutomacao { get; set; }

        public bool IsHtml { get; set; }

		public List<AnexoNotificacaoMensagem> ListaAnexos { get; set; }

		public List<ArquivoAnexoNotificacaoMensagem> ListaArquivoAnexos { get; set; }

		public override string ToString()
		{
			return string.Format("Id: {0}, Assunto: {1}, Pendente {2}", Id, Assunto, Pendente);
		}
	}
}