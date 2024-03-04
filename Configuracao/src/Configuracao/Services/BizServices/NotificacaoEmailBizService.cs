namespace GxpConfiguracao.Services.BizServices
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Mail;
	using System.Net.Mime;
	using Interfaces;
	using Models.Email;
	using Models.Email.Enums;

	public class NotificacaoEmailBizService : GxpBizService, INotificacaoMensagemBizService
	{
		private readonly IParametroBizService _parametroBizService;

		private readonly string _servidorEmail;
		private readonly int _portaServidorEmail;
		private readonly string _remetenteEmail;
		private readonly string _tituloRemetenteEmail;
		private readonly string _usuarioRemetenteEmail;
		private readonly string _senhaRemetenteEmail;
		private readonly bool _autenticacaoServidorEmail;

		public NotificacaoEmailBizService(IParametroBizService parametroBizService1)
		{
			_parametroBizService = parametroBizService1;

			_servidorEmail = _parametroBizService.ObterValor(NotificacaoParametro.Modulo, NotificacaoParametro.ServidorEmail);
			_portaServidorEmail = _parametroBizService.ObterValor<int>(NotificacaoParametro.Modulo, NotificacaoParametro.PortaServidorEmail);
			_remetenteEmail = _parametroBizService.ObterValor(NotificacaoParametro.Modulo, NotificacaoParametro.RemetenteEmail);
			_tituloRemetenteEmail = _parametroBizService.ObterValor(NotificacaoParametro.Modulo, NotificacaoParametro.TituloRemetenteEmail);
			_usuarioRemetenteEmail = _parametroBizService.ObterValor(NotificacaoParametro.Modulo, NotificacaoParametro.UsuarioRemetenteEmail);
			_senhaRemetenteEmail = _parametroBizService.ObterValor(NotificacaoParametro.Modulo, NotificacaoParametro.SenhaRemetenteEmail);
			_autenticacaoServidorEmail = _parametroBizService.ObterValor<bool>(NotificacaoParametro.Modulo, NotificacaoParametro.AutenticacaoServidorEmail);
		}

		public TipoNotificacao TipoSuportado
		{
			get
			{
				return TipoNotificacao.Email;
			}
		}

		public void EnviarNotificacao(NotificacaoMensagem notificacao)
		{
			try
			{
				var mail = new MailMessage
				{
					From = new MailAddress(_remetenteEmail, _tituloRemetenteEmail)
				};

				if (string.IsNullOrEmpty(notificacao.Destinatarios))
				{
					notificacao.Destinatarios = string.Empty;
					throw new Exception("Destinátarios não informado");
				}

				string[] destinatarios = notificacao.Destinatarios.Split(';');

				foreach (string destinatario in destinatarios)
				{
					if (string.IsNullOrWhiteSpace(destinatario))
					{
						continue;
					}

					mail.To.Add(destinatario);
				}

                if (!string.IsNullOrEmpty(notificacao.DestinatariosEmCC))
                {
                    string[] destinatariosEmCC = notificacao.DestinatariosEmCC.Split(';');

                    foreach (string destinatarioEmCC in destinatariosEmCC)
                    {
                        if (string.IsNullOrWhiteSpace(destinatarioEmCC))
                        {
                            continue;
                        }

                        mail.CC.Add(destinatarioEmCC);
                    }
                }

                if (!string.IsNullOrEmpty(notificacao.DestinatariosEmBCC))
                {
                    string[] destinatariosEmBCC = notificacao.DestinatariosEmBCC.Split(';');

                    foreach (string destinatarioEmBCC in destinatariosEmBCC)
                    {
                        if (string.IsNullOrWhiteSpace(destinatarioEmBCC))
                        {
                            continue;
                        }

                        mail.Bcc.Add(destinatarioEmBCC);
                    }
                }

                mail.IsBodyHtml = notificacao.IsHtml;
				mail.Subject = notificacao.Assunto;

				var listaStreams = new List<Stream>();
				if (notificacao.IsHtml)
				{
					AlternateView htmlView = AlternateView.CreateAlternateViewFromString(notificacao.Mensagem, null, "text/html");

					foreach (var item in notificacao.ListaAnexos)
					{
						var stream = GetStream(item.Caminho);
						listaStreams.Add(stream);
						LinkedResource emailAttachment = new LinkedResource(stream);
						emailAttachment.ContentId = item.Chave;

						htmlView.LinkedResources.Add(emailAttachment);
					}

					mail.AlternateViews.Add(htmlView);
				}
				else
				{
					mail.Body = notificacao.Mensagem;
				}

				if (notificacao.ListaArquivoAnexos != null)
				{
					foreach (var anexo in notificacao.ListaArquivoAnexos)
					{
						ContentType contentType = new ContentType(anexo.ContentType);
						Attachment attach = new Attachment(GetStream(anexo.Caminho), contentType);
						attach.ContentDisposition.FileName = anexo.Nome;
						mail.Attachments.Add(attach);	
					}
				}

				var smtp = new SmtpClient
				{
					Host = _servidorEmail,
					Port = _portaServidorEmail,
					EnableSsl = false
				};

				if (_autenticacaoServidorEmail)
				{
					smtp.Credentials = new NetworkCredential(_usuarioRemetenteEmail, _senhaRemetenteEmail);
				}

				smtp.Send(mail);

				foreach (var item in listaStreams)
				{
					item.Close();
				}
			}
			catch (Exception ex)
			{
				throw new GxpMensagemException("1", "1", ex);
			}
		}

		public Stream GetStream(string imgUrl)
		{
			Stream stream = null;

			try
			{
				stream = File.OpenRead(imgUrl);

				return stream;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
