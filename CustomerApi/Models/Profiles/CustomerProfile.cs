using AutoMapper;
using CustomerApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Models.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel,CustomerReadDto>();
            CreateMap<CustomerCreateDto,CustomerModel>();
            CreateMap<CustomerUpdateDto,CustomerModel>();
            CreateMap<CustomerModel,CustomerUpdateDto>();
        }
    }
}
