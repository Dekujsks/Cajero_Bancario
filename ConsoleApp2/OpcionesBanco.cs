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
    internal class OpcionesBanco
    {
        public static void ConsultarSaldo()
        {
            Console.WriteLine("****SALDO ACTUAL****");
            Console.WriteLine($"{OpcionesCliente.saldo}");
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void RetirarDinero()
        {
            Console.WriteLine("****RETIRO****");
            Console.Write("Ingrese la cantidad a retirar: ");
            decimal cantidadARetirar = Convert.ToDecimal(Console.ReadLine());
            if (cantidadARetirar > (decimal)OpcionesCliente.saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
            else
            {
                OpcionesCliente.saldo -= (double)cantidadARetirar;
                Console.WriteLine($"Retiro exitoso! Saldo restante: S/. {OpcionesCliente.saldo}");
            }
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void RealizarDeposito()
        {
            Console.WriteLine("****DEPOSITO****");
            Console.Write("Ingrese la cantidad a depositar: ");
            decimal cantidadADepositar = Convert.ToDecimal(Console.ReadLine());
            if (cantidadADepositar > 0)
            {
                OpcionesCliente.saldo += (double)cantidadADepositar;
                Console.WriteLine($"{OpcionesCliente.nombre} ha depositado {cantidadADepositar:C} Nuevo saldo: {OpcionesCliente.saldo:C}");
            }
            else
                Console.WriteLine("La cantidad a depositar debe ser mayor que cero.");
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Prestamos()
        {
            Console.WriteLine("****PRESTAMOS****");
            int cuotas;
            double montoPrestamo, tasaInteresMensual, tasaInteresAnual;
            Console.WriteLine("¿Cuánto dinero necesita para el préstamo?");
            montoPrestamo = Convert.ToDouble(Console.ReadLine());
            Console.Write("¿En cuántas cuotas lo desea?: ");
            cuotas = Convert.ToInt32(Console.ReadLine());
            if (OpcionesCliente.saldo < 1000)
                tasaInteresAnual = 4;
            else
                tasaInteresAnual = 10;
            tasaInteresMensual = tasaInteresAnual / 12 / 100;
            for (int i = 1; i <= cuotas; i++)
            {
                double interesCuota = montoPrestamo * tasaInteresMensual;
                OpcionesCliente.saldo += (double)interesCuota;

                Console.WriteLine($"Cuota: {i}\nMonto: {montoPrestamo:C}\nInterés: {interesCuota:C}\nTotal pagado: {OpcionesCliente.saldo:C}");

                if (i % 3 == 0)
                {
                    tasaInteresAnual += tasaInteresMensual;
                    tasaInteresMensual = tasaInteresAnual / 12 / 100;
                }
            }
            if (OpcionesCliente.saldo < 1000)
                Console.WriteLine("\nDebido a su situacion economica actual se redujo la tasa de interes a un 4%");
            Console.WriteLine("\nTasa de interes: 10%");
            Console.Write($"Total pagado al final del préstamo: {(double)montoPrestamo + OpcionesCliente.saldo:C}");
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void Salir()
        {
            Workbook base_excel = new Workbook("Basededatos.xlsx");
            Worksheet hoja = base_excel.Worksheets[0];
            for (int n = 2; n <= 100; n++)
            {
                Cell nombre = hoja.Cells[$"C{n}"];
                Cell dni = hoja.Cells[$"D{n}"];
                if (nombre.StringValue == $"{OpcionesCliente.nombre} {OpcionesCliente.apellidos}" || dni.StringValue == $"{OpcionesCliente.DNI}")
                {
                    Cell celda_saldo = hoja.Cells[$"E{n}"];
                    celda_saldo.PutValue(OpcionesCliente.saldo);
                    break;
                }
            }
            Console.WriteLine("****SALIDA****");
            Console.Write("¿Quiere cerrar sesion o quiere cerrar la caja? (s: sesion/c: caja): ");
            char resp;
            if (char.TryParse(Console.ReadLine(), out resp))

                switch (resp)
                {
                    case 's':
                        if (OpcionesCliente.nombre == "" && OpcionesCliente.apellidos == "" && OpcionesCliente.DNI == 0)
                        {
                            Console.Write("Usted nunca se registro ni inicio sesion\n\nRetornando..."); 
                            Console.ReadKey();
                        }
                        else
                        {
                            base_excel.Save("Basededatos.xlsx");
                            OpcionesCliente.nombre = "";
                            OpcionesCliente.apellidos = "";
                            OpcionesCliente.DNI = 0;
                        }
                        break;
                    case 'c':
                        if (OpcionesCliente.nombre == "" && OpcionesCliente.apellidos == "" && OpcionesCliente.DNI == 0)
                        {
                            Console.WriteLine($"Nos vemos individuo, tenga buen día.");
                        }
                        else 
                            Console.WriteLine($"Nos vemos {OpcionesCliente.nombre}, tenga buen día.");
                        base_excel.Save("Basededatos.xlsx");
                        Environment.Exit(0);
                        break;
                }
        }
    }
}