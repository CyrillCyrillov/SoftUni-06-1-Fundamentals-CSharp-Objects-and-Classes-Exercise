using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Task06_Vehicle_Catalogue_2
{
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            for (int i = 0; i <= 49; i++)
            {
                string[] datas = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (datas[0].ToUpper() == "END")
                {
                    break;
                }
                
                Vehicle nextVehicle = new Vehicle(datas[0], datas[1], datas[2], int.Parse(datas[3]));
                catalogue.Add(nextVehicle);

            }

            while (true)
            {
                string lookFor = Console.ReadLine();
                if (lookFor.ToUpper() == "CLOSE THE CATALOGUE")
                {
                    break;
                }

                Vehicle findToPrint = catalogue.First(x => x.Model == lookFor);
                Console.WriteLine(findToPrint.ToString());
            }

            List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            double totalCarHp = onlyCars.Sum(x => x.HorsePower);
            double totalTrucksHp = onlyTrucks.Sum(x => x.HorsePower); 
           

            double avergCarsHp = 0.00;
            double avergTrucksHp = 0.00;

            if (onlyCars.Count > 0)
            {
                avergCarsHp = totalCarHp / onlyCars.Count;
            }

            if (onlyTrucks.Count > 0)
            {
                avergTrucksHp = totalTrucksHp / onlyTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avergCarsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avergTrucksHp:f2}.");
        }
    }
}