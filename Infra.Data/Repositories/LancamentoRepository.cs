using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using Test.Domain.Chain;
using Test.Domain.Entities;
using Test.Domain.Interface;

namespace Infra.Data.Repositories
{
    public class LancamentoRepository : BaseRepository, ILancamentoRepository
    {
        public LancamentoRepository(IConfiguration configurationManager) : base(configurationManager) { }

        public bool DoDebit(Lancamentos lancamento)
        {
            var connectionString = GetConnection();            
            var resultado = false;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = @"INSERT INTO tbl_Lancamentos(Lancamento,TipoLancamento,Conta,Valor) VALUES(@Lancamento,@TipoLancamento,@Conta,@Valor);";                    
                    var execute = con.Query<bool>(sql, lancamento).FirstOrDefault();
                    resultado = execute;
                }
                catch (Exception ex)
                {
                    throw ex;                    
                }
                finally
                {
                    con.Close();
                }
                return resultado;
            }
        }

        public bool DoCredit(Lancamentos lancamento)
        {
            var connectionString = GetConnection();
            var resultado = false;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = @"INSERT INTO tbl_Lancamentos(Lancamento,TipoLancamento,Conta,Valor) VALUES(@Lancamento,@TipoLancamento,@Conta,@Valor);";
                    var execute = con.Query<bool>(sql, lancamento).FirstOrDefault();
                    resultado = execute;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return resultado;
            }
        }

    }
}
