using HappyLifeManagement.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HappyLifeManagement.Models
{
    public class ExpenseDetailViewModel
    {
        [Display(Name = "Danh mục chi")]
        public string CategoryName { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal Sum { get; set; }
    }
}