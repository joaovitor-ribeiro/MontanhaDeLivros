using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontanhasDeLivros.Models;
using MontanhasDeLivros.Services;

namespace MontanhasDeLivros.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly MontanhasDeLivrosContext _context;

        public SalesRecordsController(MontanhasDeLivrosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = (from rs in _context.SalesRecord 
                          join bk in _context.Book on rs.Book.Id equals bk.Id
                          select new SalesRecord(){
                                Id = rs.Id,   
                                Date = rs.Date,
                                Amount = rs.Amount,
                                Book = bk
                            });

            return View(result) ;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description")] SalesRecord sale)
        {
            if (ModelState.IsValid)
            {
                var bookId = int.Parse(HttpContext.Request.Form["Book"].First());
                var book = _context.Book.FirstOrDefault(x => x.Id == bookId);

                sale.Book = book;

                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = (from rs in _context.SalesRecord
                          join bk in _context.Book on rs.Book.Id equals bk.Id
                          where rs.Id == id
                          select new SalesRecord()
                          {
                              Id = rs.Id,
                              Date = rs.Date,
                              Amount = rs.Amount,
                              Book = bk
                          }).FirstOrDefault();

            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Seller")] SalesRecord sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bookId = int.Parse(HttpContext.Request.Form["Book.Id"].First());
                    var book = _context.Book.FirstOrDefault(x => x.Id == bookId);
                    sale.Book = book;
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(sale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = (from rs in _context.SalesRecord
                        join bk in _context.Book on rs.Book.Id equals bk.Id
                        where rs.Id == id
                        select new SalesRecord()
                        {
                            Id = rs.Id,
                            Date = rs.Date,
                            Amount = rs.Amount,
                            Book = bk
                        }).FirstOrDefault();

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = (from rs in _context.SalesRecord
                        join bk in _context.Book on rs.Book.Id equals bk.Id
                        where rs.Id == id
                        select new SalesRecord()
                        {
                            Id = rs.Id,
                            Date = rs.Date,
                            Amount = rs.Amount,
                            Book = bk
                        }).FirstOrDefault();
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.SalesRecord.FindAsync(id);
            _context.SalesRecord.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
            return _context.SalesRecord.Any(e => e.Id == id);
        }

        //public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        //{
        //    if (!minDate.HasValue)
        //    {
        //        minDate = new DateTime(DateTime.Now.Year, 1, 1);
        //    }
        //    if (!maxDate.HasValue)
        //    {
        //        maxDate = DateTime.Now;
        //    }
        //    ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        //    ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        //    var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
        //    return View(result);
        //}

        //public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        //{
        //    if (!minDate.HasValue)
        //    {
        //        minDate = new DateTime(DateTime.Now.Year, 1, 1);
        //    }
        //    if (!maxDate.HasValue)
        //    {
        //        maxDate = DateTime.Now;
        //    }
        //    ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        //    ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        //    var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
        //    return View(result);
        //}
    }
}