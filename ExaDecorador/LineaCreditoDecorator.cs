using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class LineaCreditoDecorator : CuentaDecorator
    {
        private double credito;

        public LineaCreditoDecorator(CuentaComponent cuenta, double credito)
            : base(cuenta)
        {
            this.credito = credito;
        }

        public override bool Retirar(double monto)
        {
            Console.WriteLine("\n¿Retirar de cuenta (1) o de línea de crédito (2)?");
            string op = Console.ReadLine();

            if (op == "1")
                return base.Retirar(monto);

            if (op == "2")
            {
                if (monto <= credito)
                {
                    credito -= monto;
                    Console.WriteLine("Retiro de crédito exitoso.");
                    return true;
                }
                Console.WriteLine("Crédito insuficiente.");
                return false;
            }

            Console.WriteLine("Opción no válida.");
            return false;
        }

        public override string ObtenerDescripcion()
        {
            return base.ObtenerDescripcion() + "\nLínea de crédito: $" + credito;
        }
    }
}
