namespace GxpConfiguracao.Services.BizServices
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using CacheServices.Interfaces;
    using Models.Parametro.Tos;
	using OfficeOpenXml.FormulaParsing.Excel.Functions;
    using GxpConfiguracao.Models.Parametro;
	using GxpConfiguracao.Services.BizServices.Interfaces;
	using GxpConfiguracao.Services.EntityServices.Interfaces;

	using GxpCore.Infraestrutura.Services;

	public class ParametroBizService : GxpBizService, IParametroBizService
	{
		private readonly IParametroEntityService _parametroEntityService;
        private readonly IParametrosCacheService _parametrosCacheService;

		public ParametroBizService(
            IParametroEntityService parametroEntityService, 
            IParametrosCacheService parametrosCacheService)
        {
            _parametroEntityService = parametroEntityService;
            _parametrosCacheService = parametrosCacheService;
        }

		public string ObterValor(string modulo, string chave)
        {
            return ObterValor(modulo, chave, false);
        }

        public string ObterValor(string modulo, string chave, bool carregarDoCache)
        {
            return _parametrosCacheService.ObterValor(
                modulo: modulo, 
                chave: chave, 
                forceRefresh: !carregarDoCache,
                loadFromDatabase: () => ObterValorFromDatabase(modulo, chave));
        }

        public T ObterValor<T>(string modulo, string chave, T padrao = default(T))
        {
            return ObterValor<T>(modulo, chave, false, padrao);
		}

        public T ObterValor<T>(string modulo, string chave, bool carregarDoCache, T padrao = default(T))
		{
			string valor = ObterValor(modulo, chave, carregarDoCache);

            if (string.IsNullOrWhiteSpace(valor))
            {
                return padrao;
            }

            try
            {
                return (T)Convert.ChangeType(valor, typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
}

        public T ObterValorAsNoTracking<T>(string modulo, string chave, T padrao = default(T))
        {
            return ObterValorAsNoTracking<T>(modulo, chave, false, padrao);
		}

        public T ObterValorAsNoTracking<T>(string modulo, string chave, bool carregarDoCache, T padrao = default(T))
		{
            var valor = _parametrosCacheService.ObterValor(
                modulo: modulo,
                chave: chave,
                forceRefresh: !carregarDoCache,
                loadFromDatabase: () => _parametroEntityService.ObterPorChaveAsNoTracking(modulo, chave)?.Valor);

            if (valor == null)
            {
                return padrao;
            }

            try
            {
                return (T)Convert.ChangeType(valor, typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public Parametro ObterParametro(string modulo, string chave)
		{
			return _parametroEntityService.ObterPorChave(modulo, chave);
		}

		public IList<Parametro> ObterParametros(ParametroTo pesquisa)
		{
			return _parametroEntityService.ObterParametros(pesquisa);
		}

		public bool AtualizarParametro(ParametroTo parametroTo, int usuario)
		{
			return _parametroEntityService.AtualizarParametro(parametroTo, usuario);
		}

		public Parametro ObterParametroPorId(int parametroId)
		{
			return _parametroEntityService.ObterParametroPorId(parametroId);
		}

		public Parametro IncluirParametro(ParametroTo parametroTo, int usuario)
		{
			var parametro = new Parametro
            {
				Modulo = parametroTo.Modulo,
				Valor = parametroTo.Valor,
				Chave = parametroTo.Chave,
				IdUsuarioInclusao = usuario
            };

			_parametroEntityService.Inserir(parametro);
			_parametroEntityService.Persistir();

			return parametro;
		}

		public bool VerificarParametroExistente(ParametroTo parametroTo)
		{
			return _parametroEntityService.VerificarParametroExistente(parametroTo);
		}

        private string ObterValorFromDatabase(string modulo, string chave)
        {
            Parametro parametro = _parametroEntityService.ObterPorChave(modulo, chave);

            if (parametro == null)
            {
                return string.Empty;
            }

            return parametro.Valor;
        }
}
}
