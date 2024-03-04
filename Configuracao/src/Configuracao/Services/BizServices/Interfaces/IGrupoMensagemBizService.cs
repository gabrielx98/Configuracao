namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using Models.Mensagem;

	public interface IGrupoMensagemBizService : IGrupoMensagemBizService
	{
		void RegistrarGrupoMensagem(GrupoMensagem grupoMensagem);

		void AtualizarGrupoMensagem(GrupoMensagem grupoMensagem);

		GrupoMensagem InserirOuAtualizarGrupo(GrupoMensagemTo grupoMensagemTo);
	}
}
