using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace theHaveItAllShop
{
    internal class Shop
    {

        public List<Customer> Customers { get; set; }
        public List<Item> parts { get; set; }
        public List<Item> ShopInventory { get; set; }
        public List<Item> ShoppingList { get; set; }
        public string userChoise;
        public string userPreference = null;



        public int index = 0;
        public string input = "n";
        public string NewItemCategory;
        public string NewItemType;
        public string NewItemName;
        public string NewItemMake;
        public string NewItemModel;
        public int NewItemPrice;
        public Shop()
        {
            Customers = new List<Customer>()
            {
                new Customer("Carl", "Abc Road 13. Sem", 99958586, 6500)
            };


            ShopInventory = new List<Item>()
            {
                new Item("Carpart", "Turbo", "Engine", 200, "BMW", "M5"),
                new Item("Carpart", "Crateengine", "Engine", 3500, "BMW", "M5"),
                new Item("Carpart", "Lock", "Body", 10, "BMW", "M5"),
                new Item("Carpart", "Oilpan", "Engine", 200, "BMW", "M5"),
                new Item("Carpart", "Gasketset", "Engine", 150, "BMW", "M5"),
                new Item("Carpart", "Dor", "Body", 400, "BMW", "M5"),
                new Item("Carpart", "Window", "Body", 260, "BMW", "M5"),
                new Item("Carpart", "Seat", "Interior", 190, "BMW", "M5"),
                new Item("Carpart", "Carpet", "Interior", 20, "BMW", "M5"),
                new Item("Carpart", "Headlight", "Body", 160, "BMW", "M5"),
                new Item("Carpart", "Wheelbearing", "Suspension", 200, "BMW", "M5"),
                new Item("Carpart", "Spring", "Suspension", 170, "BMW", "M5"),
                new Item("Carpart", "Damper", "Suspension", 210, "BMW", "M5"),
                new Item("Carpart", "Breakrotor", "Breaks", 70, "BMW", "M5"),
                new Item("Carpart", "Breakpads", "Breaks", 40, "BMW", "M5"),
                new Item("Food", "Tomato", "Vegetables", 2),
                new Item("Food", "Cucumber", "Vegetables", 4),
                new Item("Food", "Bellpepper", "Vegetables", 7),
                new Item("Food", "Kale", "Vegetables", 1),
                new Item("Food", "Apple", "Fruit", 2),
                new Item("Food", "Banana", "Fruit", 2),
                new Item("Food", "Grape", "Fruit", 2),
                new Item("Food", "Mango", "Fruit", 2),
                new Item("Food", "Blackberry", "Berry", 2),
                new Item("Food", "Strawberry", "Berry", 2),
                new Item("Food", "Blueberry", "Berry", 2),
                new Item("Tool", "Socetset", "Handtool", 120),
                new Item("Tool", "Spannerset", "Handtool", 80),
                new Item("Tool", "Screwdriverset", "Handtool", 50),
                new Item("Tool", "Drill", "Powertool", 170),
                new Item("Tool", "Anglegrinder", "Powertool", 220),
                new Item("Tool", "Beltsander", "Powertool", 350),
                new Item("Tool", "Lathe", "Benchmachine", 12000),
                new Item("Tool", "CNC Plaine", "Benchmachine", 65000),
                new Item("Tool", "Benchgrinder", "Benchmachine", 120),

            };

            ShoppingList = new List<Item>() { };


        }


        public void ChoseAisle()
        {
            Console.WriteLine("1. Car Aisle");
            Console.WriteLine("2. Food Aisle");
            Console.WriteLine("3. Tools");
            Console.WriteLine("4. Add something to the store");
            Console.WriteLine("5. Remove something from the shop");
            Console.WriteLine("6. show all items in the store");
            userChoise = Console.ReadLine();

            if (userChoise == "1")
            {
                userChoise = "Carpart";
                Console.WriteLine("What carparts do you need?");
                Console.WriteLine("Engine, Body, Interior, Suspenision, Brakes");
                userPreference = Console.ReadLine();
                AisleSelector();
            }
            else if (userChoise == "2")
            {
                Console.WriteLine("What food do you need?");
                Console.WriteLine("Vegetables, Fruit, Berry");
                userPreference = Console.ReadLine();
                AisleSelector();
            }

            else if (userChoise == "3")
            {
                Console.WriteLine("What kind of tools do you need?");
                Console.WriteLine("Handtool, Benchmachine, Powertool");
                userPreference = Console.ReadLine();
                AisleSelector();
            }
            else if (userChoise == "4")
            {
                InputForNewItem();
            }

            else if (userChoise == "5")
            {
                RemoveItem();
            }
            else
            {
                userChoise = null;
                AisleSelector();
            }
        }
        public void AisleSelector()
        {


            if (userPreference != null)
            {
                parts = (List<Item>)ShopInventory.Where(item => item.Category == userChoise).ToList();
                foreach (Item part in parts)
                {
                    Console.WriteLine($"{parts.IndexOf(part)}. {part.Name} {part.Price}$");

                }
            }
            else { foreach (var item in ShopInventory) { Console.WriteLine(ShopInventory.IndexOf(item) + item.Name + " " + item.Type); } }
            Console.ReadKey();
            AddToCart();
        }



        public void InputForNewItem()
        {
            Console.WriteLine("What category do you want to add?");
            Console.WriteLine("Food, Tool or Carpart");
            NewItemCategory = Console.ReadLine();

            Console.WriteLine("What type do you want to add?");
            NewItemType = Console.ReadLine();

            Console.WriteLine("Item name:");
            NewItemName = Console.ReadLine();

            Console.WriteLine("Item price:");
            NewItemPrice = int.Parse(Console.ReadLine());

            if (NewItemCategory == "Carpart")
            {
                Console.WriteLine("What's the make of the car?");
                NewItemMake = Console.ReadLine();
                Console.WriteLine($"What's the model of{NewItemMake}?");
                NewItemModel = Console.ReadLine();
                AddNewItem();
            }
            else { AddNewItem(); }
        }
        public void AddNewItem()
        {
            if (NewItemCategory == "Carpart")
            {
                ShopInventory.Add(new Item(NewItemCategory, NewItemName, NewItemType, NewItemPrice, NewItemMake, NewItemModel));
            }
            else { ShopInventory.Add(new Item(NewItemCategory, NewItemName, NewItemType, NewItemPrice)); }
            AisleSelector();
        }


        public void RemoveItem()
        {
            ShopInventory.ForEach(x => Console.WriteLine($"{ShopInventory.IndexOf(x)}. {x.Name} {x.Price} "));
            Console.WriteLine("Write Index nr of element to remove:");
            index = int.Parse(Console.ReadLine());


            ShopInventory.RemoveAt(index);
            Console.WriteLine();
            Console.WriteLine("New list:");
            foreach (Item item in ShopInventory) { Console.WriteLine(item.Name); }
            Console.ReadKey();

        }



        public void AddToCart()
        {
            Console.WriteLine("Write index of item you want to buy");
            index = int.Parse(Console.ReadLine());
            if (userPreference != null)
            {

                for (int i = 0; i < parts.Count; i++)
                {
                    if (i == index) { ShoppingList.Add(parts[i]); }
                }
            }

            else
            {
                foreach (Item item in ShopInventory)
                {
                    if (ShopInventory.IndexOf(item) == index) { ShoppingList.Add(item); }
                }
            }

            foreach (Item item in ShoppingList) { Console.WriteLine(item.Name + " " + item.Price); }
            Console.WriteLine("1. to check out, 2 to shop more");
            string user = Console.ReadLine();
            if (user == "2")
            {
                AisleSelector();
            }
            else { Console.WriteLine(CheckOut());
                Console.ReadKey();
                ChoseAisle();
            }
            user = null;
        }


        public decimal CheckOut()
        {
            decimal TotalCost = 0;
            foreach (Item item in ShoppingList)
            {
                TotalCost += item.Price;
            }
            ShoppingList.Clear();

            return TotalCost;
        }


        public void Customer() 
        { 
            
        }
     

        }
        
    }

