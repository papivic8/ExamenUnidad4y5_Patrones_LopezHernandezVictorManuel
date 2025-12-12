using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class NotificacionDecorator : CuentaDecorator
    {
        public NotificacionDecorator(CuentaComponent cuenta): base(cuenta) { }

        public override void Depositar(double monto)
        {
            base.Depositar(monto);
            Console.WriteLine("Notificación: Depósito realizado.");
        }

        public override bool Retirar(double monto)
        {
            bool ok = base.Retirar(monto);
            Console.WriteLine(ok ?
                "Notificación: Retiro exitoso." :
                "Notificación: Retiro denegado.");
            return ok;
        }
    }
}
