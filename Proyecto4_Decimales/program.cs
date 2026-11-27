using System;

namespace Proyecto4_Decimales
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
//Equipo CodigodeBarra
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        double numAlza = LeerDecimal("\nIntroduce un número decimal: ");
                        double redondeado = RedondearAlAlza(numAlza);
                        Console.WriteLine($"\n>>> El número {numAlza} redondeado al alza es: {redondeado}");
                        break;

                    case 2:
                        double numTruncar = LeerDecimal("\nIntroduce un número decimal: ");
                        double sinDecimales = EliminarDecimales(numTruncar);
                        Console.WriteLine($"\n>>> El número {numTruncar} sin decimales es: {sinDecimales}");
                        break;

                    case 3:
                        Console.WriteLine("\n--- Ecuación de segundo grado: ax² + bx + c = 0 ---");
                        double a = LeerDecimal("Introduce el coeficiente a: ");
                        double b = LeerDecimal("Introduce el coeficiente b: ");
                        double c = LeerDecimal("Introduce el coeficiente c: ");
                        ResolverEcuacionSegundoGrado(a, b, c);
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del Proyecto 4. ¡Práctica completada!");
                        break;

                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Inténtalo de nuevo.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPulsa cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        // Muestra las opciones disponibles del Proyecto 4
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("          PROYECTO 4: OPERACIONES CON DECIMALES       ");
            Console.WriteLine("======================================================");
            Console.WriteLine("1. Redondear un número al alza");
            Console.WriteLine("2. Eliminar los decimales de un número");
            Console.WriteLine("3. Resolver una ecuación de segundo grado (ax² + bx + c = 0)");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================================");
        }

        // Lee un número entero de forma segura (para el menú)
        static int LeerEntero(string mensaje)
        {
            int numero;
            bool esValido;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out numero);

                if (!esValido)
                {
                    Console.WriteLine("[Error] Debes introducir un número entero válido.");
                }
            } while (!esValido);

            return numero;
        }

        // Lee un número decimal (double) de forma segura
        static double LeerDecimal(string mensaje)
        {
            double numero;
            bool esValido;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = double.TryParse(entrada, out numero);

                if (!esValido)
                {
                    Console.WriteLine("[Error] Debes introducir un número decimal válido.");
                }
            } while (!esValido);

            return numero;
        }

        // FUNCIONALIDAD 1: Redondear un número al alza
        static double RedondearAlAlza(double numero)
        {
            return Math.Ceiling(numero);
        }

        // FUNCIONALIDAD 2: Eliminar los decimales de un número (truncar)
        static double EliminarDecimales(double numero)
        {
            return Math.Truncate(numero);
        }

        // FUNCIONALIDAD 3: Resolver la ecuación de segundo grado ax² + bx + c = 0
        static void ResolverEcuacionSegundoGrado(double a, double b, double c)
        {
            // Comprobamos primero que realmente sea una ecuación de segundo grado
            if (a == 0)
            {
                Console.WriteLine("\n[Aviso] Si a = 0, no es una ecuación de segundo grado.");
                if (b != 0)
                {
                    double xLineal = -c / b;
                    Console.WriteLine($">>> Es una ecuación de primer grado con solución única: x = {xLineal:F2}");
                }
                else
                {
                    Console.WriteLine(">>> No tiene solución válida (a = 0 y b = 0).");
                }
                return;
            }

            // Calculamos el discriminante: b² - 4ac
            double discriminante = Math.Pow(b, 2) - (4 * a * c);

            if (discriminante > 0)
            {
                // Dos soluciones reales distintas
                double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine("\n>>> La ecuación tiene dos soluciones reales distintas:");
                Console.WriteLine($"    x1 = {x1:F2}");
                Console.WriteLine($"    x2 = {x2:F2}");
            }
            else if (discriminante == 0)
            {
                // Una única solución real doble
                double x = -b / (2 * a);
                Console.WriteLine("\n>>> La ecuación tiene una única solución real (doble):");
                Console.WriteLine($"    x = {x:F2}");
            }
            else
            {
                // Discriminante negativo: sin solución en los números reales
                Console.WriteLine("\n>>> La ecuación no tiene soluciones reales (el discriminante es negativo).");
            }
        }
    }
}
