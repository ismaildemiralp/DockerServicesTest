using System;
using System.Threading.Tasks;
using Npgsql;


namespace test_pgsql
{
    class Pgsql_Test
    {
        static void Main(string[] args)
        {
            string con_test;

            NpgsqlConnection con = new NpgsqlConnection(@"server=*******; Port=5432; Database=erp-test; user ID=posstgres; password=*****");
            con.Open();
            var sql = "SELECT version()";
            using var cmd = new NpgsqlCommand(sql, con);
            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL version: {version}");
            
            if (con.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connected");
                con_test = Console.ReadLine();

                cmd.CommandText = "DROP TABLE IF EXISTS test";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE test(id SERIAL PRIMARY KEY, ad VARCHAR(255), soyad VARCHAR(255))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO test(ad, soyad) VALUES('İsmail', 'Demiralp')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO test(ad, soyad) VALUES('Deneme-1', 'Deneme')";
                cmd.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("Connection Failed !!");
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
