using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    public class AdministradorMementos
    {
        private Stack<CuentaMemento> historial = new Stack<CuentaMemento>();

        public void Guardar(CuentaMemento m)
        {
            historial.Push(m);
        }

        public CuentaMemento Restaurar()
        {
            if (historial.Count > 0)
                return historial.Pop();

            return null;
        }
    }
}
