using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder.Entidades
{
    class Faturamento
    {
        public string PrimaryKey { get; set; }
        public decimal TotalEntrada { get; set; }
        public decimal TotalSaida { get; set; }
        public DateTime DiaRerencia { get; set; }

    }
}
