using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningFileIOKassa
{
    internal class Customer
    {
        internal string FullName { get; private set; }
        internal int CustomerNumber { get; private set; }
        internal Customer(string fullName, int customerNumber)
        {
            FullName = fullName;
            CustomerNumber = customerNumber;
        }
    }
}
