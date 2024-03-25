using System;
using System.Text.RegularExpressions;
using Aspose.Cells;
using DocumentFormat.OpenXml.Drawing;
using SpreadsheetLight;
namespace ConsoleApp2
{
    internal class OpcionesCliente
    {
        public static double saldo = 0;
        public static double saldoAnterior = 0;
        public static double saldoRetirado = 0;
        public static string? nombre = "";
        public static string? apellidos = "";
        public static int DNI = 0;
        public static int clientes;
        public static int clave = 0;
        //-------------------------------------------------------------------------------------------------------------
        public static void Login()
        {
            Console.WriteLine("《 Inicio de sesión 》");
            Workbook base_excel = new Workbook("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            Regex regex = new(@"\d");
            string? na = "", ap = "";
            int dni = 0, cl = 0;
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
                        Console.Write("Ingrese su clave (6 digitos): ");
                        cl = Convert.ToInt32(Console.ReadLine());
                        int cantidad = Math.Abs(cl).ToString().Length;
                        if (cantidad != 6)
                            Console.WriteLine("Usted debe ingresar una clave de 6 digitos");
                        else
                        {
                            for (int n = 2; n <= 100; n++)
                            {
                                Cell celda_dni = hoja.Cells[$"D{n}"], celda_clave = hoja.Cells[$"E{n}"];
                                if (celda_dni.StringValue == $"{dni}" && celda_clave.StringValue == $"{cl}")
                                {
                                    DNI = dni;
                                    clave = cl;
                                    Cell celda_saldo = hoja.Cells[$"F{n}"];
                                    saldo = celda_saldo.DoubleValue;
                                    saldoAnterior = saldo;
                                    break;
                                }
                            }
                        }
                        if (DNI == 0 || clave == 0)
                            Console.WriteLine("Datos incorrectos, porfavor intentelo de nuevo");
                    } while (DNI == 0 || clave == 0);
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
                    Console.Write("Ingrese su clave (6 digitos): ");
                    cl = Convert.ToInt32(Console.ReadLine());
                    int cantidad = Math.Abs(cl).ToString().Length;
                    if (cantidad != 6)
                        Console.WriteLine("Usted debe ingresar una clave de 6 digitos");
                    else
                    {
                        for (int n = 2; n <= 100; n++)
                        {
                            Cell celda_dni = hoja.Cells[$"D{n}"], celda_clave = hoja.Cells[$"E{n}"];
                            if (celda_dni.StringValue == $"{dni}" && celda_clave.StringValue == $"{cl}")
                            {
                                DNI = dni;
                                clave = cl;
                                Cell celda_saldo = hoja.Cells[$"F{n}"];
                                saldo = celda_saldo.DoubleValue;
                                saldoAnterior = saldo;
                                break;
                            }
                        }
                    }
                    if (DNI == 0 || clave == 0)
                        Console.WriteLine("Datos incorrectos, porfavor intentelo de nuevo");
                } while (DNI == 0 || clave == 0);
                Console.Clear();
                Console.WriteLine("Inicio de sesion completada!");
                Console.ReadKey();
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Registrarse()
        {
            string nom, ap, cl;
            Regex regex = new(@"\d");
            Console.WriteLine("《 Registro 》");
            do
            {
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine();
                if (regex.IsMatch(nombre))
                    Console.WriteLine("El texto contiene números, intente con decirme su nombre de verdad");
            } while (regex.IsMatch(nombre));
            Console.WriteLine();
            do
            {
                Console.Write("Ingrese su apellido: ");
                apellidos = Console.ReadLine();
                if (regex.IsMatch(apellidos))
                    Console.WriteLine("El texto contiene números, intente con decirme su apellido de verdad");
            } while (regex.IsMatch(apellidos));
            Console.WriteLine();
            do
            {
                try
                {
                    Console.Write("Ingrese su DNI: ");
                    if (int.TryParse(Console.ReadLine(), out DNI)) {}
                    else
                        Console.WriteLine("Parece que no ingresaste un número válido, inténtalo de nuevo");
                }
                catch (Exception) { }
                string cantidad = DNI.ToString();
                int cantidad_digitos = cantidad.Length;
                if (cantidad_digitos == 8)
                    break;
                else
                    Console.WriteLine("Usted tiene que ingresar 8 digitos");
            } while (true);
            Console.WriteLine();
            do
            {
                Console.Write("Ingrese su clave (6 digitos): ");
                clave = Convert.ToInt32(Console.ReadLine());
                int cantidad = Math.Abs(clave).ToString().Length;
                if (cantidad == 6)
                    break;
                else
                    Console.WriteLine("Usted debe ingresar una clave de 6 digitos, intentelo de nuevo.");
            } while (true);
            Console.WriteLine();
            Console.Write("\nRegistrando. . .");
            Workbook base_excel = new Workbook("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            for (int fila = 2; fila <= 100; fila++)
            {
                Cell celda_cliente = hoja.Cells[$"B{fila}"];
                Cell celda_nombre = hoja.Cells[$"C{fila}"];
                Cell celda_DNI = hoja.Cells[$"D{fila}"];
                Cell celda_clave = hoja.Cells[$"E{fila}"];
                Cell celda_saldo = hoja.Cells[$"F{fila}"];
                if (celda_nombre.StringValue.Equals($"{nombre} {apellidos}") || celda_DNI.StringValue.Equals($"{DNI}"))
                {
                    Console.Write("\nUsted ya esta registrado, pruebe a iniciar sesion.");
                    nombre = ""; apellidos = ""; DNI = 0; saldo = 0; clave = 0;
                    Console.ReadKey();
                    break;
                }
                if (string.IsNullOrEmpty(celda_cliente.StringValue))
                {
                    saldo = 1000;
                    saldoAnterior = saldo;
                    celda_cliente.PutValue($"{fila - 1}.");
                    celda_nombre.PutValue($"{nombre} {apellidos}");
                    celda_DNI.PutValue($"{DNI}");
                    celda_clave.PutValue(clave);
                    celda_saldo.PutValue(saldo);
                    base_excel.Save("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
                    base_excel.Worksheets.RemoveAt(1);
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("《  Cajero Automático  》\n");
                if (nombre == "")
                {
                    Console.WriteLine("╔═════════════════════════╗");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 1. Iniciar sesión     ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 2. Registrarse        ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 3. Salir              ║");
                }
                else
                {
                    Console.WriteLine($"BIENVENIDO {nombre} {apellidos}!\n");
                    Console.WriteLine($"Su saldo actual: {saldo:C}\n");
                    Console.WriteLine("╔═════════════════════════╗");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 1. Realizar Depósito  ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 2. Retirar Dinero     ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 3. Préstamo           ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 4. Boucher            ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 5. Transferencia      ║");
                    Console.WriteLine("║                         ║");
                    Console.WriteLine("║ ► 6. Salir              ║");
                }
                Console.WriteLine("║                         ║");
                Console.WriteLine("╚═════════════════════════╝");
                Console.Write("\nSeleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
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
                            OpcionesBanco.Boucher();
                        break;
                    case 5:
                        OpcionesBanco.Transferencia();
                        break;
                    case 6:
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