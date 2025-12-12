using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class LimiteDiarioDecorator : CuentaDecorator
    {
        private double limite;
        private double acumulado;

        public LimiteDiarioDecorator(CuentaComponent cuenta, double limite) : base(cuenta)
        {
            this.limite = limite;
            acumulado = 0;
        }

        public override bool Retirar(double monto)
        {
            if (acumulado + monto > limite)
            {
                Console.WriteLine("Límite diario excedido.");
                return false;
            }

            bool ok = base.Retirar(monto);
            if (ok) acumulado += monto;
            return ok;
        }
    }
}
