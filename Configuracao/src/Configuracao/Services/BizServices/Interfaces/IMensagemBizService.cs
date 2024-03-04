namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using System.Collections.Generic;
	using Models.Mensagem;
	
	public interface IMensagemBizService : IMensagemBizService
	{
		void RegistrarMensagem(Mensagem mensagem);

		void AtualizarMensagem(Mensagem mensagem);

		IList<Mensagem> Pesquisar(PesquisaMensagemTo pesquisaMensagemTo);

		Mensagem ObterPorId(int id);

		Mensagem AtualizarMensagem(MensagemTo mensagemTo);

		Mensagem InserirMensagem(MensagemTo mensagemTo);

		Mensagem RemoverMensagem(int id);
	}
}
