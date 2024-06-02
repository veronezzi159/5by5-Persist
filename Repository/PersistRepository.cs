using Models;
using System;
using Microsoft.Data.SqlClient;
namespace Repository
{
    public class PersistRepository
    {
        private string _connectionString;
        SqlConnection connection;
        public PersistRepository()
        {
            _connectionString += "Data Source=127.0.0.1;"; // Server
            _connectionString += "Initial Catalog=DBRadar;"; //DataBase
            _connectionString += " User Id=sa; Password=SqlServer2019!;";//User and Password
            _connectionString += "TrustServerCertificate=Yes;";//certificate

            connection = new SqlConnection(_connectionString);
            connection.Open();
        }

        public int InsertInSql(string path, string file)
        {
            try
            {
                var list = ReadFile.GetData(path, file);
                string sql = "INSERT INTO TB_Infracao (Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, Sentido, Situacao ,TipoPista, DataInativacao, Latitude, Longitude, VelocidadeLeve) VALUES ";
                if (list == null) return 0;
                if (list.Count == 1)
                {
                    sql += $"('{list[0].Concessionaria}', {int.Parse(list[0].AnoDoPnvSnv)}, '{list[0].TipoDeRadar}', '{list[0].Rodovia}', '{list[0].Uf}', {list[0].KmM.Replace(',', '.')}, " +
                        $"{double.Parse(list[0].Municipio)},'{list[0].Sentido}', '{list[0].Situacao}', '{list[0].TipoPista}',null , '{list[0].Latitude}', '{list[0].Longitude}', {(list[0].VelocidadeLeve)} )";
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (item != list.Last())
                            sql += $"('{item.Concessionaria}', {int.Parse(item.AnoDoPnvSnv)}, '{item.TipoDeRadar}', '{item.Rodovia}', '{item.Uf}', {item.KmM.Replace(',', '.')}, " +
                        $"'{item.Municipio}', '{item.Sentido}', '{item.Situacao}', '{item.TipoPista}',null ,'{item.Latitude}', '{item.Longitude}', {double.Parse(item.VelocidadeLeve)} ),";
                        else
                            sql += $"('{item.Concessionaria}', {int.Parse(item.AnoDoPnvSnv)}, '{item.TipoDeRadar}', '{item.Rodovia}', '{item.Uf}', {item.KmM.Replace(',','.')}, " +
                        $"'{item.Municipio}', '{item.Sentido}', '{item.Situacao}', '{item.TipoPista}' ,null ,'{item.Latitude}', '{item.Longitude}', {item.VelocidadeLeve} )";
                    }
                }
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection = connection;
                command.ExecuteNonQuery();
                Console.WriteLine($"Success data insertion, number of data: {list.Count()}");

                return list.Count;
            }
            catch (Exception)
            {                
                Console.WriteLine("Insert error");
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }                        
    }
}
