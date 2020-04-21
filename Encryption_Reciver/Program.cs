using System;
using System.Text;

namespace Encryption_Reciver
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            Console.Write("Waiting for encrypted Message...");

            string uinput = controller.InitTcpServer();

            Console.Clear();

            Console.WriteLine("Encrypted Message:");

            Console.WriteLine();

            Console.WriteLine(uinput);

            Console.WriteLine();

            Console.WriteLine(Encoding.Default.GetString(controller.DecryptText(uinput)));

            Console.ReadKey();
        }
    }
}
