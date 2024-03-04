namespace GxpConfiguracao.Tests.Services.EntityServices
{
	using System.Collections.Generic;
	using Autofac;
	using NUnit.Framework;
	using GxpConfiguracao.Models.Mensagem;
	using GxpConfiguracao.Models.Mensagem.Enums;
	using GxpConfiguracao.Services.EntityServices.Interfaces;
	using GxpCore.Infraestrutura.Tests;

	[TestFixture(0)]
	public class MensagemEntityServiceTests : BaseEntityServiceTest<IMensagemEntityService, Mensagem, int>
	{
		private IGrupoMensagemEntityService _grupoMensagemEntityService;

		public MensagemEntityServiceTests(int entidadeId)
			: base(entidadeId)
		{
		}

		public override void Setup()
		{
			base.Setup();

			_grupoMensagemEntityService = Container.Resolve<IGrupoMensagemEntityService>();
		}

		[Test, Ignore("Build Server")]
		public override void TestarInserir()
		{
			EntidadeInserir.Codigo = "001";
			EntidadeInserir.Modulo = "Pre-Stacking";
			EntidadeInserir.Prefixo = "PRE";
			EntidadeInserir.Grupo = _grupoMensagemEntityService.ObterPorId(1);

			EntidadeInserir.Mensagens = new List<MensagemIdioma>();
			EntidadeInserir.Mensagens.Add(new MensagemIdioma
			{
				Ajuda = "Teste Ajuda",
				Descricao = "Teste Descricao",
				Titulo = "Teste Titulo",
				Mensagem = EntidadeInserir,
				Idioma = Idioma.Ingles
			});

			base.TestarInserir();
		}
	}
}
