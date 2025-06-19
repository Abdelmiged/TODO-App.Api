using Domain.Contracts.Repositories.ToDoModule;
using Domain.Models;
using Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ToDoModule
{
    public class ToDoRepository(StoreDbContext _storeDbContext) : GenericRepository<ToDo, Guid>(_storeDbContext) , IToDoRepository
    {
    }
}
