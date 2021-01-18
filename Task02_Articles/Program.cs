using System;
using System.Linq;

namespace Task02_Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}"; 
        }



    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Article article = new Article(data[0], data[1], data[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] comandAndArguments = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string comand = comandAndArguments[0];
                string argument = comandAndArguments[1];

                switch (comand)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(argument);
                        break;

                    case "Rename":
                        article.Rename(argument);
                        break;
                }
            }

            
            Console.WriteLine(article.ToString());
        }
    }
}
