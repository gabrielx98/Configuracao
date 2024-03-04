namespace GxpConfiguracao.Services.EntityServices
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Interfaces;
	using Models.Email;
	using Models.Email.Enums;
	
	public class NotificacaoMensagemEntityService : NotificacaoMensagemEntityService<NotificacaoMensagem, int>, INotificacaoMensagemEntityService
	{
		public void RegistrarNotificacao(NotificacaoMensagem notificacao)
		{
			notificacao.Pendente = true;

			Inserir(notificacao);
			Persistir();
		}

		public void AtualizarNotificacao(NotificacaoMensagem notificacao)
		{
			Atualizar(notificacao);
			Persistir();
		}

		public IList<NotificacaoMensagem> ObterPendentes()
		{
			return Repository
				.ObterTodos()
				.Include(n => n.ListaAnexos)
				.Include(n => n.ListaArquivoAnexos)
				.Where(c => c.Pendente)
				.ToList();
		}

		public IList<NotificacaoMensagem> ObterNotificacaoMensagem(TipoNotificacao tipo, DateTime dataInicioInclusao, DateTime dataFimInclusao, string assunto, string mensagem, string destinatarios, bool? pendente, bool? sucesso, PesquisaTo pesquisa)
		{
			var query = Repository.ObterTodos();

			query = query.Where(x => x.Tipo == tipo);

			if (!string.IsNullOrEmpty(assunto))
			{
				assunto = assunto.ToUpper();
				query = query.Where(x => x.Assunto.ToUpper().Contains(assunto));
			}

			if (!string.IsNullOrEmpty(mensagem))
			{
				mensagem = mensagem.ToUpper();
				query = query.Where(x => x.Mensagem.ToUpper().Contains(mensagem));
			}

			if (!string.IsNullOrEmpty(destinatarios))
			{
				destinatarios = destinatarios.ToUpper();
				query = query.Where(x => x.Destinatarios.ToUpper().Contains(destinatarios));
			}

			if (pendente.HasValue)
			{
				query = query.Where(x => x.Pendente == pendente);
			}

			if (sucesso.HasValue)
			{
				query = query.Where(x => x.Sucesso == sucesso);
			}

			dataFimInclusao = dataFimInclusao.Date.AddDays(1).AddTicks(-1);
			dataInicioInclusao = dataInicioInclusao.Date;

			query = query.Where(x => dataInicioInclusao <= x.DataInclusao && x.DataInclusao <= dataFimInclusao);

			return AplicarPesquisa(pesquisa, query);
		}
	}
}