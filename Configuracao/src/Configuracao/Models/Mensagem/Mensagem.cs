namespace GxpConfiguracao.Models.Mensagem
{
	using System.Collections.Generic;
	using Enums;
	using GxpCore.Infraestrutura.Persistence;

	public class Mensagem : EntidadeBaseIdAutomatico
	{
		public GrupoMensagem Grupo { get; set; }

		public SistemaMensagem Sistema { get; set; }

		public DestinoMensagem Destino { get; set; }

		public bool Verificado { get; set; }

		public string Modulo { get; set; }

		public string Codigo { get; set; }

		public string Prefixo { get; set; }

		public List<MensagemIdioma> Mensagens { get; set; }

		public string Identificador
		{
			get
			{
				return string.Format("{0}-{1}", Prefixo, Codigo);
			}
		}

		public string Elemento { get; set; }

		public string Observacao { get; set; }
	}
}