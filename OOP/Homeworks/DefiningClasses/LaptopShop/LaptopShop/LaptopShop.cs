using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private double ram;
        private string graphicsCard;
        private double hdd;
        private string screen;
        private Battery battery;
        private decimal price;
        public string Model 
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty!");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer cannot be empty!");
                }
                this.manufacturer = value;
            }
        }
        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Processor cannot be empty!");
                }
                this.processor = value;
            }
        }
        public double Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("RAM must be a positive number!");
                }
                this.ram = value;
            }
        }
        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Graphics Card cannot be empty!");
                }
                this.graphicsCard = value;
            }
        }
        public double Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HDD must be a positive number!");
                }
                this.hdd = value;
            }
        }
        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Screen cannot be empty!");
                }
                this.screen = value;
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
        public Laptop(string model, string manufacturer, string processor, double ram, string graphicsCard, double hdd, string screen,
            string batteryType, double batteryLife, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.battery = new Battery(batteryType, batteryLife);
            this.Price = price;
        }
        public Laptop(string model, string manufacturer, string processor, double ram, string graphicsCard, double hdd, string screen,
            string batteryType, decimal price)
            : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, batteryType, 0, price)
        {
        }
        public override string ToString()
        {
            if (this.manufacturer != null && this.battery.BatteryType != null && this.battery.BatteryLife != 0)
            {
                return String.Format("Model: {0}; Manufacturer: {1}; Processor: {2}; RAM: {3} GB; Graphics Card: {4}; HDD: {5}GB SSD; " +
                    "Screen: {6}; Battery Type: {7}; Battery Life: {8} hours; Price: {9} lv.", this.model, this.manufacturer, this.processor,
                    this.ram, this.graphicsCard, this.hdd, this.screen, this.battery.BatteryType, this.battery.BatteryLife, this.price);
            }
            else if (this.manufacturer != null && this.battery.BatteryType != null && this.battery.BatteryLife == 0)
            {
                return String.Format("Model: {0}; Manufacturer: {1}; Processor: {2}; RAM: {3} GB; Graphics Card: {4}; HDD: {5}GB SSD; " +
                    "Screen: {6}; Battery Type: {7}; Price: {8} lv.", this.model, this.manufacturer, this.processor,
                    this.ram, this.graphicsCard, this.hdd, this.screen, this.battery.BatteryType, this.price);
            }
            return "";
        }
    }
    class Battery
    {
        private string batteryType;
        private double batteryLife;
        public string BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Battery Type cannot be empty!");
                }
                this.batteryType = value;
            }
        }
        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery Life must be a positive number!");
                }
                this.batteryLife = value;
            }
        }
        public Battery(string batteryType, double batteryLife)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }
        public Battery(string batteryType)
            : this(batteryType, 0)
        {
        }
    }
}
