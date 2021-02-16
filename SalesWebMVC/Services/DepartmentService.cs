using MontanhasDeLivros.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MontanhasDeLivros.Services
{
    public class DepartmentService
    {
        private readonly MontanhasDeLivrosContext _context;

        public DepartmentService(MontanhasDeLivrosContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
