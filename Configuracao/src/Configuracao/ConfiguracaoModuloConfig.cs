namespace GxpConfiguracao
{
	using Autofac;
	using GxpConfiguracao.Services.BizServices;
    using GxpConfiguracao.Services.CacheServices;
    using GxpConfiguracao.Services.CacheServices.Interfaces;
    using GxpCore.Infraestrutura.DependencyInjection;
    using GxpCore.Infraestrutura.Mensagem;

	public class GxpConfiguracaoModuloConfig : BaseModuloConfig
	{
		public const string MODULO_SCHEMA_DB = "CONF";
		public const string MODULO_PREFIXO_DB = "CONF";

		/// <summary>
		/// Metódo utilizado em cada projeto para registro de seus componentes
		/// </summary>
		/// <param name="builder">Builder do autofac (DI)</param>
		public override void Registrar(ContainerBuilder builder)
		{
			builder.RegisterType<CacheMensagemBizService>().As<ICacheMensagemBizService>();
            builder.RegisterType<ParametrosCacheService>().As<IParametrosCacheService>();
        }
	}
}