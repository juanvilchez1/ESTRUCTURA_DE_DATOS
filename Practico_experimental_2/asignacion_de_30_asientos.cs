using System;
using System.Collections.Generic;

namespace AsignacionAsientos
{
    // Clase que representa una persona en la cola
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que gestiona la asignación de asientos
    public class AsignacionAsientos
    {
        private Queue<Persona> cola; // Cola para gestionar el orden de llegada
        private int asientosDisponibles;

        public AsignacionAsientos(int capacidad)
        {
            cola = new Queue<Persona>();
            asientosDisponibles = capacidad;
        }

        // Método para agregar una persona a la cola
        public void AgregarPersona(string nombre)
        {
            if (asientosDisponibles > 0)
            {
                Persona persona = new Persona(nombre);
                cola.Enqueue(persona);
                asientosDisponibles--;
                Console.WriteLine($"{nombre} se ha unido a la cola. Asientos restantes: {asientosDisponibles}");
            }
            else
            {
                Console.WriteLine("Todos los asientos están ocupados. No se puede agregar más personas.");
            }
        }

        // Método para asignar asientos en orden de llegada
        public void AsignarAsientos()
        {
            while (cola.Count > 0)
            {
                Persona persona = cola.Dequeue();
                Console.WriteLine($"{persona.Nombre} ha subido a la atracción.");
            }
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            AsignacionAsientos asignacion = new AsignacionAsientos(30);

            // Simulación de personas uniéndose a la cola
            for (int i = 1; i <= 35; i++)
            {
                asignacion.AgregarPersona($"Persona {i}");
            }

            // Asignación de asientos
            asignacion.AsignarAsientos();
        }
    }
}