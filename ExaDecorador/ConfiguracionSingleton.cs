using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class ConfiguracionSingleton
    {
        private static ConfiguracionSingleton instancia = null;

        public string NombreSistema { get; private set; }
        public string Version { get; private set; }

        private ConfiguracionSingleton()
        {
            NombreSistema = "Sistema Bancario Tec";
            Version = "2.0";
        }

        public static ConfiguracionSingleton ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new ConfiguracionSingleton();

            return instancia;
        }
    }
}
