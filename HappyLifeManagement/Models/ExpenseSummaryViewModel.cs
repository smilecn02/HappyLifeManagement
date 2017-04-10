using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HappyLifeManagement.Models
{
    public class ExpenseSummaryViewModel
    {
        public IEnumerable<ExpenseDetailViewModel> ExpenseDetails { get; set; }

        [Display(Name = "Tháng")]
        public string Month { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal Sum { get; set; }
        public IEnumerable<DayExpenDetailViewModel> DayExpenseDetails { get; set; }
        public string DayMaxSum { get; set; }
    }
}