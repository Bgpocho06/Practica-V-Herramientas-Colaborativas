using System;

namespace Proyecto3_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
//Equipo CodigoDeBarras
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        string textoPalindromo = LeerTextoNoVacio("\nIntroduce una palabra o frase: ");
                        if (EsPalindromo(textoPalindromo))
                        {
                            Console.WriteLine($"\n>>> \"{textoPalindromo}\" ES un palíndromo.");
                        }
                        else
                        {
                            Console.WriteLine($"\n>>> \"{textoPalindromo}\" NO es un palíndromo.");
                        }
                        break;

                    case 2:
                        string nombre = LeerTextoNoVacio("\nIntroduce un nombre: ");
                        MostrarMayusculasYMinusculas(nombre);
                        break;

                    case 3:
                        string frase = LeerTextoNoVacio("\nIntroduce el texto donde buscar: ");
                        char letra = LeerCaracter("Introduce la letra que quieres contar: ");
                        int ocurrencias = ContarOcurrenciasLetra(frase, letra);
                        Console.WriteLine($"\n>>> La letra '{letra}' aparece {ocurrencias} vez/veces en el texto.");
                        break;

                    case 4:
                        string primerTexto = LeerTextoNoVacio("\nIntroduce el primer String: ");
                        string segundoTexto = LeerTextoNoVacio("Introduce el segundo String: ");
                        int repeticiones = LeerEnteroNoNegativo("¿Cuántas veces quieres repetirlos?: ");
                        string resultadoRepetido = RepetirDosTextos(primerTexto, segundoTexto, repeticiones);
                        Console.WriteLine($"\n>>> Resultado: {resultadoRepetido}");
                        break;

                    case 5:
                        string textoOriginal = LeerTextoNoVacio("\nIntroduce un String: ");
                        string textoDuplicado = DuplicarLetras(textoOriginal);
                        Console.WriteLine($"\n>>> Resultado: {textoDuplicado}");
                        break;

                    case 6:
                        string textoBase = LeerTextoNoVacio("\nIntroduce el texto principal: ");
                        string textoABorrar = LeerTextoNoVacio("Introduce el texto que deseas borrar: ");
                        string textoFinal = BorrarSubcadena(textoBase, textoABorrar);
                        Console.WriteLine($"\n>>> Resultado: \"{textoFinal}\"");
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del Proyecto 3. ¡Hasta pronto!");
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

        // Muestra las opciones disponibles del Proyecto 3
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("           PROYECTO 3: OPERACIONES CON STRINGS        ");
            Console.WriteLine("======================================================");
            Console.WriteLine("1. Comprobar si un String es un palíndromo");
            Console.WriteLine("2. Escribir un nombre en mayúsculas y minúsculas");
            Console.WriteLine("3. Contar ocurrencias de una letra en un String");
            Console.WriteLine("4. Repetir dos Strings las veces indicadas");
            Console.WriteLine("5. Repetir cada carácter de un String");
            Console.WriteLine("6. Borrar de un String las apariciones de otro");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================================");
        }

        // Lee un número entero de forma segura
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

        // Lee un entero mayor o igual que 0
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

        // Lee una cadena de texto asegurando que no esté vacía ni sea null
        static string LeerTextoNoVacio(string mensaje)
        {
            string texto;
            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("[Error] El texto no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }

        // Lee exactamente un único carácter desde teclado
        static char LeerCaracter(string mensaje)
        {
            string entrada;
            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (string.IsNullOrEmpty(entrada) || entrada.Length != 1)
                {
                    Console.WriteLine("[Error] Debes introducir exactamente un único carácter.");
                }
            } while (string.IsNullOrEmpty(entrada) || entrada.Length != 1);

            return entrada[0];
        }

        // FUNCIONALIDAD 1: Comprobar si un String es un palíndromo
        static bool EsPalindromo(string texto)
        {
            // Normalizamos: pasamos a minúsculas y quitamos espacios para soportar frases
            string limpio = texto.ToLower().Replace(" ", "");

            int izquierda = 0;
            int derecha = limpio.Length - 1;

            while (izquierda < derecha)
            {
                if (limpio[izquierda] != limpio[derecha])
                {
                    return false;
                }
                izquierda++;
                derecha--;
            }

            return true;
        }

        // FUNCIONALIDAD 2: Escribir un nombre en mayúsculas y minúsculas
        static void MostrarMayusculasYMinusculas(string nombre)
        {
            Console.WriteLine($"\n>>> En MAYÚSCULAS: {nombre.ToUpper()}");
            Console.WriteLine($">>> En minúsculas: {nombre.ToLower()}");
        }

        // FUNCIONALIDAD 3: Devolver el número de ocurrencias de una letra dentro de un String
        static int ContarOcurrenciasLetra(string texto, char letraBuscada)
        {
            int contador = 0;
            char letraObjetivo = char.ToLower(letraBuscada);

            for (int i = 0; i < texto.Length; i++)
            {
                // Comparamos en minúsculas para contar tanto 'a' como 'A'
                if (char.ToLower(texto[i]) == letraObjetivo)
                {
                    contador++;
                }
            }

            return contador;
        }

        // FUNCIONALIDAD 4: Repetir dos Strings distintos las veces indicadas
        static string RepetirDosTextos(string texto1, string texto2, int veces)
        {
            if (veces == 0)
            {
                return "";
            }

            string resultado = "";

            for (int i = 0; i < veces; i++)
            {
                resultado += texto1 + " " + texto2;

                // Añadimos un espacio separador entre repeticiones, excepto en la última
                if (i < veces - 1)
                {
                    resultado += " ";
                }
            }

            return resultado;
        }

        // FUNCIONALIDAD 5: Repetir cada carácter de un String
        static string DuplicarLetras(string texto)
        {
            string resultado = "";

            for (int i = 0; i < texto.Length; i++)
            {
                resultado += texto[i];
                resultado += texto[i];
            }

            return resultado;
        }

        // FUNCIONALIDAD 6: Borrar del primer String las apariciones del segundo
        static string BorrarSubcadena(string textoPrincipal, string subcadena)
        {
            // Replace sustituye todas las coincidencias exactas por vacío
            // Trim elimina posibles espacios sobrantes al inicio o final tras el borrado
            return textoPrincipal.Replace(subcadena, "").Trim();
        }
    }
}
