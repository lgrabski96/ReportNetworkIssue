using System;

namespace Shop.Model
{
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MaxSpeed { get; set; }
        public abstract decimal CalculateCost(int kmRange);
        
        public virtual void Print(int kmRange)
        {
            Console.Write($"Name:{Name}, Price:{Price}, MaxSpeed: {MaxSpeed}");
            decimal cost = CalculateCost(kmRange);
            Console.Write($" Cost: {cost}");
        }
        
        public virtual void Fill()
        {
            Console.Write("Name:");
            Name = Console.ReadLine();

            Console.Write("Price:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Price = price;
            }
            else
            {
                Console.WriteLine("Incorrect price");
            }

            Console.Write("MaxSpeed:");
            if (decimal.TryParse(Console.ReadLine(), out decimal speed))
            {
                MaxSpeed = speed;
            }
            else
            {
                Console.WriteLine("Incorrect speed value");
            }
        }
    }
}

