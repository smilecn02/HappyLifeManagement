using System;
using System.ComponentModel.DataAnnotations;

namespace HappyLifeManagement.Data.Entity
{
    public class ExpenseCategory : IEntity
    {
        public Guid Id { get; set; }

        [Display(Name="Tên danh mục")]
        public string Name { get; set; }
    }
}
