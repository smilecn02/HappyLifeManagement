using HappyLifeManagement.Data;
using HappyLifeManagement.Data.Entity;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using HappyLifeManagement.Models;

namespace HappyLifeManagement.Controllers
{
    [Authorize(Users = "khactrinhcn02@gmail.com")]
    public class ExpensesController : Controller
    {
        private HappyLifeManagementContext db = new HappyLifeManagementContext();

        // GET: Expenses
        public async Task<ActionResult> Index()
        {
            var expenses = db.Expenses.Include(e => e.ExpenseCategory);

            decimal sumApril = db.Expenses.Where(i => i.ExpenseDate.Month == 4)
                                      .Sum(i => i.Amount);

            DateTime now = DateTime.Now;

            DateTime endDateOfThisMonth = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

            var summaryQuery = db.Expenses.GroupBy(i => new { i.ExpenseDate.Month, i.ExpenseDate.Year })
                .Select(i => new ExpenseSummaryViewModel
                {
                    Month = i.Key.Month + "/" + i.Key.Year,
                    Sum = i.Sum(j => j.Amount),

                    DayMaxSum = i.GroupBy(i11 => i11.ExpenseDate.Day)
                                    .Select(i12 => new { Day = i12.Key, Sum = i12.Sum(i13 => i13.Amount) })
                                    .OrderByDescending(i14 => i14.Sum)
                                    .FirstOrDefault().Day.ToString() + "/" + i.Key.Month.ToString(),
                                    

                    ExpenseDetails = i.GroupBy(i1 => i1.ExpenseCategory.Name)
                                        .Select(i2 => new ExpenseDetailViewModel
                                        {
                                            CategoryName = i2.Key,
                                            Sum = i2.Sum(i3 => i3.Amount)
                                        })
                                        .OrderByDescending(i9 => i9.Sum)
                                        ,

                    DayExpenseDetails = i.GroupBy(i4 => i4.ExpenseDate.Day)
                                        .Select(i5 => new DayExpenDetailViewModel
                                        {
                                            Day = i5.Key.ToString() + "/" + i.Key.Month.ToString(),
                                            Sum = i5.Sum(i6 => i6.Amount),
                                            CategoryDayExpenseDetails = i5.GroupBy(i6 => i6.ExpenseCategory.Name)
                                                                        .Select(i7 => new ExpenseDetailViewModel
                                                                        {
                                                                            CategoryName = i7.Key,
                                                                            Sum = i7.Sum(i8 => i8.Amount)
                                                                        })
                                                                        .OrderByDescending(i10 => i10.Sum)
                                        })
                                    
                }).ToList();

            ViewBag.SummaryQuery = summaryQuery;

            ViewBag.SummaryYear = db.Expenses.Where(i => i.ExpenseDate.Year == now.Year)
                                            .Sum(i => i.Amount);

            return View(await expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories.OrderBy(i => i.Name), 
                "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.Id = Guid.NewGuid();
                db.Expenses.Add(expense);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.ExpenseCategoryId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.ExpenseCategoryId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.ExpenseCategoryId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            db.Expenses.Remove(expense);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
