using System;

class Nodo
{
    public int Dato;
    public Nodo Izquierdo, Derecho;

    public Nodo(int dato)
    {
        Dato = dato;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Insertar nodo en el árbol
    public void Insertar(int dato)
    {
        raiz = InsertarRec(raiz, dato);
    }

    private Nodo InsertarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return new Nodo(dato);

        if (dato < nodo.Dato)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, dato);
        else if (dato > nodo.Dato)
            nodo.Derecho = InsertarRec(nodo.Derecho, dato);

        return nodo;
    }

    // Buscar un nodo
    public bool Buscar(int dato)
    {
        return BuscarRec(raiz, dato);
    }

    private bool BuscarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return false;
        if (nodo.Dato == dato)
            return true;
        return dato < nodo.Dato ? BuscarRec(nodo.Izquierdo, dato) : BuscarRec(nodo.Derecho, dato);
    }

    // Recorridos del árbol
    public void InOrden() => InOrdenRec(raiz);
    private void InOrdenRec(Nodo nodo)
    {
        if (nodo == null) return;
        InOrdenRec(nodo.Izquierdo);
        Console.Write(nodo.Dato + " ");
        InOrdenRec(nodo.Derecho);
    }

    public void PreOrden() => PreOrdenRec(raiz);
    private void PreOrdenRec(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Dato + " ");
        PreOrdenRec(nodo.Izquierdo);
        PreOrdenRec(nodo.Derecho);
    }

    public void PostOrden() => PostOrdenRec(raiz);
    private void PostOrdenRec(Nodo nodo)
    {
        if (nodo == null) return;
        PostOrdenRec(nodo.Izquierdo);
        PostOrdenRec(nodo.Derecho);
        Console.Write(nodo.Dato + " ");
    }

    // Método para eliminar un nodo
    public void Eliminar(int dato)
    {
        raiz = EliminarRec(raiz, dato);
    }

    private Nodo EliminarRec(Nodo nodo, int dato)
    {
        if (nodo == null) return nodo;

        if (dato < nodo.Dato)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, dato);
        else if (dato > nodo.Dato)
            nodo.Derecho = EliminarRec(nodo.Derecho, dato);
        else
        {
            if (nodo.Izquierdo == null) return nodo.Derecho;
            if (nodo.Derecho == null) return nodo.Izquierdo;

            nodo.Dato = MinValor(nodo.Derecho);
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Dato);
        }
        return nodo;
    }

    private int MinValor(Nodo nodo)
    {
        int min = nodo.Dato;
        while (nodo.Izquierdo != null)
        {
            min = nodo.Izquierdo.Dato;
            nodo = nodo.Izquierdo;
        }
        return min;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- Menú Árbol Binario de Búsqueda ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorrer InOrden");
            Console.WriteLine("5. Recorrer PreOrden");
            Console.WriteLine("6. Recorrer PostOrden");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un valor: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    Console.WriteLine("Valor insertado.");
                    break;

                case 2:
                    Console.Write("Ingrese un valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Valor encontrado." : "Valor no encontrado.");
                    break;

                case 3:
                    Console.Write("Ingrese un valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valor);
                    Console.WriteLine("Valor eliminado.");
                    break;

                case 4:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden();
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Recorrido PreOrden:");
                    arbol.PreOrden();
                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.PostOrden();
                    Console.WriteLine();
                    break;

                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 7);
    }
}



