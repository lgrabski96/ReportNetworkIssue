using Shop.Model;
using System;
using System.Collections.Generic;

namespace Shop
{
    public class Fleet
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        // fleet constructor, what to do at object creation. The same as above
        // public Fleet()
        // {
        //    vehicles = new List<Vehicle>();
        // }

        public void AddVehicle()
        {
            Console.WriteLine("Select vehicle type:");
            Console.WriteLine(" 1) Bike");
            Console.WriteLine(" 2) Car");
            Console.WriteLine(" 3) Plane");

            string commandText = Console.ReadLine();

            if (!int.TryParse(commandText, out int command))
            {
                Console.WriteLine("Incorrent type. Try again!");
                return;
            }

            Console.WriteLine();

            switch (command)
            {
                case 1:
                    Bike bike = new Bike();
                    bike.Fill();
                    vehicles.Add(bike);
                    break;
                
                case 2:
                    Car car = new Car();
                    car.Fill();
                    vehicles.Add(car);
                    break;
                
                case 3:
                    Plane plane = new Plane();
                    plane.Fill();
                    vehicles.Add(plane);
                    break;

                default:
                    Console.WriteLine("Not supported type");
                    break;
            }
        }

        public void Clear()
        {
            vehicles.Clear();
        }

        public void ShowFleet()
        {
            Console.Write("Range for cost calculation:");
            if (!int.TryParse(Console.ReadLine(), out int range))
            {
                Console.WriteLine("Incorrect value. Try again!");
            }

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine();
                vehicle.Print(range);
            }
            
            Console.WriteLine();
        }
    }
}
