using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class CuentaMemento
    {
        public double Saldo { get; private set; }

        public CuentaMemento(double saldo)
        {
            Saldo = saldo;
        }
    }
}
