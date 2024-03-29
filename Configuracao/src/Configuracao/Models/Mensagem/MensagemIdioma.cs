﻿namespace GxpConfiguracao.Models.Mensagem
{
	using Enums;

	public class MensagemIdioma : EntidadeBaseIdAutomatico
	{
		public Mensagem Mensagem { get; set; }

		public string Titulo { get; set; }

		public string Descricao { get; set; }

		public string Ajuda { get; set; }

		public Idioma Idioma { get; set; }
	}
}