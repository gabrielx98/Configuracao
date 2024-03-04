namespace GxpConfiguracao.Services.BizServices
{
	using System.Collections.Generic;
	using System.Linq;
	using EntityServices.Interfaces;
	using Interfaces;
	using Models.Mensagem;
	
	public class MensagemBizService : GxpBizService, IMensagemBizService
	{
		private readonly IMensagemEntityService _mensagemEntityService;
		private readonly IGrupoMensagemBizService _grupoMensagemBizService;

		public MensagemBizService(IMensagemEntityService mensagemEntityService, IGrupoMensagemBizService grupoMensagemBizService)
		{
			_mensagemEntityService = mensagemEntityService;
			_grupoMensagemBizService = grupoMensagemBizService;
		}

		public void RegistrarMensagem(Mensagem mensagem)
		{
			if (_mensagemEntityService.VerificarDuplicidadeMensagem(mensagem))
			{
				throw new GxpMensagemException("OPI-213");
			}

			_mensagemEntityService.RegistrarMensagem(mensagem);
		}

		public void AtualizarMensagem(Mensagem mensagem)
		{
			if (_mensagemEntityService.VerificarDuplicidadeMensagem(mensagem))
			{
				throw new GxpMensagemException("OPI-213");
			}

			_mensagemEntityService.AtualizarMensagem(mensagem);
		}

		public IList<Mensagem> Pesquisar(PesquisaMensagemTo pesquisaMensagemTo)
		{
			return _mensagemEntityService.Pesquisar(pesquisaMensagemTo);
		}

		public Mensagem ObterPorId(int id)
		{
			return _mensagemEntityService.ObterCompletoPorId(id);
		}

		public Mensagem AtualizarMensagem(MensagemTo mensagemTo)
		{
			var mensagem = _mensagemEntityService.ObterCompletoPorId(mensagemTo.Id);
			var grupo = _grupoMensagemBizService.InserirOuAtualizarGrupo(mensagemTo.GrupoMensagem);

			mensagem.Grupo = grupo;
			ToToMensagem(mensagemTo, mensagem);

			foreach (var mensagemIdiomaTo in mensagemTo.Mensagens)
			{
				var entidade = mensagem.Mensagens.SingleOrDefault(a => a.Idioma == mensagemIdiomaTo.Idioma);
				if (entidade != null)
				{
					entidade.Descricao = mensagemIdiomaTo.Descricao;
					entidade.Ajuda = mensagemIdiomaTo.Ajuda;
					entidade.Titulo = mensagemIdiomaTo.Titulo;
					entidade.Excluido = false;
				}
				else
				{
					var mensagemIdioma = ToToMensagemIdioma(mensagemIdiomaTo, mensagem);
					mensagem.Mensagens.Add(mensagemIdioma);
				}
			}

			var msgsExcluidas = mensagem.Mensagens.Where(a => mensagemTo.Mensagens.All(b => b.Idioma != a.Idioma));
			foreach (var msgExcluida in msgsExcluidas)
			{
				msgExcluida.Excluido = true;
			}

			mensagem.Excluido = false;
			AtualizarMensagem(mensagem);
			return mensagem;
		}

		public Mensagem InserirMensagem(MensagemTo mensagemTo)
		{
			var grupo = _grupoMensagemBizService.InserirOuAtualizarGrupo(mensagemTo.GrupoMensagem);

			Mensagem mensagem = new Mensagem();
			mensagem.Grupo = grupo;

			ToToMensagem(mensagemTo, mensagem);

			mensagem.Mensagens = mensagemTo.Mensagens.Select(a => ToToMensagemIdioma(a, mensagem)).ToList();

			RegistrarMensagem(mensagem);
			return mensagem;
		}

		public Mensagem RemoverMensagem(int id)
		{
			var mensagem = _mensagemEntityService.ObterPorId(id, a => a.Mensagens, a => a.Grupo);
			if (mensagem != null)
			{
				_mensagemEntityService.RemoverMensagem(mensagem);
			}

			return mensagem;
		}

		private MensagemIdioma ToToMensagemIdioma(MensagemIdiomaTo a, Mensagem mensagem)
		{
			return new MensagemIdioma
			{
				Descricao = a.Descricao,
				Titulo = a.Titulo,
				Ajuda = a.Ajuda ?? string.Empty,
				Idioma = a.Idioma,
				Mensagem = mensagem
			};
		}

		private void ToToMensagem(MensagemTo mensagemTo, Mensagem mensagem)
		{
			mensagem.Modulo = mensagemTo.Modulo;
			mensagem.Prefixo = mensagemTo.Prefixo;
			mensagem.Codigo = mensagemTo.Codigo;
			mensagem.Elemento = mensagemTo.Elemento;
			mensagem.Sistema = mensagemTo.Sistema;
			mensagem.Destino = mensagemTo.Destino;
			mensagem.Observacao = mensagemTo.Observacao;
		}
	}
}
