using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCCatalog
{
    class Computer
    {
        private string name;
        private Component processor;
        private Component graphicsCard;
        private Component motherboard;
        private decimal price;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }
                this.price = value;
            }
        }
        public Computer(string name, string processorName, string graphicsCardName, string motherboardName, string processorDetails,
            string graphicsCardDetails, string motherboardDetails, decimal processorPrice, decimal graphicsCardPrice,
            decimal motherboardPrice, decimal price)
        {
            this.Name = name;
            this.processor = new Component(processorName, processorDetails, processorPrice);
            this.graphicsCard = new Component(graphicsCardName, graphicsCardDetails, graphicsCardPrice);
            this.motherboard = new Component(motherboardName, motherboardDetails, motherboardPrice);
            this.Price = price;
        }
        public Computer(string name, string processorName, string graphicsCardName, string motherboardName, decimal processorPrice,
            decimal graphicsCardPrice, decimal motherboardPrice, decimal price)
            : this(name, processorName, graphicsCardName, motherboardName, null, null, null, processorPrice, graphicsCardPrice,
            motherboardPrice, price)
        {
        }
        public override string ToString()
        {
            decimal totalPrice = this.processor.Price + this.graphicsCard.Price + this.motherboard.Price;
            if (this.processor.Details != null)
            {
                return String.Format("Name: {0}; Processor Name: {1}; Graphics Card Name: {2}; Motherboard Name: {3}; " +
                    "Processor Details: {4}; Graphics Card Details: {5}; Motherboard Details: {6}; Processor Price: {7} lv; " +
                    "Graphics Card Price: {8} lv; Motherboard Price: {9} lv; Total Price: {10} lv", this.name, this.processor.Name,
                    this.graphicsCard.Name, this.motherboard.Name, this.processor.Details, this.graphicsCard.Details,
                    this.motherboard.Details, this.processor.Price, this.graphicsCard.Price, this.motherboard.Price, totalPrice);
            }
            else
            {
                return String.Format("Name: {0}; Processor Name: {1}; Graphics Card Name: {2}; Motherboard Name: {3}; " +
                    "Processor Price: {4} lv; Graphics Card Price: {5} lv; Motherboard Price: {6} lv; Total Price: {7} lv", this.name,
                    this.processor.Name, this.graphicsCard.Name, this.motherboard.Name, this.processor.Price, this.graphicsCard.Price,
                    this.motherboard.Price, totalPrice);
            }
        }
    }
    class Component
    {
        private string name;
        private string details;
        private decimal price;
        public string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }
                this.price = value;
            }
        }
        public Component(string name, string details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }
        public Component(string name, decimal price)
            : this(name, null, price)
        {
        }
    }
    class ComputerTest
    {
        static void Main()
        {
            Computer lenovo = new Computer("Lenovo", "a", "b", "c", "d", "e", "f", 2.39m, 3.15m, 6.20m, 9.20m);
            Computer asus = new Computer("Asus", "g", "h", "i", 3.65m, 2.56m, 5.33m, 9.18m);
            Computer toshiba = new Computer("Toshiba", "j", "k", "l", 2.38m, 5.16m, 3.22m, 10.55m);
            List<Computer> computers = new List<Computer>();
            computers.Add(lenovo);
            computers.Add(asus);
            computers.Add(toshiba);
            List<Computer> sortedComputers = computers.OrderBy(computer => computer.Price).ToList();
            foreach (Computer computer in sortedComputers)
                Console.WriteLine(computer);
        }
    }
}
