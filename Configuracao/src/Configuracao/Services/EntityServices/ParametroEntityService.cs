namespace GxpConfiguracao.Services.EntityServices
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Interfaces;
	using Models.Parametro;
	
	public class ParametroEntityService : ParametroEntityService<Parametro, int>, IParametroEntityService
	{
		public void RegistrarValor(Parametro parametro)
		{
			Inserir(parametro);
			Persistir();
		}

		public void AtualizarValor(Parametro parametro)
		{
			Atualizar(parametro);
			Persistir();
		}

		public Parametro ObterPorChave(string modulo, string chave)
		{
			return Repository
				.ObterTodos()
				.SingleOrDefault(c => c.Modulo == modulo && c.Chave == chave);
		}

		public Parametro ObterPorChaveAsNoTracking(string modulo, string chave)
		{
			IQueryable<Parametro> consulta = Repository.ObterTodos()
				.AsNoTracking()
				.Where(c => c.Modulo == modulo && c.Chave == chave);

			return consulta.SingleOrDefault();
		}

		public IList<Parametro> ObterParametros(ParametroTo pesquisa)
		{
			Repository.HabilitarExcluidos();

			try
			{
				var consulta = Repository.ObterTodos();

				if (!string.IsNullOrEmpty(pesquisa.Modulo))
				{
					consulta = consulta.Where(x => x.Modulo.ToUpper().Contains(pesquisa.Modulo.ToUpper()));
				}

				if (!string.IsNullOrEmpty(pesquisa.Chave))
				{
					consulta = consulta.Where(x => x.Chave.ToUpper().Contains(pesquisa.Chave.ToUpper()));
				}

				if (!string.IsNullOrEmpty(pesquisa.Valor))
				{
					consulta = consulta.Where(x => x.Valor.ToUpper().Contains(pesquisa.Valor.ToUpper()));
				}

				return AplicarPesquisa(pesquisa, consulta);
			}
			catch (Exception e)
			{
				Logger.Error("Falha ao obter parametros", e);
				return null;
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}

		public bool AtualizarParametro(ParametroTo parametroTo, int usuario)
		{
			Repository.HabilitarExcluidos();
			
			try
			{
				var parametro = Repository.ObterPorId(parametroTo.Id);

				if (!string.IsNullOrEmpty(parametroTo.Modulo))
				{
					parametro.Modulo = parametroTo.Modulo;
				}

				if (!string.IsNullOrEmpty(parametroTo.Chave))
				{
					parametro.Chave = parametroTo.Chave;
				}

				if (!string.IsNullOrEmpty(parametroTo.Valor))
				{
					parametro.Valor = parametroTo.Valor;
				}
				
				parametro.Excluido = parametroTo.Excluido;
				
				parametro.DataAlteracao = DateTime.Now;
				parametro.IdUsuarioAlteracao = usuario;

				Repository.Atualizar(parametro);
				Repository.Persistir();
				return true;
			}
			catch (Exception e)
			{
				Logger.Error("Falha ao atualizar parametro", e);
				return false;
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}

		public Parametro ObterParametroPorId(int idParametro)
		{
			Repository.HabilitarExcluidos();

			try
			{
				return Repository.ObterPorId(idParametro);
			}
			catch (Exception e)
			{
				Logger.Error("Falha ao obter parametro", e);
				return null;
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}

		public bool VerificarParametroExistente(ParametroTo parametroTo)
		{
			Repository.HabilitarExcluidos();

			try
			{
				return Repository.ObterTodos().Any(a => a.Modulo == parametroTo.Modulo && a.Chave == parametroTo.Chave);
			}
			catch (Exception e)
			{
				Logger.Error("Falha ao obter parametro", e);
				return false;
			}
			finally
			{
				Repository.DesabilitarExcluidos();
			}
		}
    }
}
