using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class ToDo : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
