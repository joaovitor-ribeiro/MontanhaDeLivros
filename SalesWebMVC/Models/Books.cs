namespace MontanhasDeLivros.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int AmountBooks { get; set; }

        public Books()
        {
        }
        public Books(int id, string title, float price, string description, string author, string publisher, int amountBooks)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Author = author;
            Publisher = publisher;
            AmountBooks = amountBooks;
        }
    }
}
