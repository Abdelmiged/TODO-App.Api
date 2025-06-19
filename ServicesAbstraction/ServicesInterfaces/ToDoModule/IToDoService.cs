using Shared.DTOs.ToDoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction.ServicesInterfaces.ToDoModule
{
    public interface IToDoService
    {
        public List<ToDoDto> GetAll();
        public void Add(NewToDoDto newToDoDto);
        public void Remove(Guid id);
        public void Update(UpdatedToDoDto updatedToDoDto);
    }
}
