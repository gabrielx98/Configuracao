namespace GxpConfiguracao.Services.EntityServices
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;
	using Interfaces;
	using Models.Mensagem;
	using Models.Mensagem.Enums;
	using Models.Mensagem.Tos;
	using GxpCore.Infraestrutura.Services;
	using GxpCore.Infraestrutura.Services.Tos;

	public class MensagemEntityService : GxpEntityService<Mensagem, int>, IMensagemEntityService
	{
		public IList<Mensagem> Pesquisar(GrupoMensagem grupo, bool? verificado, SistemaMensagem? sistema, DestinoMensagem? destino, string prefixo, string codigo, string modulo, string descricao, PesquisaTo pesquisa, TipoMensagem? tipo, string identificador = null)
		{
			try
			{
				if (pesquisa != null &&
					pesquisa.IncluirObsoletos)
				{
					Repository.HabilitarExcluidos();
				}

				var consulta = Repository
					.ObterTodos()
					.Include(c => c.Grupo)
					.Include(c => c.Mensagens);

				if (sistema.HasValue)
				{
					consulta = consulta.Where(c => c.Sistema == sistema.Value);
				}

				if (destino.HasValue)
				{
					consulta = consulta.Where(c => c.Destino == destino.Value);
				}

				if (!string.IsNullOrWhiteSpace(identificador))
				{
					identificador = identificador.ToUpper();

					char[] separator = { '-' };
					string[] identificadores = identificador.Split(separator, StringSplitOptions.RemoveEmptyEntries);

					if (identificadores.Length > 1)
					{
						string prefixoIdentificador = identificadores[0];
						string codigoIdentificador = identificadores[1];

						consulta = consulta.Where(c => c.Codigo == codigoIdentificador);
						consulta = consulta.Where(c => c.Prefixo == prefixoIdentificador);
					}
				}

				if (!string.IsNullOrWhiteSpace(descricao))
				{
					descricao = descricao.ToUpper();

					consulta = consulta.Where(c => c.Mensagens.Any(x => x.Descricao.ToUpper().Contains(descricao)));
				}

				if (!string.IsNullOrWhiteSpace(modulo))
				{
					modulo = modulo.ToUpper();

					consulta = consulta.Where(c => c.Modulo.ToUpper().Contains(modulo));
				}

				if (!string.IsNullOrWhiteSpace(prefixo))
				{
					prefixo = prefixo.ToUpper();

					consulta = consulta.Where(c => c.Prefixo.ToUpper().Contains(prefixo));
				}

				if (!string.IsNullOrWhiteSpace(codigo))
				{
					codigo = codigo.ToUpper();

					consulta = consulta.Where(c => c.Codigo.ToUpper().Contains(codigo));
				}

				if (verificado.HasValue)
				{
					consulta = consulta.Where(c => c.Verificado == verificado.Value);
				}

				if (tipo.HasValue && tipo != TipoMensagem.Indefinido)
				{
					consulta = consulta.Where(c => c.Grupo.Tipo == tipo);
				}

				return AplicarPesquisa(pesquisa, consulta);
			}
			finally
			{
				if (pesquisa != null &&
					pesquisa.IncluirObsoletos)
				{
					Repository.DesabilitarExcluidos();
				}
			}
		}

		public void RegistrarMensagem(Mensagem mensagem)
		{
			Inserir(mensagem);
			Persistir();
		}

		public bool VerificarDuplicidadeMensagem(Mensagem mensagem)
		{
			if (mensagem.Grupo.Tipo == TipoMensagem.Inline)
			{
				return Repository.ObterPorExpressao(a => a.Codigo.ToUpper() == mensagem.Codigo.ToUpper()
													 && a.Prefixo.ToUpper() == mensagem.Prefixo.ToUpper()
													 && a.Modulo.ToUpper() == mensagem.Modulo.ToUpper()
													 && a.Elemento.ToUpper() == mensagem.Elemento.ToUpper()
													 && a.Sistema == mensagem.Sistema
													 && a.Id != mensagem.Id)
								.Any();
			}

			return Repository.ObterPorExpressao(a => a.Codigo.ToUpper() == mensagem.Codigo.ToUpper()
													 && a.Prefixo.ToUpper() == mensagem.Prefixo.ToUpper()
													 && a.Modulo.ToUpper() == mensagem.Modulo.ToUpper()
													 && a.Sistema == mensagem.Sistema
													 && a.Id != mensagem.Id)
							.Any();
		}

		public IList<Mensagem> Pesquisar(PesquisaMensagemTo pesquisaMensagemTo)
		{
			try
			{
				if (pesquisaMensagemTo.IncluirObsoletos)
				{
					Repository.HabilitarExcluidos();
				}

				var consulta = Repository.ObterTodos().Include(c => c.Grupo).Include(c => c.Mensagens);
				if (pesquisaMensagemTo.Sistema.HasValue)
				{
					consulta = consulta.Where(c => c.Sistema == pesquisaMensagemTo.Sistema.Value);
				}

				if (pesquisaMensagemTo.Destino.HasValue)
				{
					consulta = consulta.Where(c => c.Destino == pesquisaMensagemTo.Destino.Value);
				}

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Identificador))
				{
					pesquisaMensagemTo.Identificador = pesquisaMensagemTo.Identificador.ToUpper();

					char[] separator = { '-' };
					string[] identificadores = pesquisaMensagemTo.Identificador.Split(separator, StringSplitOptions.RemoveEmptyEntries);

					if (identificadores.Length > 1)
					{
						string prefixoIdentificador = identificadores[0];
						string codigoIdentificador = identificadores[1];

						consulta = consulta.Where(c => c.Codigo == codigoIdentificador);
						consulta = consulta.Where(c => c.Prefixo == prefixoIdentificador);
					}
				}

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Descricao))
				{
					pesquisaMensagemTo.Descricao = pesquisaMensagemTo.Descricao.ToUpper();

					consulta = consulta.Where(c => c.Mensagens.Any(x => x.Descricao.ToUpper().Contains(pesquisaMensagemTo.Descricao)));
				}

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Modulo))
				{
					pesquisaMensagemTo.Modulo = pesquisaMensagemTo.Modulo.ToUpper();

					consulta = consulta.Where(c => c.Modulo.ToUpper().Contains(pesquisaMensagemTo.Modulo));
				}

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Prefixo))
				{
					pesquisaMensagemTo.Prefixo = pesquisaMensagemTo.Prefixo.ToUpper();

					consulta = consulta.Where(c => c.Prefixo.ToUpper().Contains(pesquisaMensagemTo.Prefixo));
				}

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Codigo))
				{
					pesquisaMensagemTo.Codigo = pesquisaMensagemTo.Codigo.ToUpper();

					consulta = consulta.Where(c => c.Codigo.ToUpper().Contains(pesquisaMensagemTo.Codigo));
				}

				if (pesquisaMensagemTo.Verificado.HasValue)
				{
					consulta = consulta.Where(c => c.Verificado == pesquisaMensagemTo.Verificado.Value);
				}

				if (pesquisaMensagemTo.Tipo.HasValue && pesquisaMensagemTo.Tipo != TipoMensagem.Indefinido)
				{
					consulta = consulta.Where(c => c.Grupo.Tipo == pesquisaMensagemTo.Tipo);
				}
				
				return AplicarPesquisa(pesquisaMensagemTo, consulta);
			}
			finally
			{
				if (pesquisaMensagemTo.IncluirObsoletos)
				{
					Repository.DesabilitarExcluidos();
				}
			}
		}

		public IList<Mensagem> PesquisarLista(PesquisaMensagemTo pesquisaMensagemTo)
		{
			if (pesquisaMensagemTo.Identificadores != null)
			{
				var consulta = Repository.ObterTodos().Include(c => c.Grupo).Include(c => c.Mensagens);

				if (!string.IsNullOrWhiteSpace(pesquisaMensagemTo.Modulo))
				{
					pesquisaMensagemTo.Modulo = pesquisaMensagemTo.Modulo.ToUpper();

					consulta = consulta.Where(c => c.Modulo.ToUpper().Contains(pesquisaMensagemTo.Modulo));
				}

				string[] identificadores = pesquisaMensagemTo.Identificadores.ToArray();

				consulta = consulta.Where(c => identificadores.Contains(c.Prefixo + "-" + c.Codigo));

				return consulta.ToList();
			}

			return null;
		}

		public void AtualizarMensagem(Mensagem mensagem)
		{
			Atualizar(mensagem);
			Persistir();
		}

		public void RemoverMensagem(Mensagem mensagem)
		{
			Remover(mensagem);
			Persistir();
		}

		public Mensagem ObterCompletoPorId(int id)
		{
			try
			{
				Repository.HabilitarExcluidos();

				return Repository
				.ObterTodos()
				.Include(c => c.Mensagens)
				.Include(c => c.Grupo)
				.SingleOrDefault(c => c.Id == id);
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}

		public IList<Mensagem> ObterTodosCompletos()
		{
			return Repository
				.ObterTodos()
				.Include(c => c.Mensagens)
				.Include(c => c.Grupo)
				.ToList();
		}
	}
}
