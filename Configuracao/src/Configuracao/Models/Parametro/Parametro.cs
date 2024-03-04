namespace GxpConfiguracao.Models.Parametro
{
	using System.Data.Entity.Spatial;

	public class Parametro : EntidadeBaseIdAutomatico
	{
		public string Modulo { get; set; }

		public string Chave { get; set; }

		public string Valor { get; set; }
	}
}