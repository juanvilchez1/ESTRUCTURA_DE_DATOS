using System;

public class Node
{
    public int Data { get; set; } // Valor del nodo
    public Node Next { get; set; } // Referencia al siguiente nodo

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head; // Nodo inicial de la lista enlazada

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

    // Método para imprimir los elementos de la lista enlazada
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
        Node prev = null;    // Nodo previo, inicialmente null
        Node current = head; // Nodo actual, comenzando en la cabeza
        Node next = null;    // Nodo siguiente, inicialmente null

        while (current != null)
        {
            next = current.Next; // Guardar el siguiente nodo
            current.Next = prev; // Invertir el enlace
            prev = current;      // Mover el puntero 'prev' al nodo actual
            current = next;      // Mover al siguiente nodo
        }

        head = prev; // Actualizar la cabeza de la lista
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
        list.Add(40);
        list.Add(50);

        Console.WriteLine("Lista original:");
        list.Print();

        // Invertir la lista
        Console.WriteLine("\nInvirtiendo la lista...");
        list.Reverse();
        list.Print();
    }
}
