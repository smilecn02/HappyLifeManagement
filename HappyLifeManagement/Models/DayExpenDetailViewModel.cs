using System.Collections.Generic;

namespace HappyLifeManagement.Models
{
    public class DayExpenDetailViewModel
    {
        public IEnumerable<ExpenseDetailViewModel> CategoryDayExpenseDetails { get; internal set; }
        public string Day { get; set; }

        //Use for sorting.
        public int DayNumber { get; set; }
        public decimal Sum { get; set; }
    }
}