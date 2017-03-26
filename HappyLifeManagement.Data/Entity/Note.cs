using System;
using System.ComponentModel.DataAnnotations;

namespace HappyLifeManagement.Data.Entity
{
    public class Note : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }


        public string Content { get; set; }

        public string Tags { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
