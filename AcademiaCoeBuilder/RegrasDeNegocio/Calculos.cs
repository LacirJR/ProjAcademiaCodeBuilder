using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder.RegrasDeNegocio
{
    class Calculos
    {
        public decimal FaturamentoTotal(List<Entidades.Faturamento> faturamentos )
        {
            decimal valorFaturamento = 0;
            foreach ( var faturamento in faturamentos)
            {
                
                valorFaturamento += faturamento.TotalEntrada;
               }

            return valorFaturamento;
        }

        public decimal SaidaTotal(List<Entidades.Faturamento> valoresDeSaida)
        {
            decimal valorTotaldeSaida = 0;
            foreach (var valorDeSaida in valoresDeSaida)
            {

                valorTotaldeSaida += valorDeSaida.TotalSaida;
            }

            return valorTotaldeSaida;
        }

        public decimal Lucro(decimal entrada, decimal saida)
        {
            decimal valorTotaldeLucro = entrada - saida;

            return valorTotaldeLucro;
        }

        public decimal DespesasPropaganda(List<Entidades.Propaganda> propagandas)
        {
            decimal valorTotalDespesas = 0;
            foreach (var propaganda in propagandas)
            {

                valorTotalDespesas += propaganda.CustoPropaganda;
            }

            return valorTotalDespesas;
        }
    }
}
