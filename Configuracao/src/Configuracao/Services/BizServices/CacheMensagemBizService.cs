namespace GxpConfiguracao.Services.BizServices
{
	using System.Collections.Generic;
	using System.Linq;
	using EntityServices.Interfaces;
	using Models.Mensagem;
	using Models.Mensagem.Enums;
	using GxpCore.Extensoes;
	using GxpCore.Infraestrutura.Api;
	using GxpCore.Infraestrutura.Api.Dto;
	using GxpCore.Infraestrutura.Mensagem;
	using GxpCore.Infraestrutura.Services;

	public class CacheMensagemBizService : GxpBizService, ICacheMensagemBizService
	{
		private readonly IMensagemEntityService _mensagemEntityService;
		private Dictionary<string, Dictionary<string, Mensagem>> _mensagens;

		public CacheMensagemBizService(IMensagemEntityService mensagemEntityService)
		{
			_mensagemEntityService = mensagemEntityService;

			// AtualizarCache();
		}

		public string ObterTextoMensagem(string identificador, params string[] argumentos)
		{
			AtualizarCache(null, identificador);

			if (!_mensagens.Any(c => c.Value.ContainsKey(identificador)))
			{
				return null;
			}

			var mensagemEncontrada = _mensagens.First(c => c.Value.ContainsKey(identificador)).Value[identificador];

			var mensagemIdioma = ObterMensagemIdioma(mensagemEncontrada);

			if (mensagemIdioma == null)
			{
				return null;
			}

			string descricao;

			if (argumentos.NulaOuVazia())
			{
				descricao = mensagemIdioma.Descricao;
			}
			else
			{
				descricao = string.Format(mensagemIdioma.Descricao, argumentos);
			}

			return descricao;
		}

		public MensagemSistemaDto ObterMensagem(MensagemSistemaDto mensagem)
		{
			if (mensagem == null || string.IsNullOrWhiteSpace(mensagem.Identificador))
			{
				return null;
			}

			Dictionary<string, Mensagem> modulo = null;

			AtualizarCache(mensagem.Modulo, mensagem.Identificador);

			if (string.IsNullOrWhiteSpace(mensagem.Modulo))
			{
				var mensagemEncontrada = _mensagens.FirstOrDefault(c => c.Value.ContainsKey(mensagem.Identificador));

				if (!string.IsNullOrWhiteSpace(mensagemEncontrada.Key))
				{
					modulo = mensagemEncontrada.Value;
				}
			}
			else if (_mensagens.ContainsKey(mensagem.Modulo))
			{
				modulo = _mensagens[mensagem.Modulo];
			}

			if (modulo != null)
			{
				Mensagem mensagemIndexada;

				if (modulo.TryGetValue(mensagem.Identificador, out mensagemIndexada))
				{
					var mensagemIdioma = ObterMensagemIdioma(mensagemIndexada);

					if (mensagemIdioma == null)
					{
						return null;
					}

					string descricao;

					if (mensagem.Argumentos.NulaOuVazia())
					{
						descricao = mensagemIdioma.Descricao;
					}
					else
					{
						descricao = string.Format(mensagemIdioma.Descricao, mensagem.Argumentos);
					}

					return new MensagemSistemaDto
					{
						Mensagem = descricao,
						Elemento = mensagemIndexada.Elemento,
						Ajuda = mensagemIndexada.Grupo.ApresentarHelp ? mensagemIdioma.Ajuda : null,
						Titulo = mensagemIdioma.Titulo,
						Nivel = (int)mensagemIndexada.Grupo.Nivel,
						Tipo = (int)mensagemIndexada.Grupo.Tipo,
						ApresentarCac = mensagemIndexada.Grupo.ApresentarCac,
						Identificador = mensagemIndexada.Identificador
					};
				}
			}

			return null;
		}

		public void AtualizarCache()
		{
		}

		public void AtualizarCache(string modulo, string codigo)
		{
			if (_mensagens == null)
			{
				_mensagens = new Dictionary<string, Dictionary<string, Mensagem>>();
			}
			else
			{
				_mensagens.Clear();
			}

			// IList<Mensagem> mensagens = _mensagemEntityService.ObterTodosCompletos();
			var mensagens = _mensagemEntityService.Pesquisar(null, null, null, null, null, null, modulo, null, null, null, codigo);

			foreach (var mensagem in mensagens)
			{
				Dictionary<string, Mensagem> mensagensIndexadas;

				if (!_mensagens.TryGetValue(mensagem.Modulo, out mensagensIndexadas))
				{
					mensagensIndexadas = new Dictionary<string, Mensagem>();

					_mensagens[mensagem.Modulo] = mensagensIndexadas;
				}

				if (!mensagensIndexadas.ContainsKey(mensagem.Identificador))
				{
					if (!mensagem.Verificado)
					{
						Logger.Warn("Mensagem com identificador {0} nao verificada no modulo {1}", mensagem.Identificador, mensagem.Modulo);
					}

					mensagensIndexadas[mensagem.Identificador] = mensagem;
				}
				else
				{
					Logger.Error("Mensagem com identificador {0} já indexada no modulo {1}", mensagem.Identificador, mensagem.Modulo);
				}
			}
		}

		private MensagemIdioma ObterMensagemIdioma(Mensagem mensagemIndexada)
		{
			if (mensagemIndexada == null ||
				mensagemIndexada.Mensagens == null)
			{
				return null;
			}

			var idioma = mensagemIndexada.Mensagens.FirstOrDefault(c => c.Idioma == Idioma.Portugues);

			/*
			// TODO: tratar idioma da requisição
			switch (Thread.CurrentThread.CurrentCulture.LCID)
			{
				case 1033:
					{
						idioma = mensagemIndexada.Mensagens.FirstOrDefault(c => c.Idioma == Idioma.Ingles);
						break;
					}

				case 1034:
					{
						idioma = mensagemIndexada.Mensagens.FirstOrDefault(c => c.Idioma == Idioma.Espanhol);
						break;
					}

				case 1046:
					{
						idioma = mensagemIndexada.Mensagens.FirstOrDefault(c => c.Idioma == Idioma.Portugues);
						break;
					}
			}
			*/

			if (idioma != null)
			{
				return idioma;
			}

			if (mensagemIndexada.Mensagens.Any())
			{
				return mensagemIndexada.Mensagens[0];
			}

			return null;
		}
	}
}