using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OefeningFileIOKassa
{
    internal class Articles
    {
        internal static void CreateArticle(Customer customer)
        {
            string pathAllTickets = @"C:\temp\data\kassa_IO_Oef\allekastickets.txt";
            bool exit = false;
            double totalcost = 0;
            List<string> output = new List<string>();
            output.Add(customer.FullName + "\t" + customer.CustomerNumber);
            while (exit == false)
            {
                Console.WriteLine("Input name of requested article: ");
                string product = Console.ReadLine().Trim();
                double price = double.MinValue;
                Console.WriteLine("What is the price of this product? ");
                while (double.TryParse(Console.ReadLine().Trim(), out price) == false)
                {
                    Console.Clear();
                    Console.WriteLine("Input was not a number.");
                    Console.WriteLine("What is the price of this product? ");
                }
                totalcost += price;
                Console.Clear();
                output.Add(product + "\t" + price.ToString());
                Console.WriteLine("Product registered, press Q to exit, or any other sequence to continue.");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    exit = true;
                }
            }
            output.Add(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "\t" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString());
            foreach (string outputString in output)
            {
                Console.WriteLine(outputString);
            }
            using (StreamWriter writer = new StreamWriter(pathAllTickets, true))
            {
                writer.WriteLine("#");
                foreach (string outputString in output)
                {
                    writer.WriteLine(outputString);
                }
            }

            string pathTotalSum = @"C:\temp\data\kassa_IO_Oef\totaalsom.txt";
            double currentTotal = double.MinValue;
            using (StreamReader reader = new StreamReader(pathTotalSum))
            {
                try
                {
                    if (double.TryParse(reader.ReadLine().Trim(), out currentTotal) == false)
                    {
                        currentTotal = 0;
                    }
                }
                catch (NullReferenceException)
                {
                    currentTotal = 0;
                }
                currentTotal += totalcost;
            }
            using (StreamWriter writer = new StreamWriter(pathTotalSum))
            {
                writer.Write(currentTotal);
            }
        }
    }
}
