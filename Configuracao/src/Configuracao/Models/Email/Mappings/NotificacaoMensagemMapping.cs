namespace GxpConfiguracao.Models.Email.Mappings
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Infrastructure.Annotations;
	using System.Data.Entity.ModelConfiguration;

	using GxpCore.Infraestrutura.Persistence;

	public class NotificacaoMensagemMapping : BaseMapping<NotificacaoMensagem, int>
	{
		public override string TableName
		{
			get
			{
				return "NOTIFICACAO_MENSAGEM";
			}
		}

		public override void Map(EntityTypeConfiguration<NotificacaoMensagem> mapper)
		{
			mapper.HasTableAnnotation("GRANT_DEPENDENTS", "INSERT,UPDATE,DELETE,REFERENCES");

			mapper.Property(a => a.Id)
				.HasColumnName("ID_NOTIFICACAO");

			mapper.Property(a => a.Tipo)
				.HasColumnName("TIPO")
				.IsRequired();

			mapper.Property(a => a.Sucesso)
				.HasColumnName("SUCESSO")
				.IsRequired();

			mapper.Property(a => a.Destinatarios)
				.HasColumnName("DESTINATARIOS")
				.IsRequired();

			mapper.Property(a => a.DestinatariosEmCC)
				.HasColumnName("DESTINATARIOS_EM_CC");

			mapper.Property(a => a.DestinatariosEmBCC)
				.HasColumnName("DESTINATARIOS_EM_BCC");

            mapper.Property(a => a.Assunto)
				.HasColumnName("ASSUNTO")
				.HasMaxLength(255)
				.IsRequired();

			mapper.Property(a => a.Mensagem)
				.HasColumnName("MENSAGEM")
				.IsRequired();

			mapper.Property(a => a.Resultado)
				.HasColumnName("RESULTADO")
				.HasMaxLength(512);

			mapper.Property(a => a.IsHtml)
				.HasColumnName("IS_HTML")
				.IsRequired();

            mapper.Property(a => a.CodigoRoboAutomacao)
            .HasColumnName("CODIGO_ROBO_AUTOMACAO");

            mapper.Property(a => a.NomeRoboAutomacao)
           .HasColumnName("NOME_ROBO_AUTOMACAO");

            mapper.Property(a => a.IsHtml)
            .HasColumnName("IS_HTML")
            .IsRequired();

            mapper
                .HasMany(a => a.ListaAnexos)
				.WithRequired(n => n.Notificacao)
				.Map(map => map.MapKey("ID_NOTIFICACAO"))
				.WillCascadeOnDelete(false);

			mapper
				.HasMany(a => a.ListaArquivoAnexos)
				.WithRequired(n => n.Notificacao)
				.Map(map => map.MapKey("ID_NOTIFICACAO"))
				.WillCascadeOnDelete(false);
		}
	}
}