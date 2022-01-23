using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder
{
    class Fluxo
    {
        public void Run()
        {
            var leituraArquivos = new LeituraArquivos();
            
            var sql = new Conexao.Sql();
    

        
            var alunos = leituraArquivos.LeituraAlunos();
            var faturamentos = leituraArquivos.LeituraFaturamento();
            var propagandas = leituraArquivos.LeituraPropaganda();

            var regrasDeNegocio = new RegrasDeNegocio.SelecionandoClientesPromocao();
            


            foreach (var aluno in alunos)
            {
                regrasDeNegocio.SelecionandoClientesAno(alunos);
                sql.InserirTabelaAlunos(aluno);
            }


            foreach (var faturamento in faturamentos)
            {
                sql.InserirTabelaFaturamento(faturamento);
            }


            foreach (var propaganda in propagandas)
            {
                sql.InserirTabelaPropaganda(propaganda);
            }

            ArquivoResultadostxt();
            ArquivoAlunosPromocao();

        }

        private void ArquivoResultadostxt() {
            var leituraArquivos = new LeituraArquivos();
            var faturamento = leituraArquivos.LeituraFaturamento();
            var calculos = new RegrasDeNegocio.Calculos();
            var promocaoClientes = new RegrasDeNegocio.SelecionandoClientesPromocao();
            
            

            string resultados = "O Faturamento total do período é de: R$" + calculos.FaturamentoTotal(faturamento)+
                "\r\n\r\nO Lucro total do periodo é de: R$"+ calculos.Lucro(calculos.FaturamentoTotal(faturamento), calculos.SaidaTotal(faturamento))+
                "\r\n\r\nE as Despesas totais são de: R$"+ calculos.DespesasPropaganda(leituraArquivos.LeituraPropaganda())+"\r\n";

            File.WriteAllText(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\resultado.txt", resultados);

        }
        private void ArquivoAlunosPromocao()
        {
            var leitura = new LeituraArquivos();
            var listaPromocao = new RegrasDeNegocio.SelecionandoClientesPromocao();
            var promocaoTresMeses = listaPromocao.SelecionandoClientesAno(leitura.LeituraAlunos());

            TextWriter tw = new StreamWriter(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\20-01-2022\listaAlunos.txt");
            tw.WriteLine("Um total de " + promocaoTresMeses.Count() + " alunos estão nas condições da promoção! \r\n\r\n");
            
            foreach (var aluno in promocaoTresMeses) tw.WriteLine("ALUNO: " + aluno.Nome + "     DATA DE CADASTRO:" + aluno.DataCadastro);
            tw.Close();

        }

    }
}

