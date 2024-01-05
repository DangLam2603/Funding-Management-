using FundingApplication.Data;
using FundingApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundingApplication.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public SalaryController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult AddSpending(Guid id)
        {
            var user = dBContext.users
             .Include(u => u.salaries)
             .ThenInclude(s => s.Spendings)
             .FirstOrDefault(u => u.Id == id);

            return View(user);
        }
        public IActionResult Import(Guid id)
        {
            var user = dBContext.users
             .Include(u => u.salaries)
             .ThenInclude(s => s.monthSalaries)
             .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public IActionResult Detail(Guid id)
        {
            var user = dBContext.users
             .Include(u => u.salaries)
             .ThenInclude(s => s.monthSalaries)
             .Include(u => u.salaries)
             .ThenInclude(x=>x.Spendings)
             .FirstOrDefault(u => u.Id == id);
            //validate only this current year (2023)

            //user.salaries.ForEach(s => s.monthSalaries = s.monthSalaries.OrderBy(m => m.dateOfTransaction).ToList());
            user.salaries = user.salaries.OrderBy(s => s.Spendings.FirstOrDefault()?.Time).ToList();
            user.salaries = user.salaries.OrderBy(s => s.monthSalaries.FirstOrDefault()?.dateOfTransaction).ToList();
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public IActionResult DisplaySpending(Guid id)
        {
            var user = dBContext.users
             .Include(u => u.salaries)
             .ThenInclude(s => s.monthSalaries)
             .Include(u => u.salaries)
             .ThenInclude(x => x.Spendings)
             .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Validate only for the current year (2023) and order salaries
            var topTransaction = user.salaries.OrderByDescending(s => s.monthSalaries.FirstOrDefault()?.dateOfTransaction).Take(1).ToList().First().total;
            var topSpending = user.salaries.OrderByDescending(s => s.Spendings.FirstOrDefault()?.Time).Take(1).ToList().First().total;

            return View(user);
        }

        [HttpPost]
        public IActionResult ImportAttributes(Guid userId, double newAmount)
        {
            var user = dBContext.users
                .Include(u => u.salaries)
                .ThenInclude(x => x.monthSalaries)
                .FirstOrDefault(u => u.Id == userId);

            var totalSalary = user.salaries
            .SelectMany(s => s.monthSalaries)
            .Sum(m => m.Salary);

            if (totalSalary == 0)
            {
                totalSalary = newAmount;
            }
            else
            {
                totalSalary += newAmount;
            }

            if (user == null)
            {
                return NotFound();
            }

            var salary = new List<Salary>
            {
                new Salary
                {
                    Id = new Guid(),
                    year = DateTime.Now.Year,
                    total= totalSalary,
                    monthSalaries = new List<MonthSalary> {
                        new MonthSalary
                        {
                            Id = new Guid(),
                            month = DateTime.Now.Month,
                            Salary = newAmount,
                            dateOfTransaction = DateTime.Now
                        }
                    }

                }
            };
            user.salaries.AddRange(salary);

            if (salary == null)
            {
                // Handle the case where the specified salary doesn't exist
                return NotFound();
            }
            // Update other attributes as needed

            dBContext.SaveChanges();

            // Redirect back to the Import view
            return RedirectToAction("Detail", "Salary", new { id = userId });
        }
        [HttpPost]
        public IActionResult ImportSpending(Guid userId, string Description, double Price)
        {
            var user = dBContext.users
               .Include(u => u.salaries)
               .ThenInclude(x => x.Spendings)
               .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var totalSalary = user.salaries
            .SelectMany(s => s.Spendings)
            .Sum(m => m.Price);

            if (totalSalary == 0)
            {
                totalSalary = Price;
            }
            else
            {
                totalSalary += Price;
            }



            var salary = new List<Salary>
            {
                new Salary
                {
                    Id = new Guid(),
                    year = DateTime.Now.Year,
                    total = totalSalary,
                    Spendings = new List<Spending> {
                        new Spending
                        {
                            Id = new Guid(),
                            Description = Description,
                            Price = Price,
                            Time = DateTime.Now
                        }
                    }

                }
            };
            user.salaries.AddRange(salary);

            dBContext.SaveChanges();

            // Redirect back to the Import view
            return RedirectToAction("Detail", "Salary", new { id = userId });
        }
        

       
    }
}

