using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Data;
using ExpenseTracking.Models;

namespace ExpenseTracking.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly ExpenseTracking.Data.MyContext _context;

        public IndexModel(ExpenseTracking.Data.MyContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Expenses != null)
            {
                Expense = await _context.Expenses
                .Include(e => e.Currency)
                .Include(e => e.ExpenseType)
                .Include(e => e.User).ToListAsync();
            }
        }
    }
}
