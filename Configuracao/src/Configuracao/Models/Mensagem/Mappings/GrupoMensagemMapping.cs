namespace GxpConfiguracao.Models.Mensagem.Mappings
{
	using System.Data.Entity.ModelConfiguration;
	using GxpCore.Infraestrutura.Persistence;

	public class GrupoMensagemMapping : BaseMapping<GrupoMensagem, int>
	{
		public override string TableName
		{
			get
			{
				return "GRUPO_MENSAGEM";
			}
		}

		public override void Map(EntityTypeConfiguration<GrupoMensagem> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_GRUPO_MENSAGEM");

			mapper.Property(a => a.Codigo)
				.HasColumnName("CODIGO")
				.HasMaxLength(50)
				.IsRequired();

			mapper.Property(a => a.ApresentarCac)
				.HasColumnName("APRESENTAR_CAC")
				.IsRequired();

			mapper.Property(a => a.ApresentarHelp)
				.HasColumnName("APRESENTAR_HELP")
				.IsRequired();

			mapper.Property(a => a.Nivel)
				.HasColumnName("ID_NIVEL_MENSAGEM")
				.IsRequired();

			mapper.Property(a => a.Tipo)
				.HasColumnName("ID_TIPO_MENSAGEM")
				.IsRequired();
		}
	}
}