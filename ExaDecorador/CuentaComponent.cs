using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public abstract class CuentaComponent
    {
        public abstract void Depositar(double monto);
        public abstract bool Retirar(double monto);
        public abstract string ObtenerDescripcion();
        public abstract double ObtenerBalance();

        // MEMENTO
        public abstract CuentaMemento GuardarEstado();
        public abstract void Restaurar(CuentaMemento m);
    }
}
