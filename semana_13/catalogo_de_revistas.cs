using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        static List<string> catalogo = new List<string>();
        
        static void Main(string[] args)
        {
            // 1. Crear el catálogo de revistas
            InicializarCatalogo();
            
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== CATÁLOGO DE REVISTAS =====");
                Console.WriteLine("1. Buscar título (Recursivo)");
                Console.WriteLine("2. Buscar título (Iterativo)");
                Console.WriteLine("3. Mostrar todos los títulos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        BuscarTituloRecursivo();
                        break;
                    case "2":
                        BuscarTituloIterativo();
                        break;
                    case "3":
                        MostrarCatalogo();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Pulse cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        static void InicializarCatalogo()
        {
            // 2. Ingresar 10 títulos al catálogo
            catalogo.Add("National Geographic");
            catalogo.Add("Time");
            catalogo.Add("Scientific American");
            catalogo.Add("The Economist");
            catalogo.Add("Wired");
            catalogo.Add("New Scientist");
            catalogo.Add("Popular Mechanics");
            catalogo.Add("IEEE Spectrum");
            catalogo.Add("Nature");
            catalogo.Add("Science");
            
            // Ordenar el catálogo para la búsqueda binaria
            catalogo.Sort();
        }
        
        static void MostrarCatalogo()
        {
            Console.Clear();
            Console.WriteLine("===== TÍTULOS EN EL CATÁLOGO =====");
            
            for (int i = 0; i < catalogo.Count; i++)
            {
                Console.WriteLine($"{i+1}. {catalogo[i]}");
            }
            
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void BuscarTituloRecursivo()
        {
            Console.Clear();
            Console.WriteLine("===== BÚSQUEDA RECURSIVA =====");
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();
            
            bool encontrado = BusquedaBinariaRecursiva(titulo, 0, catalogo.Count - 1);
            
            Console.WriteLine(encontrado ? "Resultado: ENCONTRADO" : "Resultado: NO ENCONTRADO");
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static bool BusquedaBinariaRecursiva(string titulo, int inicio, int fin)
        {
            if (inicio > fin)
                return false;
                
            int medio = (inicio + fin) / 2;
            int comparacion = string.Compare(titulo, catalogo[medio], StringComparison.OrdinalIgnoreCase);
            
            if (comparacion == 0)
                return true;
            else if (comparacion < 0)
                return BusquedaBinariaRecursiva(titulo, inicio, medio - 1);
            else
                return BusquedaBinariaRecursiva(titulo, medio + 1, fin);
        }
        
        static void BuscarTituloIterativo()
        {
            Console.Clear();
            Console.WriteLine("===== BÚSQUEDA ITERATIVA =====");
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();
            
            bool encontrado = BusquedaBinariaIterativa(titulo);
            
            Console.WriteLine(encontrado ? "Resultado: ENCONTRADO" : "Resultado: NO ENCONTRADO");
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static bool BusquedaBinariaIterativa(string titulo)
        {
            int inicio = 0;
            int fin = catalogo.Count - 1;
            
            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                int comparacion = string.Compare(titulo, catalogo[medio], StringComparison.OrdinalIgnoreCase);
                
                if (comparacion == 0)
                    return true;
                else if (comparacion < 0)
                    fin = medio - 1;
                else
                    inicio = medio + 1;
            }
            
            return false;
        }
    }
}


