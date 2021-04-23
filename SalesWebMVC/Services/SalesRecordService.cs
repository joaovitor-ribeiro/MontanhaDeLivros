using MontanhasDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MontanhasDeLivros.Services
{
    public class SalesRecordService
    {
        private readonly MontanhasDeLivrosContext _context;

        public SalesRecordService(MontanhasDeLivrosContext context)
        {
            _context = context;
        }


        public async Task<List<SalesRecord>> GetAll()
        {
            var sales = await (from rs in _context.SalesRecord select rs).Include(x => x.Book).ToListAsync();

            return sales;
        }

        public async Task<bool> CreateSale(SalesRecord sale, int bookId)
        {
            if (sale == null) return false;

            var book = _context.Book.FirstOrDefault(x => x.Id == bookId);

            if (book == null) return false;

            sale.Book = book;

            _context.Add(sale);
            await _context.SaveChangesAsync();

            return true;
        }

        //public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        //{
        //    var result = from obj in _context.SalesRecord select obj;
        //    if (minDate.HasValue)
        //    {
        //        result = result.Where(x => x.Date >= minDate.Value);
        //    }
        //    if (maxDate.HasValue)
        //    {
        //        result = result.Where(x => x.Date <= maxDate.Value);
        //    }
        //    return await result
        //        .Include(x => x.Seller)
        //        .Include(x => x.Seller.Department)
        //        .OrderByDescending(x => x.Date)
        //        .ToListAsync();
        //}

        //public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        //{
        //    var result = from obj in _context.SalesRecord select obj;
        //    if (minDate.HasValue)
        //    {
        //        result = result.Where(x => x.Date >= minDate.Value);
        //    }
        //    if (maxDate.HasValue)
        //    {
        //        result = result.Where(x => x.Date <= maxDate.Value);
        //    }
        //    return await result
        //        .Include(x => x.Seller)
        //        .Include(x => x.Seller.Department)
        //        .OrderByDescending(x => x.Date)
        //        .GroupBy(x => x.Seller.Department)
        //        .ToListAsync();
        //}
    }
}
