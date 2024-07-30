using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theHaveItAllShop
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phonenumber { get; set; }
        public decimal Balance { get; set; }

        public Customer(string name, string address, int phonenumber, decimal balance)
        {
            Name = name;
            Address = address;
            Phonenumber = phonenumber;
            Balance = balance;
        }
    }
}
