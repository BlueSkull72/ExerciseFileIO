using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OefeningFileIOKassa
{
    class Program
    {
        static void Main(string[] args)
        {
            RunInit();
            Choicescreen();
            Console.ReadKey();
        }

        private static void RunInit()
        {
            string baseTargetFolder = @"C:\temp\data\kassa_IO_Oef";
            if (File.Exists(Path.Combine(baseTargetFolder, "allekastickets.txt")) == false)
            {
                File.Create(Path.Combine(baseTargetFolder, "allekastickets.txt"));
            }
            if (File.Exists(Path.Combine(baseTargetFolder, "totaalsom.txt")) == false)
            {
                File.Create(Path.Combine(baseTargetFolder, "totaalsom.txt"));
            }
            if (File.Exists(Path.Combine(baseTargetFolder, "klantenbestand.txt")) == false)
            {
                File.Create(Path.Combine(baseTargetFolder, "klantenbestand.txt"));
            }
        }

        private static void Choicescreen()
        {
            Customer user = null;
            bool waitingForInput = true;
            while (waitingForInput)
            {
                Console.WriteLine("Do you have a customer card? Y(es)/N(o)");
                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "y":
                    case "yes":
                        waitingForInput = false;
                        user = CustomerDB.ConfirmInputCustomerNumber();
                        break;
                    case "n":
                    case "no":
                        waitingForInput = false;
                        user = CustomerDB.CreateCustomer();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            if (user != null)
            {
                Articles.CreateArticle(user);
            }
        }
    }
}
