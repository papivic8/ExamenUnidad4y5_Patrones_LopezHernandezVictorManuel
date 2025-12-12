using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class ValidacionSaldoDecorator : CuentaDecorator
    {
        private double minimo;

        public ValidacionSaldoDecorator(CuentaComponent cuenta, double minimo)
            : base(cuenta)
        {
            this.minimo = minimo;
        }

        public override bool Retirar(double monto)
        {
            if (cuenta.ObtenerBalance() - monto < minimo)
            {
                Console.WriteLine("No puede dejar menos de $" + minimo + ".");
                return false;
            }
            return base.Retirar(monto);
        }
    }
}
