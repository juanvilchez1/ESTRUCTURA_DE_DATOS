using System;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    // Método para agregar un nodo al final de la lista
    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Método para imprimir los elementos de la lista
    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node current = head;
        Console.Write("Lista enlazada: ");
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Método para invertir la lista enlazada
    public void Reverse()
    {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.Next; // Guardar el siguiente nodo
            current.Next = prev; // Invertir el enlace
            prev = current;      // Mover el puntero 'prev' al nodo actual
            current = next;      // Mover al siguiente nodo
        }

        head = prev; // Actualizar la cabeza de la lista
    }

    // Método para buscar un valor en la lista y contar las apariciones
    public void Search(int value)
    {
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node current = head;
        int count = 0;

        while (current != null)
        {
            if (current.Data == value)
            {
                count++;
            }
            current = current.Next;
        }

        if (count > 0)
        {
            Console.WriteLine($"El valor {value} se encontró {count} vez/veces en la lista.");
        }
        else
        {
            Console.WriteLine($"El valor {value} no fue encontrado en la lista.");
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        // Agregar elementos a la lista
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(20);
        list.Add(40);

        Console.WriteLine("Lista original:");
        list.Print();

        // Invertir la lista
        Console.WriteLine("\nInvirtiendo la lista...");
        list.Reverse();
        list.Print();

        // Buscar un valor en la lista
        Console.WriteLine("\nBuscando valores...");
        list.Search(20); // Valor que existe
        list.Search(50); // Valor que no existe
    }
}
