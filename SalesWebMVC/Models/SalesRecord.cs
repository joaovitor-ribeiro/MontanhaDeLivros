using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MontanhasDeLivros.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Books> Books { get; set; } = new List<Books>();

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Seller = seller;
        }

        public void AddBooks(Books bo)
        {
            Books.Add(bo);
        }

        public void RemoveSales(Books bo)
        {
            Books.Remove(bo);
        }

        //public double TotalSales(DateTime initial, DateTime final)
        //{
        //    return Books.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        //}
    }
}
