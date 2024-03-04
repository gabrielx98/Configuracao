namespace GxpConfiguracao.Models.Parametro.Mappings
{
	using System.Data.Entity.ModelConfiguration;

	using GxpConfiguracao.Models.Email;

	public class ParametroMapping : BaseMapping<Parametro, int>
	{
		public override string TableName
		{
			get
			{
				return "PARAMETRO_CONFIGURACAO";
			}
		}

		public override void Map(EntityTypeConfiguration<Parametro> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_PARAMETRO_CONFIGURACAO");

			mapper.Property(a => a.Modulo)
				.HasColumnName("MODULO")
				.HasMaxLength(100)
				.IsRequired();

			mapper.Property(a => a.Chave)
				.HasColumnName("CHAVE")
				.HasMaxLength(100)
				.IsRequired();

			mapper.Property(a => a.Valor)
				.HasColumnName("VALOR")
				.HasMaxLength(1250);
		}
	}
}