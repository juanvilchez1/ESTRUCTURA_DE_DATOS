public struct Contact
{
    public string Name;      // Nombre del contacto
    public string Phone;     // Número de teléfono

    // Constructor para inicializar un contacto
    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    // Método para mostrar el contacto como texto
    public override string ToString()
    {
        return $"Nombre: {Name}, Teléfono: {Phone}";
    }
}

using System;

public class Agenda
{
    private Contact[] contacts;  // Arreglo de contactos
    private int contactCount;    // Cantidad de contactos actuales

    public Agenda(int maxContacts)
    {
        contacts = new Contact[maxContacts]; // Inicializar el arreglo
        contactCount = 0;
    }

    // Método para agregar un contacto
    public void AddContact(string name, string phone)
    {
        if (contactCount < contacts.Length)
        {
            contacts[contactCount] = new Contact(name, phone);
            contactCount++;
            Console.WriteLine("Contacto agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("La agenda está llena.");
        }
    }

    // Método para visualizar todos los contactos
    public void ShowContacts()
    {
        if (contactCount == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
            return;
        }

        Console.WriteLine("Lista de contactos:");
        for (int i = 0; i < contactCount; i++)
        {
            Console.WriteLine($"{i + 1}. {contacts[i]}");
        }
    }

    // Método para buscar un contacto por nombre
    public void SearchContact(string name)
    {
        bool found = false;
        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Contacto encontrado: {contacts[i]}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda(100); // Crear una agenda con capacidad para 100 contactos

        while (true)
        {
            Console.WriteLine("\n--- Agenda Telefónica ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Visualizar contactos");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ingrese el nombre: ");
                    string name = Console.ReadLine();
                    Console.Write("Ingrese el teléfono: ");
                    string phone = Console.ReadLine();
                    agenda.AddContact(name, phone);
                    break;

                case "2":
                    agenda.ShowContacts();
                    break;

                case "3":
                    Console.Write("Ingrese el nombre del contacto a buscar: ");
                    string searchName = Console.ReadLine();
                    agenda.SearchContact(searchName);
                    break;

                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
}

