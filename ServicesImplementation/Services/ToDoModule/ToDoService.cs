using Domain.Contracts.Repositories;
using Domain.Contracts.Repositories.ToDoModule;
using ServicesAbstraction.ServicesInterfaces.ToDoModule;
using Shared.DTOs.ToDoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementation.Services.ToDoModule
{
    public class ToDoService(IToDoRepository _toDoRepository) : IToDoService
    {
        public void Add(NewToDoDto newToDoDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, UpdatedToDoDto updatedToDoDto)
        {
            throw new NotImplementedException();
        }
    }
}
