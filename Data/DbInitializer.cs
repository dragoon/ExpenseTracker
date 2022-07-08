using ExpenseTracking.Models;

namespace ExpenseTracking.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Name="John"},
                new User{Name="Mary"},
                new User{Name="Arthur"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var expenseTypes = new ExpenseType[]
            {
                new ExpenseType{Type="Food"},
                new ExpenseType{Type="Travel"},
                new ExpenseType{Type="Other"},
            };

            context.ExpenseTypes.AddRange(expenseTypes);
            context.SaveChanges();

            var currencies = new Currency[]
            {
                new Currency{Code="USD"},
                new Currency{Code="CHF"},
            };

            context.Currencies.AddRange(currencies);
            context.SaveChanges();
        }
    }
}