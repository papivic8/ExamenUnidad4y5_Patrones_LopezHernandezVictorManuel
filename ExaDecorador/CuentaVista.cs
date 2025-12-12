using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class CuentaVista
    {
        public void Mostrar(CuentaMVC c)
        {
            Console.WriteLine("\n===== INFORMACIÓN (MVC) =====");
            Console.WriteLine("Titular: " + c.Titular);
            Console.WriteLine("Saldo: $" + c.Saldo);
        }
    }
}
