using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class BancoFlyweightFactory
    {
        private static Dictionary<string, BancoFlyweight> bancos = new Dictionary<string, BancoFlyweight>();

        public static BancoFlyweight ObtenerBanco(string nombre, string sucursal)
        {
            string clave = nombre + sucursal;

            if (!bancos.ContainsKey(clave))
            {
                bancos[clave] = new BancoFlyweight(nombre, sucursal);
            }

            return bancos[clave];
        }
    }
}
