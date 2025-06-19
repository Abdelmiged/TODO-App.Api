using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.ToDoModule
{
    public class NewToDoDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
