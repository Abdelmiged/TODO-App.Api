using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Contracts.Repositories.ToDoModule;
using Domain.Models;
using ServicesAbstraction.ServicesInterfaces.ToDoModule;
using Shared.DTOs.ToDoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementation.Services.ToDoModule
{
    public class ToDoService(IToDoRepository _toDoRepository, IMapper _mapper) : IToDoService
    {
        public void Add(NewToDoDto newToDoDto)
        {
            if (newToDoDto is null)
                throw new ArgumentNullException("New TODO Dto is null");

            var newToDo = _mapper.Map<NewToDoDto, ToDo>(newToDoDto);
            var result = _toDoRepository.Add(newToDo);

            if (result == 0)
                throw new Exception("Couldn't add a new TODO");
        }

        public List<ToDoDto> GetAll()
        {
            var todoList = _toDoRepository.GetAll();

            if (todoList is null)
                return null;

            var mappedTodoList = _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDto>>(todoList).ToList();

            return mappedTodoList;
        }

        public void Remove(Guid id)
        {
            var todoEntity = _toDoRepository.GetEntity(id);

            if (todoEntity is null)
                throw new ArgumentNullException($"No TODO with Id = {id} is found");

            var result = _toDoRepository.Delete(todoEntity);

            if (result == 0)
                throw new Exception("Couldn't remove TODO");
        }

        public void Update(UpdatedToDoDto updatedToDoDto)
        {
            var todoEntity = _toDoRepository.GetEntity(updatedToDoDto.Id);

            if(todoEntity is null)
                throw new ArgumentNullException($"No TODO with Id = {updatedToDoDto.Id} is found");

            todoEntity = _mapper.Map<UpdatedToDoDto, ToDo>(updatedToDoDto);

            var result = _toDoRepository.Update(todoEntity);

            if (result == 0)
                throw new Exception("Couldn't update TODO");
        }
    }
}
