using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyLifeManagement.Data.Entity
{
    public class Expense : IEntity
    {
        public Guid Id { get; set; }
        [Display(Name = "Ngày chi tiêu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        [Display(Name = "Mục chi")]
        public string Name { get; set; }

        [Display(Name = "Tiền")]
        public decimal Amount { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Danh mục chi")]
        public Guid ExpenseCategoryId { get; set; }

        [Display(Name = "Danh mục chi")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
