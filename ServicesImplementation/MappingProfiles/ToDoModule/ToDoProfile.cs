using AutoMapper;
using Domain.Models;
using Shared.DTOs.ToDoModule;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementation.MappingProfiles.ToDoModule
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoDto>()
                .ForMember(TD => TD.Status, options => options.MapFrom(TDE => TDE.Status.ToString()))
                .ForMember(TD => TD.Priority, options => options.MapFrom(TDE => TDE.Priority.ToString()));

            CreateMap<NewToDoDto, ToDo>()
                .ForMember(TDE => TDE.Status, options => options.MapFrom(NTD => Status.Pending))
                .ForMember(TDE => TDE.Priority, options => options.MapFrom(NTD => StringToEnumValueConverter<Priority>.ConvertStringToEnum(NTD.Priority)));

            CreateMap<UpdatedToDoDto, ToDo>()
                .ForMember(TDE => TDE.Status, options => options.MapFrom(UTD => StringToEnumValueConverter<Status>.ConvertStringToEnum(UTD.Status)))
                .ForMember(TDE => TDE.Priority, options => options.MapFrom(UTD => StringToEnumValueConverter<Priority>.ConvertStringToEnum(UTD.Priority)))
                .ForMember(TDE => TDE.LastModifiedDate, options => options.MapFrom(O => DateTime.Now));
        }
    }
}
