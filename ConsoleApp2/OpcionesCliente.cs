using System.Text.RegularExpressions;
using Aspose.Cells;
using DocumentFormat.OpenXml.Drawing;
using SpreadsheetLight;
namespace ConsoleApp2
{
    internal class OpcionesCliente
    {
        public static double saldo = 0;
        public static string? nombre = "";
        public static string? apellidos = "";
        public static int DNI = 0;
        public static int clientes;
        //-------------------------------------------------------------------------------------------------------------
        public static void Login()
        {
            Console.WriteLine("****INICIO DE SESION****");
            Workbook base_excel = new Workbook("C:\\Users\\Alexis\\Desktop\\Proyectos y practicas\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            Regex regex = new(@"\d");
            string? na = "", ap = "";
            int dni = 0;
            do
            {
                do
                {
                    Console.Write("Ingrese su nombre: ");
                    na = Console.ReadLine();
                    if (regex.IsMatch(na))
                        Console.WriteLine("El texto contiene números, intente con decirme su nombre de verdad");
                } while (regex.IsMatch(na));
                do
                {
                    Console.Write("Ingrese su apellido: ");
                    ap = Console.ReadLine();
                    if (regex.IsMatch(ap))
                        Console.WriteLine("El texto contiene números, intente con decirme su apellido de verdad");
                } while (regex.IsMatch(ap));
                for (int n = 2; n <= 100; n++)
                {
                    Cell usuario = hoja.Cells[$"C{n}"];
                    if (usuario.StringValue == $"{na} {ap}")
                    {
                        nombre = na;
                        apellidos = ap;
                        break;
                    }
                }
                if (nombre == na || apellidos == ap)
                    break;
                if (nombre == "" || apellidos == "")
                {
                    Console.WriteLine("El nombre o apellido no coinciden, intentelo de nuevo o registrese");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            } while (true);
            if (nombre == "" || apellidos == "") { }
            else
            {
                do
                {
                    try
                    {
                        Console.Write("Ingrese su DNI: ");
                        dni = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Parece que no ingresaste un valor adecuado, intentelo de nuevo");
                    }
                    for (int n = 2; n <= 100; n++)
                    {
                        Cell celda_dni = hoja.Cells[$"D{n}"];
                        if (celda_dni.StringValue == $"{dni}")
                        {
                            DNI = dni;
                            Cell celda_saldo = hoja.Cells[$"E{n}"];
                            saldo = celda_saldo.DoubleValue;
                            break;
                        }
                    }
                } while (DNI == 0);
                Console.Clear();
                Console.WriteLine("Inicio de sesion completada!");
                Console.ReadKey();
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Registrarse()
        {
            Regex regex = new(@"\d");
            Console.WriteLine("****REGISTRO****");
            do
            {
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine();
                if (regex.IsMatch(nombre))
                    Console.WriteLine("El texto contiene números, intente con decirme su nombre de verdad");
            } while (regex.IsMatch(nombre));
            do
            {
                Console.Write("Ingrese su apellido: ");
                apellidos = Console.ReadLine();
                if (regex.IsMatch(apellidos))
                    Console.WriteLine("El texto contiene números, intente con decirme su apellido de verdad");
            } while (regex.IsMatch(apellidos));
            do
            {
                try
                {
                    Console.Write("Ingrese su DNI: ");
                    if (int.TryParse(Console.ReadLine(), out DNI))
                        break;
                    else
                        Console.WriteLine("Parece que no ingresaste un número válido, inténtalo de nuevo");
                }
                catch (Exception) { }
            } while (true);
            Console.Write("\nRegistrando. . .");
            Workbook base_excel = new Workbook("C:\\Users\\Alexis\\Desktop\\Proyectos y practicas\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            for (int fila = 2; fila <= 100; fila++)
            {
                Cell celda_cliente = hoja.Cells[$"B{fila}"];
                Cell celda_nombre = hoja.Cells[$"C{fila}"];
                Cell celda_DNI = hoja.Cells[$"D{fila}"];
                Cell celda_saldo = hoja.Cells[$"E{fila}"];
                if (celda_nombre.StringValue.Equals($"{nombre} {apellidos}") || celda_DNI.StringValue.Equals($"{DNI}"))
                {
                    Console.Write("\nUsted ya esta registrado, pruebe a iniciar sesion.");
                    nombre = "";
                    apellidos = "";
                    DNI = 0;
                    saldo = 0;
                    Console.ReadKey();
                    break;
                }
                if (string.IsNullOrEmpty(celda_cliente.StringValue))
                {
                    saldo = 1000;
                    celda_cliente.PutValue($"{fila - 1}.");
                    celda_nombre.PutValue($"{nombre} {apellidos}");
                    celda_DNI.PutValue($"{DNI}");
                    celda_saldo.PutValue($"{saldo}");
                    base_excel.Save("C:\\Users\\Alexis\\Desktop\\Proyectos y practicas\\Basededatos.xlsx");
                    Console.Clear();
                    Console.WriteLine($"BIENVENIDO {nombre} {apellidos}!\nDNI: {DNI}\n");
                    Console.Write($"Empiezas con un saldo de: {saldo:C}");
                    Console.ReadKey();
                    break;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void MostrarMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Cajero Automático:");
                if (nombre == "")
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("1. Iniciar sesion     |");
                    Console.WriteLine("2. Registrarse        |");
                    Console.WriteLine("3. Salir              |");
                }
                else
                {
                    Console.WriteLine($"BIENVENIDO {nombre} {apellidos}!\n");
                    Console.WriteLine($"Su saldo actual: {saldo:C}\n");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("1. Realizar Depósito  |");
                    Console.WriteLine("2. Retirar Dinero     |");
                    Console.WriteLine("3. Préstamo           |");
                    Console.WriteLine("4. Salir              |");
                }
                Console.WriteLine("-----------------------");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        if (nombre == "")
                            Login();
                        else
                            OpcionesBanco.RealizarDeposito();
                        break;
                    case 2:
                        if (nombre == "")
                            Registrarse();
                        else
                            OpcionesBanco.RetirarDinero();
                        break;
                    case 3:
                        if (nombre == "")
                            OpcionesBanco.Salir();
                        else
                            OpcionesBanco.Prestamos();
                        break;
                    case 4:
                        if (nombre == "")
                        {
                            Console.Write("Opción inválida. Por favor, seleccione una opción válida.");
                            Console.ReadKey();
                        }
                        else
                            OpcionesBanco.Salir();
                        break;
                    default:
                        Console.Write("Opción no válida. Por favor, seleccione una opción válida.");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}