namespace GxpConfiguracao.Models.Mensagem.Mappings
{
	using System.Data.Entity.ModelConfiguration;
	using GxpCore.Infraestrutura.Persistence;

	public class MensagemIdiomaMapping : BaseMapping<MensagemIdioma, int>
	{
		public override string TableName
		{
			get
			{
				return "MENSAGEM_IDIOMA";
			}
		}

		public override void Map(EntityTypeConfiguration<MensagemIdioma> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_MENSAGEM_IDIOMA");

			mapper.Property(a => a.Ajuda)
				.HasColumnName("AJUDA");

			mapper.Property(a => a.Descricao)
				.HasColumnName("DESCRICAO")
				.HasMaxLength(512)
				.IsRequired();

			mapper.Property(a => a.Titulo)
				.HasColumnName("TITULO")
				.HasMaxLength(255)
				.IsOptional();

			mapper.HasRequired(c => c.Mensagem)
				.WithMany(c => c.Mensagens)
				.Map(x => x.MapKey("ID_MENSAGEM"));
		}
	}
}