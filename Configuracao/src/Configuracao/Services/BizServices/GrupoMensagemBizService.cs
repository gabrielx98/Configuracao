namespace GxpConfiguracao.Services.BizServices
{
	using EntityServices.Interfaces;
	using Interfaces;
	using Models.Mensagem;
	using Models.Mensagem.Tos;
	using GxpCore.Infraestrutura.Api;
	using GxpCore.Infraestrutura.Services;

	public class GrupoMensagemBizService : GxpBizService, IGrupoMensagemBizService
	{
		private readonly IGrupoMensagemEntityService _grupoMensagemEntityService;

		public GrupoMensagemBizService(IGrupoMensagemEntityService grupoMensagemEntityService)
		{
			_grupoMensagemEntityService = grupoMensagemEntityService;
		}

		public void RegistrarGrupoMensagem(GrupoMensagem grupoMensagem)
		{
			if (_grupoMensagemEntityService.VerificarDuplicidadeGrupoMensagem(grupoMensagem))
			{
				throw new GxpMensagemException("OPI-214");
			}

			_grupoMensagemEntityService.RegistrarGrupo(grupoMensagem);
		}

		public void AtualizarGrupoMensagem(GrupoMensagem grupoMensagem)
		{
			if (_grupoMensagemEntityService.VerificarDuplicidadeGrupoMensagem(grupoMensagem))
			{
				throw new GxpMensagemException("OPI-214");
			}

			_grupoMensagemEntityService.AtualizarGrupo(grupoMensagem);
		}

		public GrupoMensagem InserirOuAtualizarGrupo(GrupoMensagemTo grupoMensagemTo)
		{
			var grupo = _grupoMensagemEntityService.ObterCompletoPorId(grupoMensagemTo.Id);

			if (grupo == null)
			{
				grupo = new GrupoMensagem();
				grupo.ApresentarCac = grupoMensagemTo.ApresentarCac;
				grupo.ApresentarHelp = grupoMensagemTo.ApresentarHelp;
				grupo.Codigo = grupoMensagemTo.Codigo;
				grupo.Nivel = grupoMensagemTo.Nivel;
				grupo.Tipo = grupoMensagemTo.Tipo;
				RegistrarGrupoMensagem(grupo);
			}

			return grupo;
		}
	}
}
