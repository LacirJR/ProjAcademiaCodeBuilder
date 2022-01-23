using System;

namespace AcademiaCodeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var leiuraFaturamento = new LeituraArquivos();
            var fluxo = new Fluxo();
            fluxo.Run();
            

            
        }
    }
}
