using System;

namespace Shop.Model
{
    public class Car : Vehicle
    {
        public int FuelLiters { get; set; }

        public override decimal CalculateCost(int kmRange)
        {
            return kmRange * FuelLiters * 6.5m;
        }

        public override void Fill()
        {
            base.Fill();

            Console.Write("FuelLiters:");
            if (int.TryParse(Console.ReadLine(), out int liters))
            {
                FuelLiters = liters;
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }
        }

        public override void Print(int kmRange)
        {
            base.Print(kmRange);
            Console.Write($" FuelLiters:{FuelLiters}");
        }
    }
}
