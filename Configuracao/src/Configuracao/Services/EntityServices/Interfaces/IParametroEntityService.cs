namespace GxpConfiguracao.Services.EntityServices.Interfaces
{
	using System.Collections.Generic;
	using Models.Parametro;
	
	public interface IParametroEntityService : IGxpEntityService<Parametro, int>
	{
		void RegistrarValor(Parametro parametro);

		void AtualizarValor(Parametro parametro);

		Parametro ObterPorChave(string modulo, string chave);

		Parametro ObterPorChaveAsNoTracking(string modulo, string chave);

		IList<Parametro> ObterParametros(ParametroTo pesquisa);

		bool AtualizarParametro(ParametroTo parametroTo, int usuario);

		Parametro ObterParametroPorId(int idParametro);

		bool VerificarParametroExistente(ParametroTo parametroTo);
	}
}
