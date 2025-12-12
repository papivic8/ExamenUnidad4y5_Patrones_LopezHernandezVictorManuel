using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class BancoFlyweight
    {
        public string Nombre { get; private set; }
        public string Sucursal { get; private set; }

        public BancoFlyweight(string nombre, string sucursal)
        {
            Nombre = nombre;
            Sucursal = sucursal;
        }
    }

}
