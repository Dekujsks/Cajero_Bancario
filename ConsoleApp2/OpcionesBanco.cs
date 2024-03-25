using System;
using Aspose.Cells;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class OpcionesBanco : OpcionesCliente
    {
        public static void Boucher()
        {
            Console.ForegroundColor = ConsoleColor.White;
            DateTime horaActual = DateTime.Now;
            Console.WriteLine("**************************************************");
            Console.WriteLine("               BOLETA DE BANCO                   ");
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Nombre del Cliente: {nombre}");
            Console.WriteLine($"DOCUMENTO: D. N. I. {DNI}");
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Fecha:              {horaActual.ToString("yyyy-MM-dd")}          Hora: {horaActual.ToString("HH:mm:ss")}");
            Console.WriteLine($"Monto:              {saldo:C}");
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine($"Saldo Anterior:     {saldoAnterior:C}");
            Console.WriteLine($"Monto Retirado:     {saldoRetirado:C}\n");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Nuevo Saldo:        {saldo:C}");
            Console.Write("Verifique su dinero antes de retirarse."); Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void RetirarDinero()
        {
            Console.WriteLine("《 Retiro 》");
            Console.Write("Ingrese la cantidad a retirar: ");
            double cantidadARetirar = Convert.ToDouble(Console.ReadLine());
            if (cantidadARetirar > saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
            else
            {
                saldo -= cantidadARetirar;
                saldoRetirado += cantidadARetirar;
                Console.WriteLine($"Retiro exitoso! Saldo restante: S/. {saldo}");
            }
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void RealizarDeposito()
        {
            Console.WriteLine("《 Depósito 》");
            Console.Write("Ingrese la cantidad a depositar: ");
            decimal cantidadADepositar = Convert.ToDecimal(Console.ReadLine());
            if (cantidadADepositar > 100)
            {
                saldo += (double)cantidadADepositar;
                Console.WriteLine($"{nombre} ha depositado {cantidadADepositar:C} Nuevo saldo: {saldo:C}");
            }
            else
                Console.WriteLine("La cantidad a depositar debe ser mayor que S/. 100.");
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Transferencia()
        {
            Console.WriteLine("《 Transferencia 》");
            bool s = false;
            Console.Write("Ingrese el nombre del usuario: "); string? nom_trans = Console.ReadLine();
            Console.Write("Ingrese el apellido del usuario: "); string? ap_trans = Console.ReadLine();
            Console.Write("Ingrese el DNI del usuario: "); string? dni_trans = Console.ReadLine();
            Workbook base_excel = new Workbook("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            for (int i = 2; i < 100; i++)
            {
                char? resp = null;
                Cell nomap = hoja.Cells[$"C{i}"], dni = hoja.Cells[$"D{i}"];
                if (nomap.StringValue != "" && dni.StringValue != "")
                {
                    if (nomap.StringValue == $"{nom_trans} {ap_trans}" && dni.StringValue == $"{dni_trans}")
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"《 Usuario encontrado : {nom_trans} {ap_trans} 》");
                            Console.WriteLine($"Saldo actual (Tú): {saldo:C}\n");
                            Console.Write("Ingrese la cantidad a transferir: "); double trans = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            if (trans > saldo)
                            {
                                Console.Write("Saldo insuficiente"); Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"**Saldo posterior a la transaccion: {saldo - trans:C}**");
                                Console.Write($"¿Esta seguro que desea transferir {trans:C} al usuario {nom_trans} {ap_trans}? (s/n): ");
                                resp = Convert.ToChar(Console.ReadLine());
                                if (resp == 's')
                                {
                                    saldo = saldo - trans;
                                    Cell saldo_trans = hoja.Cells[$"F{i}"];
                                    saldo_trans.PutValue(saldo_trans.DoubleValue + trans);
                                    base_excel.Save("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
                                    Console.Write("Transferencia satisfactoria!");
                                    Console.ReadKey();
                                    break;
                                }
                                else if (resp == 'n')
                                {
                                    Console.Write("Retornando. . .");
                                    Console.ReadKey();
                                }
                            }
                        } while (resp != 's');
                        if (resp == 's')
                        {
                            s = true;
                            break;
                        }
                    }
                }
            }
            if (s) {}
            else
            {
                Console.WriteLine("Usuario no identificado.");
                Console.ReadKey();
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Prestamos()
        {
            Console.WriteLine("《 Préstamo 》");
            int cuotas;
            double montoPrestamo, tasaInteresMensual, tasaInteresAnual;
            Console.WriteLine("¿Cuánto dinero necesita para el préstamo?");
            montoPrestamo = Convert.ToDouble(Console.ReadLine());
            Console.Write("¿En cuántas cuotas lo desea?: ");
            cuotas = Convert.ToInt32(Console.ReadLine());
            if (saldo < 1000)
                tasaInteresAnual = 4;
            else
                tasaInteresAnual = 10;
            tasaInteresMensual = tasaInteresAnual / 12 / 100;
            for (int i = 1; i <= cuotas; i++)
            {
                double interesCuota = montoPrestamo * tasaInteresMensual;
                saldo += (double)interesCuota;

                Console.WriteLine($"Cuota: {i}\nMonto: {montoPrestamo:C}\nInterés: {interesCuota:C}\nTotal pagado: {saldo:C}");

                if (i % 3 == 0)
                {
                    tasaInteresAnual += tasaInteresMensual;
                    tasaInteresMensual = tasaInteresAnual / 12 / 100;
                }
            }
            if (saldo < 1000)
                Console.WriteLine("\nDebido a su situacion economica actual se redujo la tasa de interes a un 4%");
            Console.WriteLine("\nTasa de interes: 10%");
            Console.Write($"Total pagado al final del préstamo: {(double)montoPrestamo + saldo:C}");
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Salir()
        {
            Console.WriteLine("《 Salida 》");
            Workbook base_excel = new Workbook("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            for (int n = 2; n <= 100; n++)
            {
                Cell nom = hoja.Cells[$"C{n}"], dni = hoja.Cells[$"D{n}"], cl = hoja.Cells[$"E{n}"];
                if (nom.StringValue == $"{nombre} {apellidos}" && dni.StringValue == $"{DNI}" && cl.StringValue == $"{clave}")
                {
                    Cell celda_saldo = hoja.Cells[$"F{n}"];
                    celda_saldo.PutValue(saldo);
                    break;
                }
            }
            base_excel.Save("C:\\Users\\LESLIE\\Downloads\\Proyectos y practicas\\Proyectos y practicas\\ConsoleApp2\\Basededatos.xlsx");
            nombre = ""; apellidos = ""; DNI = 0; saldo = 0; clave = 0;
            saldoAnterior = 0; saldoRetirado = 0;
            Console.Write("¿Quiere cerrar sesion o quiere cerrar la caja? (s: sesion/c: caja): ");
            char resp;
            if (char.TryParse(Console.ReadLine(), out resp))
                switch (resp)
                {
                    case 's':
                        if (nombre == "" && apellidos == "" && DNI == 0)
                        {
                            Console.Write("Usted nunca se registro ni inicio sesion\n\nRetornando..."); 
                            Console.ReadKey();
                        }
                        else {}
                        break;
                    case 'c':
                        if (nombre == "" && apellidos == "" && DNI == 0)
                        {
                            Console.WriteLine($"Nos vemos individuo, tenga buen día.");
                        }
                        else 
                            Console.WriteLine($"Nos vemos {nombre}, tenga buen día.");
                        Environment.Exit(0);
                        break;
                }
        }
    }
}