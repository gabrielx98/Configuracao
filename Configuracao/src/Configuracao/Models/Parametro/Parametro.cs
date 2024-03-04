namespace GxpConfiguracao.Models.Parametro
{
	using System.Data.Entity.Spatial;

	using GxpCore.Infraestrutura.Persistence;

	public class Parametro : EntidadeBaseIdAutomatico
	{
		public string Modulo { get; set; }

		public string Chave { get; set; }

		public string Valor { get; set; }
	}
}