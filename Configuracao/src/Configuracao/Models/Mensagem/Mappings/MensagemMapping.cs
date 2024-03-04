namespace GxpConfiguracao.Models.Mensagem.Mappings
{
	using System.Data.Entity.ModelConfiguration;

	public class MensagemMapping : BaseMapping<Mensagem, int>
	{
		public override string TableName
		{
			get
			{
				return "MENSAGEM";
			}
		}

		public override void Map(EntityTypeConfiguration<Mensagem> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_MENSAGEM");

			mapper.Property(a => a.Codigo)
				.HasColumnName("CODIGO")
				.HasMaxLength(255)
				.IsRequired();

			mapper.Property(a => a.Sistema)
				.HasColumnName("ID_SISTEMA_MENSAGEM");

			mapper.Property(a => a.Destino)
				.HasColumnName("ID_DESTINO_MENSAGEM");

			mapper.Property(a => a.Verificado)
				.HasColumnName("VERIFICADO");

			mapper.Property(a => a.Modulo)
				.HasColumnName("MODULO")
				.HasMaxLength(255)
				.IsRequired();

			mapper.Property(a => a.Prefixo)
				.HasColumnName("PREFIXO")
				.HasMaxLength(255)
				.IsRequired();

			mapper.Property(a => a.Elemento)
				.HasColumnName("ELEMENTO")
				.HasMaxLength(255);

			mapper.Property(a => a.Observacao)
				.HasColumnName("OBSERVACAO")
				.HasMaxLength(500);

			mapper.HasRequired(c => c.Grupo)
				.WithMany()
				.Map(x => x.MapKey("ID_GRUPO_MENSAGEM"));
		}
	}
}