namespace _2nov.Classes
{
    internal class Book
    {
        public string Title;
        public string Author;
        public int Pages;
        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }
        public void GetBookİnfo()
        {
            Console.WriteLine($"" +
                $"Title  : {Title}\n" +
                $"Author : {Author}\n" +
                $"Pages  : {Pages}");
        }
    }
}
