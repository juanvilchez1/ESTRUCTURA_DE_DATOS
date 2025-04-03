class Vuelo
{
    public string Destino { get; set; }
    public int Costo { get; set; }

    public Vuelo(string destino, int costo)
    {
        Destino = destino;
        Costo = costo;
    }
}

class Aeropuerto
{
    public string Nombre { get; set; }
    public Dictionary<string, Vuelo> Vuelos { get; set; }

    public Aeropuerto(string nombre)
    {
        Nombre = nombre;
        Vuelos = new Dictionary<string, Vuelo>();
    }

    public void AgregarVuelo(string destino, int costo)
    {
        Vuelos[destino] = new Vuelo(destino, costo);
    }
}

class RedDeVuelos
{
    private Dictionary<string, Aeropuerto> aeropuertos;

    public RedDeVuelos()
    {
        aeropuertos = new Dictionary<string, Aeropuerto>();
    }

    public void AgregarAeropuerto(string nombre)
    {
        if (!aeropuertos.ContainsKey(nombre))
            aeropuertos[nombre] = new Aeropuerto(nombre);
    }

    public void AgregarVuelo(string origen, string destino, int costo)
    {
        AgregarAeropuerto(origen);
        AgregarAeropuerto(destino);
        aeropuertos[origen].AgregarVuelo(destino, costo);
    }

    public void EncontrarVueloMasBarato(string inicio, string destino)
    {
        var costos = new Dictionary<string, int>();
        var anteriores = new Dictionary<string, string>();
        var visitados = new HashSet<string>();

        foreach (var aeropuerto in aeropuertos.Keys)
            costos[aeropuerto] = int.MaxValue;
        
        costos[inicio] = 0;
        var colaPrioridad = new SortedSet<(int, string)> { (0, inicio) };

        while (colaPrioridad.Count > 0)
        {
            var (costoActual, aeropuertoActual) = colaPrioridad.Min;
            colaPrioridad.Remove(colaPrioridad.Min);

            if (visitados.Contains(aeropuertoActual)) continue;
            visitados.Add(aeropuertoActual);

            if (aeropuertoActual == destino) break;

            foreach (var vuelo in aeropuertos[aeropuertoActual].Vuelos)
            {
                int nuevoCosto = costoActual + vuelo.Value.Costo;
                if (nuevoCosto < costos[vuelo.Key])
                {
                    costos[vuelo.Key] = nuevoCosto;
                    anteriores[vuelo.Key] = aeropuertoActual;
                    colaPrioridad.Add((nuevoCosto, vuelo.Key));
                }
            }
        }

        // Reconstrucción del camino
        if (!anteriores.ContainsKey(destino))
        {
            Console.WriteLine("No hay ruta disponible.");
            return;
        }

        string ruta = destino;
        while (anteriores.ContainsKey(destino))
        {
            destino = anteriores[destino];
            ruta = destino + " -> " + ruta;
        }

        Console.WriteLine($"Ruta más barata: {ruta} con un costo de {costos[ruta.Split(' ')[0]]}");
    }
}

