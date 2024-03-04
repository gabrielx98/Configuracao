namespace GxpConfiguracao.Models.Email.Mappings
{
	using System.Data.Entity.ModelConfiguration;
	using GxpCore.Infraestrutura.Persistence;

	public class ArquivoAnexoNotificacaoMensagemMapping : BaseMapping<ArquivoAnexoNotificacaoMensagem, int>
	{
		public override string TableName
		{
			get
			{
				return "ARQ_ANEXO_NOTIFICACAO";
			}
		}

		public override void Map(EntityTypeConfiguration<ArquivoAnexoNotificacaoMensagem> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_ARQ_ANEXO_NOTIFICACAO");

			mapper.Property(a => a.Caminho)
				.HasColumnName("CAMINHO")
				.HasMaxLength(512)
				.IsRequired();

			mapper.Property(a => a.ContentType)
				.HasColumnName("CONTENT_TYPE")
				.HasMaxLength(255)
				.IsRequired();

			mapper.Property(a => a.Nome)
				.HasColumnName("NOME_ARQUIVO")
				.HasMaxLength(255)
				.IsRequired();
		}
	}
}
