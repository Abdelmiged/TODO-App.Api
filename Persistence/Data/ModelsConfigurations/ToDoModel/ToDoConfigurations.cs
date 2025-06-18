using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.ModelsConfigurations.ToDoModel
{
    public class ToDoConfigurations : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(TD => TD.Id).HasDefaultValueSql("NEWID()");
            builder.Property(TD => TD.Title).IsRequired().HasColumnType("nvarchar(100)");

            builder.Property(TD => TD.Status).HasConversion(new EnumToStringConverter<Status>()).IsRequired();
            builder.Property(TD => TD.Priority).HasConversion(new EnumToStringConverter<Priority>()).IsRequired();

            builder.Property(TD => TD.CreatedDate).HasDefaultValueSql("GETDATE()");

        }
    }
}
