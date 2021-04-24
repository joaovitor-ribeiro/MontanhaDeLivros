using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MontanhasDeLivros.Models;
using MontanhasDeLivros.Services;

namespace MontanhasDeLivros.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly MontanhasDeLivrosContext _context;
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(
            MontanhasDeLivrosContext context,
            SalesRecordService salesRecordService
            )
        {
            _context = context;
            _salesRecordService = salesRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _salesRecordService.GetAll();

            return View(result) ;
        }

        public IActionResult Create()
        {
            ViewBag.BookId = new SelectList
                (
                    _context.Book.ToList(),
                    "Id",
                    "Title"
                );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description,Quantity")] SalesRecord sale, string bookId)
        {
            if (!ModelState.IsValid) return View(sale);
            
            var book = int.Parse(bookId);

            var response = await _salesRecordService.CreateSale(sale, book);

            if (!response) return View(sale);
            
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
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
                            Book = bk,
                            Quantity = rs.Quantity
                        }).FirstOrDefault();

            ViewBag.BookId = new SelectList
                (
                    _context.Book.ToList(),
                    "Id",
                    "Title",
                    sale.Book.Id
                );

            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Date,Amount,Seller,Quantity")] SalesRecord sale, string bookId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var selectedBookId = int.Parse(bookId);
                    var book = _context.Book.FirstOrDefault(x => x.Id == selectedBookId);
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

        public IActionResult Details(int? id)
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
                            Book = bk,
                            Quantity = rs.Quantity
                        }).FirstOrDefault();

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        public IActionResult Delete(int? id)
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
                            Book = bk,
                            Quantity = rs.Quantity
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

        public IActionResult IndexSearch()
        {
            return View();
        }

        public async Task<IActionResult> SingleSearch(DateTime? Date)
        {
            if (!Date.HasValue)
            {
                Date = DateTime.Now;
            }

            ViewData["Date"] = Date.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindSingleDateAsync(Date);
            return View(result);
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
               minDate = new DateTime(DateTime.Now.Year, 1, 1);
           }
            if (!maxDate.HasValue)
            {
                 maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

       public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}