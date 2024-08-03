using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Generar tabla de multiplicar");
            Console.WriteLine("2. Ingresar concepto y definición");
            Console.WriteLine("3. Ingresar nombre completo");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TablaDeMultiplicar();
                    break;
                case "2":
                    ConceptoYDefinicion();
                    break;
                case "3":
                    NombreCompleto();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            // Console.WriteLine("Presione cualquier tecla para continuar...");
            // Console.ReadKey();
        }
    }

     static void TablaDeMultiplicar()
    {
        Console.Write("Ingrese el número para generar la tabla de multiplicar (1-10): ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 1 || numero > 10)
        {
            Console.WriteLine("Número fuera del rango permitido.");
            return;
        }

        
        string nombreDeArchivo = "tablas_multiplicar.txt";
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", nombreDeArchivo);

        string contenido = $"Tabla de multiplicar del {numero}\n";
        for (int i = 1; i <= 10; i++)
        {
            contenido += $"{numero} x {i} = {numero * i}\n";
        }
        contenido += "\n"; 

        File.AppendAllText(filePath, contenido);

        Console.WriteLine("Tabla de multiplicar generada y almacenada en " + filePath);
    }

    static void ConceptoYDefinicion()
    {
        Console.Write("Ingrese el concepto y su definición (concepto:definición): ");
        string input = Console.ReadLine();

        if (!input.Contains(":"))
        {
            Console.WriteLine("Formato incorrecto.");
            return;
        }

        string nombreDeArchivo = "conceptos_definiciones.txt";
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", nombreDeArchivo);

        File.AppendAllText(filePath, input + Environment.NewLine);

        Console.WriteLine("Concepto y definición almacenados en " + filePath);
    }

    static void NombreCompleto()
    {
        Console.Write("Ingrese el nombre completo: ");
        string nombre = Console.ReadLine();

        string nombreDeArchivo = "nombres_completos.txt";
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", nombreDeArchivo);

        File.AppendAllText(filePath, nombre + Environment.NewLine);

        Console.WriteLine("Nombre completo almacenado en " + filePath);
    }
}
