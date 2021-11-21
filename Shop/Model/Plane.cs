using System;

namespace Shop.Model
{
    public class Plane : Vehicle
    {
        public int JetFuelLiters { get; set; }

        public override decimal CalculateCost(int kmRange)
        {
            return kmRange * JetFuelLiters * 80.5m;
        }

        public override void Fill()
        {
            base.Fill();

            Console.Write("JetFuelLiters:");
            if (int.TryParse(Console.ReadLine(), out int liters))
            {
                JetFuelLiters = liters;
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }
        }

        public override void Print(int kmRange)
        {
            base.Print(kmRange);
            Console.Write($" JetFuelLiters:{JetFuelLiters}");
        }
    }
}
