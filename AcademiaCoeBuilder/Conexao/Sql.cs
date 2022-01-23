using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace AcademiaCodeBuilder.Conexao
{
    class Sql
    {
        public readonly SqlConnection _conexao;

        public Sql() { 
            string conexao = File.ReadAllText(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\Conexao.txt");
           
        _conexao = new SqlConnection(conexao);
        }

        public void InserirTabelaAlunos(Entidades.Alunos aluno)
        {
            try
            {
                _conexao.Open();
                    
                string query = "INSERT INTO Aluno (Identificador , Nome , Email, Telefone, Endereco, DataCadastro) " +
                    "VALUES (@Identificador , @Nome , @Email, @Telefone, @Endereco, @DataCadastro);";
                using(SqlCommand cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("Identificador", aluno.PrimaryKey);
                    cmd.Parameters.AddWithValue("Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("Email", aluno.Email);
                    cmd.Parameters.AddWithValue("Telefone", aluno.Telefone);
                    cmd.Parameters.AddWithValue("Endereco", aluno.Endereco);
                    cmd.Parameters.AddWithValue("DataCadastro", aluno.DataCadastro);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void InserirTabelaFaturamento(Entidades.Faturamento faturamento)
        {
            try
            {
                _conexao.Open();

                string query = "INSERT INTO Faturamento (Identificador , TotalEntrada , TotalSaida, DiaReferencia) " +
                    "VALUES (@Identificador , @TotalEntrada , @TotalSaida, @DiaReferencia);";
                using (SqlCommand cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("Identificador", faturamento.PrimaryKey);
                    cmd.Parameters.AddWithValue("TotalEntrada", faturamento.TotalEntrada);
                    cmd.Parameters.AddWithValue("TotalSaida", faturamento.TotalSaida);
                    cmd.Parameters.AddWithValue("DiaReferencia", faturamento.DiaRerencia);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void InserirTabelaPropaganda(Entidades.Propaganda propaganda)
        {
            try
            {
                _conexao.Open();

                string query = "INSERT INTO Propaganda (Identificador , EmpresaDivulgadora , Custo, DataPropaganda) " +
                    "VALUES (@Identificador , @EmpresaDivulgadora , @Custo, @DataPropaganda);";
                using (SqlCommand cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("Identificador", propaganda.PrimaryKey);
                    cmd.Parameters.AddWithValue("EmpresaDivulgadora", propaganda.EmpresaDivulgadora);
                    cmd.Parameters.AddWithValue("Custo", propaganda.CustoPropaganda);
                    cmd.Parameters.AddWithValue("DataPropaganda", propaganda.DataPropaganda);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
   
