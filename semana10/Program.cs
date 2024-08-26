using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Paso 1: Crear los conjuntos ficticios

        // Conjunto de 500 ciudadanos (IDs del 1 al 500)
        HashSet<int> ciudadanos = new HashSet<int>(Enumerable.Range(1, 500));

        // Crear conjunto de 75 ciudadanos vacunados con Pfizer
        HashSet<int> vacunadosPfizer = GenerarVacunadosAleatorios(ciudadanos, 75);

        // Crear conjunto de 75 ciudadanos vacunados con AstraZeneca
        HashSet<int> vacunadosAstraZeneca = GenerarVacunadosAleatorios(ciudadanos, 75);

        // Paso 2: Realizar las operaciones necesarias

        // 1. Listado de ciudadanos que no se han vacunado
        HashSet<int> noVacunados = new HashSet<int>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstraZeneca);

        // 2. Listado de ciudadanos que han recibido las dos vacunas
        HashSet<int> vacunadosDosDosis = new HashSet<int>(vacunadosPfizer);
        vacunadosDosDosis.IntersectWith(vacunadosAstraZeneca);

        // 3. Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        HashSet<int> soloPfizer = new HashSet<int>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // 4. Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        HashSet<int> soloAstraZeneca = new HashSet<int>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // Mostrar resultados:
        Console.WriteLine("Ciudadanos que no se han vacunado: " + string.Join(", ", noVacunados));
        Console.WriteLine("Ciudadanos que han recibido las dos vacunas: " + string.Join(", ", vacunadosDosDosis));
        Console.WriteLine("Ciudadanos que solamente han recibido la vacuna de Pfizer: " + string.Join(", ", soloPfizer));
        Console.WriteLine("Ciudadanos que solamente han recibido la vacuna de AstraZeneca: " + string.Join(", ", soloAstraZeneca));
    }

    static HashSet<int> GenerarVacunadosAleatorios(HashSet<int> ciudadanos, int cantidad)
    {
        Random random = new Random();
        return new HashSet<int>(ciudadanos.OrderBy(x => random.Next()).Take(cantidad));
    }
}

