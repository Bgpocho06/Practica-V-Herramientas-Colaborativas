using System;

namespace Proyecto2_Numero
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            // Equipo Código  de barras
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        int numPrimo = LeerEntero("\nIntroduce un número entero para comprobar si es primo: ");
                        if (EsPrimo(numPrimo))
                        {
                            Console.WriteLine($"\n>>> El número {numPrimo} ES primo.");
                        }
                        else
                        {
                            Console.WriteLine($"\n>>> El número {numPrimo} NO es primo.");
                        }
                        break;

                    case 2:
                        int numFact = LeerEnteroNoNegativo("\nIntroduce un número entero positivo (o 0) para calcular su factorial (máx. 20): ");
                        if (numFact > 20)
                        {
                            Console.WriteLine("\n[Aviso] Un número mayor que 20 desborda la capacidad de un tipo 'long' en C#.");
                        }
                        else
                        {
                            long factorial = CalcularFactorial(numFact);
                            Console.WriteLine($"\n>>> El factorial de {numFact} ({numFact}!) es: {factorial}");
                        }
                        break;

                    case 3:
                        int totalSegundos = LeerEnteroNoNegativo("\nIntroduce la cantidad total de segundos: ");
                        ConvertirSegundos(totalSegundos);
                        break;

                    case 4:
                        int[] seriePell = ObtenerSeriePell(15);
                        Console.WriteLine("\n>>> Los primeros 15 números de la serie de Pell son:");
                        MostrarArray(seriePell);
                        break;

                    case 5:
                        int numArmstrong = LeerEnteroNoNegativo("\nIntroduce un número entero positivo para comprobar si es de Armstrong: ");
                        if (EsArmstrong(numArmstrong))
                        {
                            Console.WriteLine($"\n>>> El número {numArmstrong} ES un número de Armstrong.");
                        }
                        else
                        {
                            Console.WriteLine($"\n>>> El número {numArmstrong} NO es un número de Armstrong.");
                        }
                        break;

                    case 6:
                        int numDigitos = LeerEntero("\nIntroduce un número entero para comprobar si todos sus dígitos son diferentes: ");
                        if (TieneDigitosDiferentes(numDigitos))
                        {
                            Console.WriteLine($"\n>>> El número {numDigitos} tiene TODOS sus dígitos diferentes.");
                        }
                        else
                        {
                            Console.WriteLine($"\n>>> El número {numDigitos} tiene dígitos REPETIDOS.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del Proyecto 2. ¡Hasta pronto!");
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

        // Muestra las opciones disponibles del Proyecto 2
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("           PROYECTO 2: OPERACIONES CON NÚMEROS        ");
            Console.WriteLine("======================================================");
            Console.WriteLine("1. Comprobar si un número es primo");
            Console.WriteLine("2. Calcular el factorial de un número");
            Console.WriteLine("3. Convertir segundos en horas, minutos y segundos");
            Console.WriteLine("4. Mostrar los primeros 15 números de la serie de Pell");
            Console.WriteLine("5. Comprobar si un número es de Armstrong");
            Console.WriteLine("6. Comprobar si un número tiene todos sus dígitos diferentes");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================================");
        }

        // Lee cualquier número entero (positivo, negativo o cero)
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

        // Lee un número entero mayor o igual que 0
        static int LeerEnteroNoNegativo(string mensaje)
        {
            int numero;
            do
            {
                numero = LeerEntero(mensaje);
                if (numero < 0)
                {
                    Console.WriteLine("[Error] El número no puede ser negativo.");
                }
            } while (numero < 0);

            return numero;
        }

        // Muestra por pantalla los elementos de un array separados por comas
        static void MostrarArray(int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i]);
                if (i < numeros.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        // FUNCIONALIDAD 1: Comprobar si un número es primo
        static bool EsPrimo(int numero)
        {
            // Los números menores o iguales a 1 no son primos por definición
            if (numero <= 1)
            {
                return false;
            }

            // Buscamos divisores desde 2 hasta la raíz cuadrada del número
            int limite = (int)Math.Sqrt(numero);
            for (int i = 2; i <= limite; i++)
            {
                if (numero % i == 0)
                {
                    // Si encontramos un divisor exacto, ya sabemos que no es primo
                    return false;
                }
            }

            return true;
        }

        // FUNCIONALIDAD 2: Calcular el factorial de un número
        static long CalcularFactorial(int numero)
        {
            // Por definición matemática, 0! = 1 y 1! = 1
            long resultado = 1;

            for (int i = 2; i <= numero; i++)
            {
                resultado *= i;
            }

            return resultado;
        }

        // FUNCIONALIDAD 3: Convertir segundos en horas, minutos y segundos
        static void ConvertirSegundos(int totalSegundos)
        {
            int horas = totalSegundos / 3600;
            int segundosRestantes = totalSegundos % 3600;
            int minutos = segundosRestantes / 60;
            int segundos = segundosRestantes % 60;

            Console.WriteLine($"\n>>> {totalSegundos} segundos = {horas} hora(s), {minutos} minuto(s) y {segundos} segundo(s).");
        }

        // FUNCIONALIDAD 4: Devolver los primeros 'cantidad' números de la serie de Pell
        static int[] ObtenerSeriePell(int cantidad)
        {
            int[] pell = new int[cantidad];

            if (cantidad >= 1)
            {
                pell[0] = 0;
            }
            if (cantidad >= 2)
            {
                pell[1] = 1;
            }

            // Fórmula de recurrencia: P(n) = 2 * P(n-1) + P(n-2)
            for (int i = 2; i < cantidad; i++)
            {
                pell[i] = 2 * pell[i - 1] + pell[i - 2];
            }

            return pell;
        }

        // FUNCIONALIDAD 5: Comprobar si un número es de Armstrong (narcisista)
        static bool EsArmstrong(int numero)
        {
            // 1. Contamos cuántos dígitos tiene el número
            int digitos = 0;
            int temp = numero;

            if (temp == 0)
            {
                digitos = 1;
            }
            else
            {
                while (temp > 0)
                {
                    digitos++;
                    temp /= 10;
                }
            }

            // 2. Sumamos cada dígito elevado al número total de dígitos
            int suma = 0;
            temp = numero;

            while (temp > 0)
            {
                int ultimoDigito = temp % 10;
                suma += (int)Math.Pow(ultimoDigito, digitos);
                temp /= 10;
            }

            // 3. Si la suma coincide con el número original, es un número de Armstrong
            return suma == numero;
        }

        // FUNCIONALIDAD 6: Comprobar si un número tiene todos sus dígitos diferentes
        static bool TieneDigitosDiferentes(int numero)
        {
            // Usamos valor absoluto para soportar también números negativos (ej. -123)
            int temp = Math.Abs(numero);

            // Array de 10 posiciones (índices del 0 al 9) para marcar dígitos ya vistos
            bool[] digitosVistos = new bool[10];

            // Caso especial: el 0 tiene un único dígito, así que todos sus dígitos son diferentes
            if (temp == 0)
            {
                return true;
            }

            while (temp > 0)
            {
                int digito = temp % 10;

                // Si ese dígito ya había aparecido antes, hay repetición
                if (digitosVistos[digito])
                {
                    return false;
                }

                // Marcamos el dígito como visto y avanzamos al siguiente
                digitosVistos[digito] = true;
                temp /= 10;
            }

            return true;
        }
    }
}
