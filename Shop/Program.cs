using System;

namespace Shop
{
    public class Program
    {
        public static void Main()
        {
            Fleet fleet = new Fleet();
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select command:");
                Console.WriteLine(" 1) Add vehicle");
                Console.WriteLine(" 2) Clear fleet");
                Console.WriteLine(" 3) Show fleet with costs");
                Console.WriteLine(" 0) Exit");

                string commandText = Console.ReadLine();

                if (!int.TryParse(commandText, out int command))
                {
                    Console.WriteLine("Incorrent command. Try again!");
                    continue;
                }

                Console.WriteLine();

                switch(command)
                {
                    case 1:
                        fleet.AddVehicle();
                        break;
                    case 2:
                        fleet.Clear();
                        break;
                    case 3:
                        fleet.ShowFleet();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Not supported command");
                        break;
                }
            }
        }
    }
}
