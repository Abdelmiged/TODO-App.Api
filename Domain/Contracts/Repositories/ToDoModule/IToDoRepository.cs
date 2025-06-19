using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories.ToDoModule
{
    public interface IToDoRepository : IGenericRepository<ToDo, Guid>
    {
    }
}
