using System;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string article = Console.ReadLine();

            Console.WriteLine($"{"<h1>"}{Environment.NewLine}   {title}{Environment.NewLine}{"</h1>"}");
            Console.WriteLine($"{"<article>"}{Environment.NewLine}  {article}{Environment.NewLine}{"</article>"}");

            string comment;

            while((comment=Console.ReadLine())!="end of comments")
            {
                Console.WriteLine($"{"<div>"}{Environment.NewLine}  {comment}{Environment.NewLine}{"</div>"}");
            }
        }
    }
}
