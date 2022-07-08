using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracking.Data;
using ExpenseTracking.Models;


namespace ExpenseTracking.Pages
{
    public class ExpenseModel : PageModel
    {
        private readonly ExpenseTracking.Data.MyContext _context;
        [BindProperty]
        public Expense Expense { get; set; } = default!;
        public IList<Expense> Expenses { get;set; } = default!;

        public ExpenseModel(ExpenseTracking.Data.MyContext context)
        {
            _context = context;
        }

        private async Task PopulatePageData() {
           if (_context.Expenses != null)
            {
                Expenses = await _context.Expenses
                .Include(e => e.Currency)
                .Include(e => e.ExpenseType)
                .Include(e => e.User).ToListAsync();
            }

            ViewData["Currency"] = new SelectList(_context.Set<Currency>(), "Id", "Code");
            ViewData["ExpenseType"] = new SelectList(_context.Set<ExpenseType>(), "Id", "Type");
            ViewData["User"] = new SelectList(_context.Set<User>(), "Id", "Name"); 
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulatePageData();
            return Page();    
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await PopulatePageData();
            // validate foreign keys
            var currency = await _context.Currencies.SingleOrDefaultAsync(c => c.Id == Expense.CurrencyId);
            if (currency == null)
            {
                ModelState.AddModelError("Expense.CurrencyId", "That is not a valid id");
            }
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Expense.UserId);
            if (user == null)
            {
                ModelState.AddModelError("Expense.UserId", "That is not a valid id");
            }
            var expenseType = await _context.ExpenseTypes.SingleOrDefaultAsync(c => c.Id == Expense.ExpenseTypeId);
            if (expenseType == null)
            {
                ModelState.AddModelError("Expense.ExpenseTypeId", "That is not a valid id");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
