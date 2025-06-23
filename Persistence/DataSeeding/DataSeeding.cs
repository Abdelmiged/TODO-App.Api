using Domain.Contracts.DataSeeding;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Contexts;
using Shared.DTOs.ToDoModule;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.DataSeeding
{
    public class DataSeeding(StoreDbContext _storeDbContext) : IDataSeeding
    {
        public void Seed()
        {
            if (_storeDbContext.Database.GetPendingMigrations().Any())
            {
                _storeDbContext.Database.Migrate();
            }

            if (!_storeDbContext.ToDos.Any())
            {
                var filePath = @"..\Persistence\Data\SeedingDummyData\TODOSeedingData.json";

                if(!File.Exists(filePath))
                    throw new FileNotFoundException(filePath);

                var jsonFile = File.ReadAllText(filePath);

                var deserializedData = JsonSerializer.Deserialize<List<NewToDoDto>>(jsonFile);

                var todoList = deserializedData?.Select(O => new ToDo
                {
                    Title = O.Title,
                    Description = O.Description,
                    Priority = StringToEnumValueConverter<Priority>.ConvertStringToEnum(O.Priority),
                    DueDate = O.DueDate,
                });

                if (todoList != null && todoList.Any())
                {
                    _storeDbContext.ToDos.AddRange(todoList);
                    _storeDbContext.SaveChanges();
                }
            }
        }
    }
}
