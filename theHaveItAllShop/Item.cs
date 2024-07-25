using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theHaveItAllShop
{
    internal class Item
    {
        public string Category;
        public string Name;
        public string Type;
        public int Price;
        public string Make;
        public string Model;
        public Item(string category, string name, string type, int price, string make, string model)
        {
            Category = category;
            Name = name;
            Type = type;
            Price = price;
            Make = make;
            Model = model;

        }

        public Item(string category, string name, string type, int price)
        {
            Category = category;
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
