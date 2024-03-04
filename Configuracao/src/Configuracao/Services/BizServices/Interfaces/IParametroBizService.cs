namespace GxpConfiguracao.Services.BizServices.Interfaces
{
	using System.Collections.Generic;
	using GxpConfiguracao.Models.Parametro;

	public interface IParametroBizService : IGxpBizService
	{
		string ObterValor(string modulo, string chave);

        string ObterValor(string modulo, string chave, bool carregarDoCache);

		T ObterValor<T>(string modulo, string chave, T padrao = default(T));

        T ObterValor<T>(string modulo, string chave, bool carregarDoCache, T padrao = default(T));

		T ObterValorAsNoTracking<T>(string modulo, string chave, T padrao = default(T));

        T ObterValorAsNoTracking<T>(string modulo, string chave, bool carregarDoCache, T padrao = default(T));

		Parametro ObterParametro(string modulo, string chave);

		IList<Parametro> ObterParametros(ParametroTo pesquisa);

		bool AtualizarParametro(ParametroTo parametroTo, int usuario);

		Parametro ObterParametroPorId(int parametroId);

		Parametro IncluirParametro(ParametroTo parametroTo, int usuario);

		bool VerificarParametroExistente(ParametroTo parametroTo);
	}
}
