﻿using System;
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
        public int Quantity { get; set; }
        public Book Book { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, int quantity, Book book)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Quantity = quantity;
            Book = book;
        }

        //public void AddBooks(Books bo)
        //{
        //    Book.Add(bo);
        //}

        //public void RemoveSales(Books bo)
        //{
        //    Book.Remove(bo);
        //}

        //public double TotalSales(DateTime initial, DateTime final)
        //{
        //    return Book.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        //}
    }
}
