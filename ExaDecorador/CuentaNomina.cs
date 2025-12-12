using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class CuentaNomina : CuentaComponent
    {
        private string titular;
        private string numero;
        public double saldo;
        private BancoFlyweight banco;

        public CuentaNomina(string titular, string numero, double saldo)
        {
            this.titular = titular;
            this.numero = numero;
            this.saldo = saldo;
            this.banco = BancoFlyweightFactory.ObtenerBanco("TecBank", "Sucursal Centro");
        }

        public override void Depositar(double monto)
        {
            saldo += monto;
        }

        public override bool Retirar(double monto)
        {
            if (saldo >= monto)
            {
                saldo -= monto;
                return true;
            }
            Console.WriteLine("Saldo insuficiente.");
            return false;
        }

        public override string ObtenerDescripcion()
        {
            return "Cuenta de Nómina\nTitular: " + titular +
                   "\nNúmero: " + numero +
                   "\nBanco: " + banco.Nombre +
                   "\nSucursal: " + banco.Sucursal;
        }

        public override double ObtenerBalance()
        {
            return saldo;
        }

        // MEMENTO
        public override CuentaMemento GuardarEstado()
        {
            return new CuentaMemento(this.saldo);
        }

        public override void Restaurar(CuentaMemento m)
        {
            if (m != null)
                this.saldo = m.Saldo;
        }
    }
}
