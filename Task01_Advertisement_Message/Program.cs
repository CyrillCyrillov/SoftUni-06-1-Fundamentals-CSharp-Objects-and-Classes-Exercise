using System;

namespace Task01_Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] posiblePhrases = { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."};

            string[] posibleEvents = { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"};

            string[] posibleAuthors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

            string[] posibleCities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int number = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            for (int i = 0; i <= number; i++)
            {
                string phrase = posiblePhrases[rnd.Next(posiblePhrases.Length - 1)];
                string eevent = posibleEvents[rnd.Next(posibleEvents.Length - 1)];
                string author = posibleAuthors[rnd.Next(posibleAuthors.Length - 1)];
                string city = posibleCities[rnd.Next(posibleCities.Length - 1)];

                Console.WriteLine($"{phrase} {eevent} {author} – {city}");
            }
            
            
        }
    }
}
