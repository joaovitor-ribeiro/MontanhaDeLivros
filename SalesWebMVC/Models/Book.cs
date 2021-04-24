using System;
using System.Collections.Generic;
using System.Linq;

namespace MontanhasDeLivros.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int AmountBook { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Book()
        {
        }
        public Book(int id, string title, float price, string description, string author, string publisher, int amountBook)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Author = author;
            Publisher = publisher;
            AmountBook = amountBook;
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
