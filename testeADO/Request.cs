using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testeADO
{
    internal class Request
    {
        public string DataSource { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public Request(string datasource, string database)
        {
            this.DataSource = datasource;
            this.Database = database;
            this.ConnectionString = "monta aqui sua connectionString";
        }
        public List<string> GetParcelas()
        {

            using (FbConnection connection = new FbConnection(ConnectionString)) //Instanciando a conexão com base na biblioteca de acesso a dados do firebird
            {
                using (var produtos = new FbCommand($"SELECT * FROM PRODUTOS", connection))
                {
                    try
                    {
                        connection.Open();
                        FbDataAdapter adapterItem = new FbDataAdapter(produtos);
                        DataSet dataset = new DataSet();

                        adapterItem.Fill(dataset, "PRODUTOS");

                        List<string> parcelas = new List<string>();
                        foreach (DataTable table in dataset.Tables) //Lista as tabelas
                        {
                            DataRowCollection rows = table.Rows;

                            foreach (DataRow row in rows) //Lista as linhas das tabelas
                            {

                                parcelas.Add(row[0].ToString());
                            }
                        }
                        return parcelas;
                    }
                    catch (Exception e)
                    {
                       
                    }
                    return null;
                }
            }
        }

        public void Insert(string data, int caixa, string idempresa, string tipo)
        {

            using (FbConnection connection = new FbConnection(ConnectionString))
            {
                using (var saida = new FbCommand($"INSERT INTO BLABLABLA (DATA, CAIXA, IDEMPRESA, TIPO) VALUES ('{data}', {caixa}, {idempresa}, '{tipo}')", connection))
                {
                    try
                    {
                        connection.Open();
                        saida.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

    }
}
