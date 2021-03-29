using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BytradeApiOn.Functions
{
    public class SqlCommad
    {

        public void gerarInsert(string comando,int id)
        {

            string connectionString =
            "Password=160491;Persist Security Info=True;User ID=Bytrade;Initial Catalog=ByTradeGeralApp;Data Source=localhost";
            string[] sqlComando = comando.Split("##");
            
            string tabela = sqlComando[0];
            string tabelaId = sqlComando[1];
            string codEmpresa = sqlComando[2];
            string tabelaInsert = sqlComando[3];
            string tabelaUpdate = sqlComando[4];

            string sqlConsulta = "SELECT * FROM " + tabela + " WHERE Id = " + tabelaId + " and CompanyId=" + codEmpresa + ";";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand commandConsulta = new SqlCommand(sqlConsulta, connection);
                SqlCommand command = new SqlCommand(tabelaInsert, connection);
                SqlCommand commandUpdate = new SqlCommand(tabelaUpdate, connection);
                connection.Open();

                int count = 0;

                try
                {

                    SqlDataReader leitura = commandConsulta.ExecuteReader();
                    while (leitura.Read())
                    {
                         count++;
                    }
                    leitura.Close();

                    if (count == 0)
                    {
                           SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}",
                                reader[0], reader[1], reader[2]);
                        }
                        reader.Close();
                    }
                    else
                    {
                        SqlDataReader update = commandUpdate.ExecuteReader();
                        while (update.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}",
                                update[0], update[1], update[2]);
                        }
                        update.Close();
                    }
                }
                catch (Exception ex)
                    {
                        var comandoReplaceInsert = tabelaInsert.Replace("'","^/");
                        var comandoReplaceUpdate = tabelaUpdate.Replace("'","^/");
                        var sql = "INSERT INTO[BytradeGeralApp].[dbo].[Log](CompanyId, FileGenerationId, Status, Sql, Date,sqlUpdate, Tabela, IdTabela) values ("+ codEmpresa + ", "+ id +", 0, '"+ comandoReplaceInsert + "', CURRENT_TIMESTAMP,'"+ commandUpdate +"','"+ tabela +"',"+ tabelaId +");";
                        SqlCommand command2 = new SqlCommand(sql, connection);
                        SqlDataReader reader2 = command2.ExecuteReader();
                        reader2.Close();
                    }
                //Console.ReadLine();
            }
        }

        public bool gerarLog(string comando)
        {

            string connectionString =
            "Password=160491;Persist Security Info=True;User ID=Bytrade;Initial Catalog=ByTradeGeralApp;Data Source=localhost";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                comando = comando.Replace("^/", "'");
                SqlCommand command = new SqlCommand(comando, connection);
                connection.Open();

                try
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
