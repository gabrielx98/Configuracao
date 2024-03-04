namespace GxpConfiguracao.Services.EntityServices
{
	using System.Collections.Generic;
	using System.Linq;
	using Interfaces;
	using Models.Mensagem;
	using Models.Mensagem.Enums;

	public class GrupoMensagemEntityService : GxpEntityService<GrupoMensagem, int>, IGrupoMensagemEntityService
	{
		public IList<GrupoMensagem> Pesquisar(TipoMensagem? tipo, NivelMensagem? nivel, bool? apresentarCac,
			bool? apresentarHelp, string codigo, PesquisaTo pesquisa)
		{
			try
			{
				if (pesquisa != null &&
					pesquisa.IncluirObsoletos)
				{
					Repository.HabilitarExcluidos();
				}

				var consulta = Repository
					.ObterTodos();

				if (apresentarCac.HasValue)
				{
					consulta = consulta.Where(c => c.ApresentarCac == apresentarCac.Value);
				}

				if (apresentarHelp.HasValue)
				{
					consulta = consulta.Where(c => c.ApresentarHelp == apresentarHelp.Value);
				}

				if (nivel.HasValue)
				{
					consulta = consulta.Where(c => c.Nivel == nivel.Value);
				}

				if (tipo.HasValue)
				{
					consulta = consulta.Where(c => c.Tipo == tipo.Value);
				}

				if (apresentarHelp.HasValue)
				{
					consulta = consulta.Where(c => c.ApresentarHelp == apresentarHelp.Value);
				}

				if (!string.IsNullOrWhiteSpace(codigo))
				{
					codigo = codigo.ToUpper();

					consulta = consulta.Where(c => c.Codigo.ToUpper().Contains(codigo));
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

		public bool VerificarDuplicidadeGrupoMensagem(GrupoMensagem grupoMensagem)
		{
			return Repository.ObterPorExpressao(a => a.Codigo.ToUpper() == grupoMensagem.Codigo.ToUpper()
												&& a.ApresentarCac == grupoMensagem.ApresentarCac
												&& a.ApresentarHelp == grupoMensagem.ApresentarHelp
												&& a.Tipo == grupoMensagem.Tipo
												&& a.Nivel == grupoMensagem.Nivel
												&& a.Id != grupoMensagem.Id)
			.Any();
		}

		public void RegistrarGrupo(GrupoMensagem grupo)
		{
			Inserir(grupo);
			Persistir();
		}

		public void AtualizarGrupo(GrupoMensagem grupo)
		{
			Atualizar(grupo);
			Persistir();
		}

		public void RemoverGrupo(GrupoMensagem grupo)
		{
			Remover(grupo);
			Persistir();
		}

		public GrupoMensagem ObterCompletoPorId(int id)
		{
			try
			{
				Repository.HabilitarExcluidos();

				return Repository
				.ObterTodos()
				.SingleOrDefault(c => c.Id == id);
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}
	}
}
