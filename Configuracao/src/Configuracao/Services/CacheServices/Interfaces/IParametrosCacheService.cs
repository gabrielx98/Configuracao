namespace GxpConfiguracao.Services.CacheServices.Interfaces
{
    using System;

    public interface IParametrosCacheService
    {
        string ObterValor(string modulo, string chave, bool forceRefresh, Func<string> loadFromDatabase);
    }
}