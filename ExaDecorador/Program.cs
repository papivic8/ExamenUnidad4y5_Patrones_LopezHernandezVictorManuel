using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaDecorador
{
    class Program
    {
        static void Main(string[] args)
        {
            // SINGLETON
            ConfiguracionSingleton cfg = ConfiguracionSingleton.ObtenerInstancia();
            Console.WriteLine("=== " + cfg.NombreSistema + " v" + cfg.Version + " ===");

            Console.Write("Nombre del titular: ");
            string nombre = Console.ReadLine();

            Console.Write("Tipo de cuenta (1=Ahorro, 2=Nómina):");
            string tipo = Console.ReadLine();

            Console.Write("Saldo inicial: $");
            double saldo = Convert.ToDouble(Console.ReadLine());

            CuentaComponent cuenta;
            if (tipo == "1")
                cuenta = new CuentaAhorro(nombre, "A-001", saldo);
            else
                cuenta = new CuentaNomina(nombre, "N-001", saldo);

            Console.Write("\n¿Activar validación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
                cuenta = new ValidacionSaldoDecorator(cuenta, 100);

            Console.Write("¿Activar límite diario? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Límite: $");
                double lim = Convert.ToDouble(Console.ReadLine());
                cuenta = new LimiteDiarioDecorator(cuenta, lim);
            }

            Console.Write("¿Activar línea de crédito? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Crédito: $");
                double cred = Convert.ToDouble(Console.ReadLine());
                cuenta = new LineaCreditoDecorator(cuenta, cred);
            }

            Console.Write("¿Activar notificaciones? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
                cuenta = new NotificacionDecorator(cuenta);

            AdministradorMementos admin = new AdministradorMementos();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n===== MENÚ =====");
                Console.WriteLine("1. Depositar");
                Console.WriteLine("2. Retirar");
                Console.WriteLine("3. Ver información");
                Console.WriteLine("4. Deshacer operación (Memento)");
                Console.WriteLine("5. Ver información con MVC");
                Console.WriteLine("6. Salir");

                Console.Write("Opción: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.Write("Monto: $");
                        admin.Guardar(cuenta.GuardarEstado());
                        cuenta.Depositar(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case "2":
                        Console.Write("Monto: $");
                        admin.Guardar(cuenta.GuardarEstado());
                        cuenta.Retirar(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case "3":
                        Console.WriteLine("\n" + cuenta.ObtenerDescripcion());
                        Console.WriteLine("Saldo actual: $" + cuenta.ObtenerBalance());
                        break;

                    case "4":
                        cuenta.Restaurar(admin.Restaurar());
                        Console.WriteLine("Operación deshecha.");
                        break;

                    case "5":
                        CuentaMVC modelo = new CuentaMVC();
                        CuentaVista vista = new CuentaVista();
                        CuentaControlador controlador = new CuentaControlador(modelo, vista);

                        controlador.Sincronizar(nombre, cuenta.ObtenerBalance());
                        controlador.Mostrar();
                        break;

                    case "6":
                        salir = true;
                        break;
                }
            }
        }
    }
}
