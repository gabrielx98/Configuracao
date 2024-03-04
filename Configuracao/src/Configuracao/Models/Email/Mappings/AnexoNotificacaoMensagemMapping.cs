namespace GxpConfiguracao.Models.Email.Mappings
{
	using System.Data.Entity.ModelConfiguration;

	public class AnexoNotificacaoMensagemMapping : BaseMapping<AnexoNotificacaoMensagem, int>
	{
		public override string TableName
		{
			get
			{
				return "ANEXO_NOTIFICACAO_MENSAGEM";
			}
		}

		public override void Map(EntityTypeConfiguration<AnexoNotificacaoMensagem> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_ANEXO_NOTIFICACAO_MENSAGEM");

			mapper.Property(a => a.Chave)
				.HasColumnName("CHAVE")
				.HasMaxLength(35)
				.IsRequired();

			mapper.Property(a => a.Caminho)
				.HasColumnName("CAMINHO")
				.HasMaxLength(512)
				.IsRequired();
		}
	}
}
