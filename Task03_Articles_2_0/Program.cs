using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03_Articles_2_0
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
            int n = int.Parse(Console.ReadLine());
            List<Article> listOfArticles = new List<Article>();
            
            for (int i = 1; i <= n; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Article nextArticle = new Article(data[0], data[1], data[2]);

                listOfArticles.Add(nextArticle);
            }

            string sortBy = Console.ReadLine();

            

            if (sortBy.ToUpper() == "TITLE")
            {
                listOfArticles =  listOfArticles.OrderBy(x => x.Title).ToList();
            }

            else if (sortBy.ToUpper() == "CONTENT")
            {
                listOfArticles = listOfArticles.OrderBy(x => x.Content).ToList();
            }

            else if (sortBy.ToUpper() == "AUTHOR")
            {
                listOfArticles = listOfArticles.OrderBy(x => x.Author).ToList();
            }
            
            
            Console.WriteLine(string.Join(Environment.NewLine, listOfArticles));
        }
    }
}
