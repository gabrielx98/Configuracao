namespace GxpConfiguracao.Models.Mensagem
{
	using Enums;
	public class GrupoMensagem : EntidadeBaseIdAutomatico
	{
		public NivelMensagem Nivel { get; set; }

		public TipoMensagem Tipo { get; set; }

		public bool ApresentarCac { get; set; }

		public bool ApresentarHelp { get; set; }

		public string Codigo { get; set; }
	}
}