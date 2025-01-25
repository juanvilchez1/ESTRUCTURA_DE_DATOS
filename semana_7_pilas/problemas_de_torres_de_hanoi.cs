using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Método principal para resolver las Torres de Hanoi usando pilas
    public static void ResolverTorresDeHanoi(int numDiscos)
    {
        // Inicializar las pilas para las tres torres
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();

        // Llenar la torre origen con los discos en orden descendente (disco más grande abajo)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Determinar el número total de movimientos requeridos
        int totalMovimientos = (int)Math.Pow(2, numDiscos) - 1;

        // Nombrar las torres para mostrar los movimientos
        char origen = 'A', auxiliar = 'B', destino = 'C';

        // Si el número de discos es impar, intercambiar las torres auxiliar y destino
        if (numDiscos % 2 == 0)
        {
            char temp = destino;
            destino = auxiliar;
            auxiliar = temp;
        }

        // Realizar los movimientos
        for (int i = 1; i <= totalMovimientos; i++)
        {
            if (i % 3 == 1)
            {
                MoverDisco(torreOrigen, torreDestino, origen, destino);
            }
            else if (i % 3 == 2)
            {
                MoverDisco(torreOrigen, torreAuxiliar, origen, auxiliar);
            }
            else if (i % 3 == 0)
            {
                MoverDisco(torreAuxiliar, torreDestino, auxiliar, destino);
            }
        }
    }

    // Método para mover un disco de una torre a otra
    private static void MoverDisco(Stack<int> torreOrigen, Stack<int> torreDestino, char nombreOrigen, char nombreDestino)
    {
        if (torreOrigen.Count == 0) // Si la torre origen está vacía
        {
            int disco = torreDestino.Pop();
            torreOrigen.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreDestino} a {nombreOrigen}");
        }
        else if (torreDestino.Count == 0) // Si la torre destino está vacía
        {
            int disco = torreOrigen.Pop();
            torreDestino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            int topOrigen = torreOrigen.Peek();
            int topDestino = torreDestino.Peek();

            if (topOrigen > topDestino)
            {
                int disco = torreDestino.Pop();
                torreOrigen.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreDestino} a {nombreOrigen}");
            }
            else
            {
                int disco = torreOrigen.Pop();
                torreDestino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            }
        }
    }

    // Método principal
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el número de discos:");
        int numDiscos = int.Parse(Console.ReadLine());

        Console.WriteLine($"Resolviendo las Torres de Hanoi para {numDiscos} discos:");
        ResolverTorresDeHanoi(numDiscos);
    }
}
