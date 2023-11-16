using AutoMapper;
using EcommAPI.DTOs;
using EcommAPI.Entities;

namespace EcommAPI.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
