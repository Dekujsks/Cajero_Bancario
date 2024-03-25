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
            Console.WriteLine(" BIENVENIDO AL CAJERO BANCARIO!!!*\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
        MMMMMMMMMMMMWXK0Okkkkkdd0NWWMMMMMMMMMMMM
        MMMMMMMMWN0kdloOOkkkkxo;:ldxx0NWMMMMMMMM
        MMMMMMWKkocclcd0kdddddl;;ccc,':dKWMMMMMM
        MMMMWXxlcccllcokxdddddl::cccc,..,dKWMMMM
        MMMW0occcclcccccccccccccccccc:'...:OWMMM
        MMWOlccccccccclddddddoc:cccccc,....,kWMM
        MW0lclclccccccxKOkkkkdc;:lcccc;.....;0MM
        MXdclcclccccclOKkkkkkd:;:ccclc;......oNM
        M0lcccccllccclk0xddddo:;:ccccc;......;0M
        Wkcclcccccccccoddooool::ccccc:,......,OM
        Nxcccc:lk0KOxlcccccccccldOKKOxc'.....,kM
        Xdcc:;dNMMMMWXklcccccco0WMMMMMNO:.....lK
        x::c,oNMMMMMMMW0occloxXMMMMMMMMM0:....,l
        l:c;'oNMMMMMMMMW0olkXNMMMMMMMMMMKc..'oxd
        k0d,.;0MMMMMMMMMW00NMMMMMMMMMMMWx'..cXXK
        KNKc..xWMMMMMMMMMMMMMMMMMMMMMMMK:..,OWXX
        XKNk,.lNMMMMMMMMMMMMMMMMMMMMMMMk,.'o00KW
        WXOko'cXMMMMMMMMMMMMMMMMMMMMMMWd,.':oOWM
        MWXxl;cKMMMMMMMMMMMMMMMMMMMMMMKc';lxKWMM
        MMMWX00NMMMMMMMMMMMMMMMMMMMMMMKxkKWMMMMM");
            Console.ReadKey();
            OpcionesCliente.MostrarMenu();
        }
        public static string GetBarraCarga(int completado, int total)
        {
            int numBarras = 10;
            int completadoBarras = (int)Math.Floor((double)completado / total * numBarras);
            int restantesBarras = numBarras - completadoBarras;
            return new string('▓', completadoBarras) + new string('-', restantesBarras);
        }
    }
}