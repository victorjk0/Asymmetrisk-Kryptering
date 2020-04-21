using System;
using System.Collections.Generic;

namespace Encryption_Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            List<string> list = new List<string>();


            list = controller.InitKeyStrings();

            Console.WriteLine("Key Generated");
            Console.WriteLine();
            Console.WriteLine("Modulus:");
            Console.WriteLine(list[0]);
            Console.WriteLine();
            Console.WriteLine("Exponent: {0}", list[1]);

            Console.WriteLine();

            Console.Write("Message To Send: ");

            string encString = Convert.ToBase64String(controller.EncryptText(Console.ReadLine(), "KeyContainer"));

            controller.InitTcpClient(encString);
            
            //controller.DelKey();

            Console.ReadLine();
            
        }
    }
}
