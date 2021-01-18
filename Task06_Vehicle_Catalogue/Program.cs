using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Task06_Vehicle_Catalogue
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

            sb.AppendLine($"Type: {(Type == "car" ?"Car" : "Truck")}");
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
            Vehicle[] catalogue = new Vehicle[50];
            
            double totalCarHp = 0;
            double totalTrucksHp = 0;

            int onlyCarsCount = 0;
            int onlyTrucksCount = 0;

            for (int i = 0; i <= 49; i++)
            {
                string[] datas = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(datas[0].ToUpper() == "END")
                {
                    break;
                }

                if(datas[0] == "car")
                {
                    totalCarHp += int.Parse(datas[3]);
                    onlyCarsCount += 1;
                }
                else
                {
                    totalTrucksHp += int.Parse(datas[3]);
                    onlyTrucksCount += 1;
                }
                

                Vehicle nextVehicle = new Vehicle(datas[0], datas[1], datas[2], int.Parse(datas[3]));
                catalogue[i] = nextVehicle;

            }

            while(true)
            {
                string lookFor = Console.ReadLine();
                if(lookFor.ToUpper() == "CLOSE THE CATALOGUE")
                {
                    break;
                }

                Vehicle findToPrint = catalogue.First(x => x.Model == lookFor);
                Console.WriteLine(findToPrint.ToString());
            }

            //List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            //List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            

            

            double avergCarsHp = 0.00;
            double avergTrucksHp = 0.00;

            if(onlyCarsCount > 0)
            {
                avergCarsHp = totalCarHp / onlyCarsCount;
            }

            if (onlyTrucksCount > 0)
            {
                avergTrucksHp = totalTrucksHp / onlyTrucksCount;
            }

            Console.WriteLine($"Cars have average horsepower of: {avergCarsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avergTrucksHp:f2}.");
        }
    }
}
