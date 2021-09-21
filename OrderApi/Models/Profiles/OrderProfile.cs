using OrderApi.Models.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, OrderReadDto>();
            CreateMap<OrderCreateDto, OrderModel>();
            CreateMap<OrderUpdateDto, OrderModel>();
            CreateMap<OrderModel, OrderUpdateDto>();
        }
    }
}
