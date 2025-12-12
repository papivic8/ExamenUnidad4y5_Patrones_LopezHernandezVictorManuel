using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public abstract class CuentaDecorator : CuentaComponent
    {
        protected CuentaComponent cuenta;

        public CuentaDecorator(CuentaComponent cuenta)
        {
            this.cuenta = cuenta;
        }

        public override void Depositar(double monto) { cuenta.Depositar(monto); }
        public override bool Retirar(double monto) { return cuenta.Retirar(monto); }
        public override string ObtenerDescripcion() { return cuenta.ObtenerDescripcion(); }
        public override double ObtenerBalance() { return cuenta.ObtenerBalance(); }

        public override CuentaMemento GuardarEstado() { return cuenta.GuardarEstado(); }
        public override void Restaurar(CuentaMemento m) { cuenta.Restaurar(m); }
    }
}
