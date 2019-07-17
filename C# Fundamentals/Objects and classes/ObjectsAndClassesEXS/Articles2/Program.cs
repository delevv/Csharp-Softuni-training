using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {

            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split(", ");

                Article article = new Article(info[0], info[1], info[2]);
                articles.Add(article);

            }

            string type = Console.ReadLine();

            if (type == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (type == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (type == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }

        }
    }
}
