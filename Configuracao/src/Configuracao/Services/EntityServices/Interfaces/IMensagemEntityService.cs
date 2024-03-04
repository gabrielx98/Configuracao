namespace GxpConfiguracao.Services.EntityServices.Interfaces
{
	using System;
	using System.Collections.Generic;
	using Models.Mensagem;
	using Models.Mensagem.Enums;

	public interface IMensagemEntityService : IGxpEntityService<Mensagem, int>
	{
		[Obsolete]
		IList<Mensagem> Pesquisar(GrupoMensagem grupo, bool? verificado, SistemaMensagem? sistema, DestinoMensagem? destino, string prefixo, string codigo,
			string modulo, string descricao, PesquisaTo pesquisa, TipoMensagem? tipo, string identificador);

		void RegistrarMensagem(Mensagem mensagem);

		void AtualizarMensagem(Mensagem mensagem);

		void RemoverMensagem(Mensagem mensagem);

		IList<Mensagem> ObterTodosCompletos();

		Mensagem ObterCompletoPorId(int id);

		bool VerificarDuplicidadeMensagem(Mensagem mensagem);

		IList<Mensagem> Pesquisar(PesquisaMensagemTo pesquisaMensagemTo);

		IList<Mensagem> PesquisarLista(PesquisaMensagemTo pesquisaMensagemTo);
	}
}