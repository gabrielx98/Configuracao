namespace GxpConfiguracao.Services.EntityServices.Interfaces
{
	using System;
	using System.Collections.Generic;
	using Models.Email;
	using Models.Email.Enums;
	using GxpCore.Infraestrutura.Services;
	using GxpCore.Infraestrutura.Services.Tos;

	public interface INotificacaoMensagemEntityService : IGxpEntityService<NotificacaoMensagem, int>
    {
        void RegistrarNotificacao(NotificacaoMensagem notificacao);

        void AtualizarNotificacao(NotificacaoMensagem notificacao);

        IList<NotificacaoMensagem> ObterPendentes();

        IList<NotificacaoMensagem> ObterNotificacaoMensagem(TipoNotificacao tipo,
                                                            DateTime dataInicioInclusao,
                                                            DateTime dataFimInclusao,
                                                            string assunto,
                                                            string mensagem,
                                                            string destinatarios,
                                                            bool? pendente,
                                                            bool? sucesso,
                                                            PesquisaTo pesquisa);
    }
}
