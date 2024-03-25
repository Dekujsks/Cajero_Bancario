using System;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using ConsoleApp2;
using Aspose.Cells;
namespace Cajero_Bancario
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" BIENVENIDO AL CAJERO BANCARIO!!!*\n\n OOOOOOOOOOOOOOOOOOOOkOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOOkd:,,,;oOOx:,,,;lkOOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOxc.     cOOo.     ;dkOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOko'       cOOo.      .cxOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOo,.        cOOo.        'lkOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOkd,.          cOOo.          'lxOOOOOOOO");
            Console.WriteLine(" OOOOOxl,.            cOOo.            .cxOOOOOO");
            Console.WriteLine(" OOOd:.               cOOo.              .;okOOO");
            Console.WriteLine(" OOx,        ',.      cOOo.      ,,.       .oOOO");
            Console.WriteLine(" OOx'     .,lkd.      cOOo.      ckd:.     .oOOO");
            Console.WriteLine(" OOx'   ':dkOOd.      cOOo.      cOOOxl,.  .oOkO");
            Console.WriteLine(" OOx;':okOOOOOd.      cOOo.      cOOkOOkdc,'oOOO");
            Console.WriteLine(" OOkkkOOOOOOOOd.      cOOo.      cOOOkOOOOkxkOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.      cOOo.      cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOd.     .cOOo.     .cOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOklccccccdOOxlccccccxOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine(" OOOOOOOOkxooxkdodkkdooooddkOkxooxOkdoxkOOOOOOOO");
            Console.WriteLine(" OOOOOOOOx, .:d' .lo.     ..lx, .;kl. ,xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOk,  ;d.  co.  ,c'  'o,   cl. 'xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOx,  ;d.  co. .o0c  .o,   .,. 'xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOx,  ;d.  co.  ';.  ,d,       'xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOx,  ;d.  co.  ....;dx' .,.   'xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOk;  .,. .lo. .ckkkOOx' .lc.  'xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOo'.   .;xo. .oOOOOOx, .lk;. ,xOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOxollldkOkdodkOOOOOkdooxOxdodkOOOOOOOO");
            Console.WriteLine(" OOOOOOOOOOOOOOOOOOOOOOOOOOOOkOOkkOOOOOOOOOOOOOO");
            Console.ReadKey();
            OpcionesCliente.MostrarMenu();
        }
    }
}