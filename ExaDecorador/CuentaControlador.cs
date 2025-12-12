using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class CuentaControlador
    {
        private CuentaMVC modelo;
        private CuentaVista vista;

        public CuentaControlador(CuentaMVC m, CuentaVista v)
        {
            modelo = m;
            vista = v;
        }

        public void Sincronizar(string titular, double saldo)
        {
            modelo.Titular = titular;
            modelo.Saldo = saldo;
        }

        public void Mostrar()
        {
            vista.Mostrar(modelo);
        }
    }
}
