namespace GxpConfiguracao.Services.EntityServices.Interfaces
{
	using System.Collections.Generic;
	using Models.Mensagem;
	using Models.Mensagem.Enums;

	public interface IGrupoMensagemEntityService : IGxpEntityService<GrupoMensagem, int>
	{
		IList<GrupoMensagem> Pesquisar(TipoMensagem? tipo, NivelMensagem? nivel, bool? apresentarCac, bool? apresentarHelp, string codigo, PesquisaTo pesquisa);

		void RegistrarGrupo(GrupoMensagem mensagem);

		void AtualizarGrupo(GrupoMensagem mensagem);

		void RemoverGrupo(GrupoMensagem mensagem);

		GrupoMensagem ObterCompletoPorId(int id);

		bool VerificarDuplicidadeGrupoMensagem(GrupoMensagem grupoMensagem);
	}
}
