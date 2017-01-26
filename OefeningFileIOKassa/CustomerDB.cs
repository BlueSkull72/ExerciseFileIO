using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OefeningFileIOKassa
{
    internal class CustomerDB
    {
        internal static Customer CreateCustomer()
        {
            string fullName = "";
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine().Trim().ToUpper();
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine().Trim();
            fullName = lastName + " " + firstName;
            int highestNumber = 0;
            string path = @"C:\temp\data\kassa_IO_Oef\klantenbestand.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string[] contents = reader.ReadToEnd().Split('\n');
                foreach (string content in contents)
                {
                    string[] subcontent = content.Split('#');
                    for (int i = 0; i < subcontent.Length; i++)
                    {
                        int isInt = int.MinValue;
                        if (int.TryParse(subcontent[i], out isInt))
                        {
                            if (isInt > highestNumber)
                            {
                                highestNumber = isInt;
                            }
                        }
                    }
                }

                Customer customer = new Customer(fullName, highestNumber + 1);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(customer.FullName + "#" + customer.CustomerNumber);
                }
                return customer;
            }
        }
        internal static Customer ConfirmInputCustomerNumber()
        {
            int custNr = 0;
            Console.WriteLine("What is your customer number?");
            bool validNumber = false;
            validNumber = int.TryParse(Console.ReadLine().Trim(), out custNr);
            while (validNumber == false)
            {
                Console.WriteLine("Input was not a valid number.");
                Console.WriteLine("What is your customer number?");
                validNumber = int.TryParse(Console.ReadLine().Trim(), out custNr);
            }
            if (custNr != 0)
            {
                string path = @"C:\temp\data\kassa_IO_Oef\klantenbestand.txt";
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] contents = reader.ReadToEnd().Split('\n');
                    foreach (string content in contents)
                    {
                        string[] subcontent = content.Split('#');
                        for (int i = 0; i < subcontent.Length; i++)
                        {
                            int isInt = int.MinValue;
                            if (int.TryParse(subcontent[i], out isInt))
                            {
                                if (isInt == custNr)
                                {
                                    return new Customer(subcontent[i - 1], custNr);
                                }
                            }
                        }
                    }
                    Console.WriteLine("The given customer number is not registered.");
                    return null;
                }
            }
            return null;
        }
    }
}
