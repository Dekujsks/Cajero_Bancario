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
                Console.WriteLine("Saldo insuficiente.");
            else
            {
                Console.WriteLine("Retirando. . .");
                for (int r = 0; r <= 10; r++)
                {
                    string barraCarga = GetBarraCarga(r, 10);
                    Console.Write($"\r[{barraCarga}] {r * 10}%");
                    Thread.Sleep(450);
                }
                Console.WriteLine();
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
                Console.WriteLine("Depositando. . .");
                for (int i = 0; i <= 10; i++)
                {
                    string barraCarga = GetBarraCarga(i, 10);
                    Console.Write($"\r[{barraCarga}] {i * 10}%");
                    Thread.Sleep(200);
                }
                Console.WriteLine();
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
            Workbook base_excel = new Workbook("C:\\Users\\[NombredeEquipo]\\Desktop\\Cajero_Bancario\\Basededatos.xlsx");
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
                                    base_excel.Save("C:\\Users\\[NombredeEquipo]\\Desktop\\Cajero_Bancario\\Basededatos.xlsx");
                                    Console.WriteLine("Transfiriendo. . .");
                                    for (int t = 0; t <= 10; t++)
                                    {
                                        string barraCarga = GetBarraCarga(t, 10);
                                        Console.Write($"\r[{barraCarga}] {t * 10}%");
                                        Thread.Sleep(300);
                                    }
                                    Console.WriteLine();
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
            Console.WriteLine("Realizando prestamo...");
            for (int p = 0; p <= 10; p++)
            {
                string barraCarga = GetBarraCarga(p, 10);
                Console.Write($"\r[{barraCarga}] {p * 10}%");
                Thread.Sleep(400);
            }
            Console.WriteLine();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo olvide ser responsable con sus pagos, gracias :)");
            Console.ForegroundColor = ConsoleColor.Green;
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
            Workbook base_excel = new Workbook("C:\\Users\\[NombredeEquipo]\\Desktop\\Cajero_Bancario\\Basededatos.xlsx");
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
                        else {
                            Console.WriteLine("Guardando cambios...");
                            for (int s = 0; s <= 10; s++)
                            {
                                string barraCarga = GetBarraCarga(s, 10);
                                Console.Write($"\r[{barraCarga}] {s * 10}%");
                                Thread.Sleep(50);
                            }
                            base_excel.Save("C:\\Users\\[NombredeEquipo]\\Desktop\\Cajero_Bancario\\Basededatos.xlsx");
                            Console.WriteLine();
                            nombre = ""; apellidos = ""; DNI = 0; saldo = 0; clave = 0;
                            saldoAnterior = 0; saldoRetirado = 0;
                        }
                        break;
                    case 'c':
                        if (nombre == "" && apellidos == "" && DNI == 0)
                        {
                            Console.WriteLine($"Nos vemos individuo, tenga buen día.");
                        }
                        else
                        {
                            base_excel.Save("C:\\Users\\[NombredeEquipo]\\Desktop\\Cajero_Bancario\\Basededatos.xlsx");
                            Console.WriteLine($"Nos vemos {nombre}, tenga buen día.");
                        }
                            
                        Environment.Exit(0);
                        break;
                }
        }
    }
}