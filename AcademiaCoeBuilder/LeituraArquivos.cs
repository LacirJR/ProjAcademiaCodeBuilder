using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder
{
    class LeituraArquivos
    {
        public List<Entidades.Alunos> LeituraAlunos()
        {
            var tabelaAlunos = new List<Entidades.Alunos>();
            var arquivoAlunos = File.ReadAllText(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\AlunosV2.csv");
            var linhasAluno = arquivoAlunos.Split(',', '\n');


            var lista = linhasAluno.ToList();


            lista.RemoveAll(linha => string.IsNullOrEmpty(linha));

            lista.RemoveRange(0, 6);

            int position = 0;
            foreach (string line in linhasAluno)
            {
                if (position == lista.Count())
                {
                    break;
                }
                else
                {
                    string primaryKey = lista[position++];
                    string nome = lista[position++];
                    string email = lista[position++];
                    string telefone = lista[position++].Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                    string endereco = lista[position++];
                    string dataCadastro = lista[position++];

                    

                    var aluno = new Entidades.Alunos();
                    aluno.PrimaryKey = primaryKey;
                    aluno.Nome = nome;
                    aluno.Email = email;
                    aluno.Telefone = long.Parse(telefone);
                    aluno.Endereco = endereco;
                    aluno.DataCadastro = DateTime.Parse(dataCadastro);

                    tabelaAlunos.Add(aluno);
                    
                }
            }
         
            return tabelaAlunos;
        }


        public List<Entidades.Faturamento> LeituraFaturamento()
        {
            var arquivoFaturamento = File.ReadAllText(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\Faturamentos.csv");
            var tabelaFaturamento = new List<Entidades.Faturamento>();
            
            TextFieldParser parser = new TextFieldParser(new StringReader(arquivoFaturamento));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] linhas;
            var lista = new List<string>();

            while (!parser.EndOfData)
            {
                linhas = parser.ReadFields();


                foreach (string linha in linhas)
                {
                    lista.Add(linha);
                }
            }
                int position = 0;
                lista.RemoveRange(0, 4);
                foreach (var linha in lista)
                {
                if (position == lista.Count())
                    break;

                    string primaryKey = lista[position++];
                    string diaFaturamento = lista[position++];
                    string totalEntrada = lista[position++].Replace("R$", "").Replace(" ", "").Replace(".", "");
                    string totalSaida = lista[position++].Replace("R$", "").Replace(" ", "").Replace(".", "");

                    var faturamento = new Entidades.Faturamento();
                    faturamento.PrimaryKey = primaryKey;
                    faturamento.DiaRerencia = Convert.ToDateTime(diaFaturamento);
                    faturamento.TotalEntrada = decimal.Parse(totalEntrada);
                    faturamento.TotalSaida = decimal.Parse(totalSaida);

                    tabelaFaturamento.Add(faturamento);
                }

            return tabelaFaturamento;
            }

        public List<Entidades.Propaganda> LeituraPropaganda()
        {
            var arquivoPropaganda = File.ReadAllText(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\Propagandas.csv");
            var tabelaPropaganda = new List<Entidades.Propaganda>();

            TextFieldParser parser = new TextFieldParser(new StringReader(arquivoPropaganda));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] fields;
            var lista = new List<string>();

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();


                foreach (string field in fields)
                {
                    lista.Add(field);
                }
            }
            int position = 0;
            lista.RemoveRange(0, 4);
            foreach (var linha in lista)
            {
                if (position == lista.Count())
                    break;

                string primaryKey = lista[position++];
                string empresaDivulgadora = lista[position++];
                string custoPropaganda = lista[position++].Replace("R$", "").Replace(" ", "").Replace(".", "");
                string dataPropaganda = lista[position++];

                var propaganda = new Entidades.Propaganda();
                propaganda.PrimaryKey = primaryKey;
                propaganda.DataPropaganda = Convert.ToDateTime(dataPropaganda);
                propaganda.CustoPropaganda = decimal.Parse(custoPropaganda);
                propaganda.EmpresaDivulgadora = empresaDivulgadora;

                tabelaPropaganda.Add(propaganda);
            }

            return tabelaPropaganda;

        }
    }

    
}
