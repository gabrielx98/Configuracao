namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using Models.Mensagem;
	using Models.Mensagem.Tos;
	using GxpCore.Infraestrutura.Services;

	public interface IGrupoMensagemBizService : IGxpBizService
	{
		void RegistrarGrupoMensagem(GrupoMensagem grupoMensagem);

		void AtualizarGrupoMensagem(GrupoMensagem grupoMensagem);

		GrupoMensagem InserirOuAtualizarGrupo(GrupoMensagemTo grupoMensagemTo);
	}
}
