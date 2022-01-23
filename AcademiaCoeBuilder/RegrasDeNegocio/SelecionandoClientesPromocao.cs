using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder.RegrasDeNegocio
{
    class SelecionandoClientesPromocao
    {
        public List<Entidades.Alunos> SelecionandoClientesAno(List<Entidades.Alunos> clientes)
        {
            var promocaoTresMeses = new List<Entidades.Alunos>();

            foreach ( var cliente in clientes)
            {
                DateTime Inicio2019 = new DateTime(2019, 01, 01);
                DateTime Fim2019 = new DateTime(2019, 12,31);
                if (cliente.DataCadastro >= Inicio2019 && cliente.DataCadastro <= Fim2019)
                {
                    promocaoTresMeses.Add(cliente);

                }
            }
           

            return promocaoTresMeses;
        }

    }
    
}
