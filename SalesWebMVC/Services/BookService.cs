using MontanhasDeLivros.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MontanhasDeLivros.Services
{
    public class BookService
    {
        private readonly MontanhasDeLivrosContext _context;

        public BookService(MontanhasDeLivrosContext context)
        {
           _context = context;
        }

        public async Task<List<Book>> FindAllAsync()
        {
            return await _context.Book.OrderBy(x => x.Title).ToListAsync();
        }
    }
}
