using System;

namespace Proyecto1_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
        // Equipo Código de barras.
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        int[] datosMax = PedirArray();
                        int max = CalcularMaximo(datosMax);
                        Console.WriteLine($"\n>>> El valor máximo del array es: {max}");
                        break;

                    case 2:
                        int[] datosMin = PedirArray();
                        int min = CalcularMinimo(datosMin);
                        Console.WriteLine($"\n>>> El valor mínimo del array es: {min}");
                        break;

                    case 3:
                        int[] datosMediana = PedirArray();
                        double mediana = CalcularMediana(datosMediana);
                        Console.WriteLine($"\n>>> La mediana del array es: {mediana:F2}");
                        break;

                    case 4:
                        int[] datosMedia = PedirArray();
                        double media = CalcularMedia(datosMedia);
                        Console.WriteLine($"\n>>> La media del array es: {media:F2}");
                        break;

                    case 5:
                        int[] datosOrdenar = PedirArray();
                        int[] arrayOrdenado = OrdenarArray(datosOrdenar);
                        Console.Write("\nArray original: ");
                        MostrarArray(datosOrdenar);
                        Console.Write("Array ordenado: ");
                        MostrarArray(arrayOrdenado);
                        break;

                    case 6:
                        int[] datosDesv = PedirArray();
                        double desviacion = CalcularDesviacionTipica(datosDesv);
                        Console.WriteLine($"\n>>> La desviación típica del array es: {desviacion:F4}");
                        break;

                    case 7:
                        int[] datosBin = PedirArray();
                        int umbral = LeerEntero("\nIntroduce el número umbral (n) para binarizar: ");
                        int[] binarizado = BinarizarArray(datosBin, umbral);
                        Console.Write("\nArray original:   ");
                        MostrarArray(datosBin);
                        Console.Write($"Array binarizado: ");
                        MostrarArray(binarizado);
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del Proyecto 1. ¡Hasta pronto!");
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

        // Muestra las opciones disponibles por pantalla
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("        PROYECTO 1: OPERACIONES ARRAY    ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Calcular el máximo de un array");
            Console.WriteLine("2. Calcular el mínimo de un array");
            Console.WriteLine("3. Calcular la mediana");
            Console.WriteLine("4. Calcular la media");
            Console.WriteLine("5. Ordenar un array de menor a mayor");
            Console.WriteLine("6. Calcular la desviación típica");
            Console.WriteLine("7. Binarizar un array en base a un número n");
            Console.WriteLine("0. Salir");
            Console.WriteLine("=========================================");
        }

        // Método auxiliar para leer un número entero de forma segura
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

        // Método auxiliar para crear y rellenar un array desde teclado
        static int[] PedirArray()
        {
            int tamaño;

            do
            {
                tamaño = LeerEntero("\n¿Cuántos números tendrá el array?: ");
                if (tamaño <= 0)
                {
                    Console.WriteLine("[Error] El tamaño del array debe ser mayor que 0.");
                }
            } while (tamaño <= 0);

            int[] array = new int[tamaño];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = LeerEntero($"Introduce el número para la posición [{i}]: ");
            }

            return array;
        }

        // Método auxiliar para imprimir un array por pantalla
        static void MostrarArray(int[] numeros)
        {
            Console.Write("[ ");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i]);
                if (i < numeros.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" ]");
        }

        // FUNCIONALIDAD 1: Calcular el máximo de un array
        static int CalcularMaximo(int[] numeros)
        {
            int maximo = numeros[0];

            for (int i = 1; i < numeros.Length; i++)
            {
                if (numeros[i] > maximo)
                {
                    maximo = numeros[i];
                }
            }

            return maximo;
        }

        // FUNCIONALIDAD 2: Calcular el mínimo de un array
        static int CalcularMinimo(int[] numeros)
        {
            int minimo = numeros[0];

            for (int i = 1; i < numeros.Length; i++)
            {
                if (numeros[i] < minimo)
                {
                    minimo = numeros[i];
                }
            }

            return minimo;
        }

        // FUNCIONALIDAD 3: Calcular la mediana de un array
        static double CalcularMediana(int[] numeros)
        {
            int[] ordenado = OrdenarArray(numeros);

            Console.Write("\nArray ordenado: ");
            MostrarArray(ordenado);

            int n = ordenado.Length;

            if (n % 2 == 0)
            {
                int centroIzquierdo = ordenado[(n / 2) - 1];
                int centroDerecho = ordenado[n / 2];
                return (centroIzquierdo + centroDerecho) / 2.0;
            }
            else
            {
                return ordenado[n / 2];
            }
        }

        // FUNCIONALIDAD 4: Calcular la media aritmética de un array
        static double CalcularMedia(int[] numeros)
        {
            double suma = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i];
            }

            return suma / numeros.Length;
        }

        // FUNCIONALIDAD 5: Ordenar un array de menor a mayor (Método de la Burbuja)
        static int[] OrdenarArray(int[] numeros)
        {
            // Creamos una copia para mantener intacto el array original
            int[] copia = new int[numeros.Length];
            for (int i = 0; i < numeros.Length; i++)
            {
                copia[i] = numeros[i];
            }

            for (int i = 0; i < copia.Length - 1; i++)
            {
                for (int j = 0; j < copia.Length - 1 - i; j++)
                {
                    if (copia[j] > copia[j + 1])
                    {
                        int aux = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = aux;
                    }
                }
            }

            return copia;
        }

        // FUNCIONALIDAD 6: Calcular la desviación típica de un array
        static double CalcularDesviacionTipica(int[] numeros)
        {
            // Reutilizamos el propio método CalcularMedia
            double media = CalcularMedia(numeros);
            double sumaCuadrados = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                double diferencia = numeros[i] - media;
                sumaCuadrados += Math.Pow(diferencia, 2);
            }

            double varianza = sumaCuadrados / numeros.Length;
            return Math.Sqrt(varianza);
        }

        // FUNCIONALIDAD 7: Binarizar un array en base a un umbral n
        static int[] BinarizarArray(int[] numeros, int n)
        {
            int[] binarizado = new int[numeros.Length];

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] < n)
                {
                    binarizado[i] = 0;
                }
                else
                {
                    binarizado[i] = 1;
                }
            }

            return binarizado;
        }
    }
}
