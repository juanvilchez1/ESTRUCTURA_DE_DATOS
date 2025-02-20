using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        // Conjunto ficticio de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano_{i}");
        }

        // Conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"Ciudadano_{i}");
        }

        // Conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        for (int i = 76; i <= 150; i++)
        {
            vacunadosAstrazeneca.Add($"Ciudadano_{i}");
        }

        // Listado de ciudadanos que han recibido las dos vacunas (intersección)
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer (diferencia)
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca (diferencia)
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Listado de ciudadanos que no se han vacunado (diferencia)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Resultados
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos con ambas vacunas: {vacunadosAmbas.Count}");
        Console.WriteLine($"Ciudadanos solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos solo con AstraZeneca: {soloAstrazeneca.Count}");

        // Guardar en archivos
        File.WriteAllLines("NoVacunados.txt", noVacunados);
        File.WriteAllLines("VacunadosAmbas.txt", vacunadosAmbas);
        File.WriteAllLines("SoloPfizer.txt", soloPfizer);
        File.WriteAllLines("SoloAstrazeneca.txt", soloAstrazeneca);

        Console.WriteLine("Datos guardados en archivos.");
    }
}
