using AutoMapper;
using Orders.Application.Common.Mapping;
using Orders.Domain;

namespace Orders.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public long PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order,  OrderLookupDto>()
                .ForMember(orderDto => orderDto.Id,
                opt => opt.MapFrom(order =>  order.Id))
                .ForMember(orderDto => orderDto.PhoneNumber,
                opt => opt.MapFrom(order => order.PhoneNumber));
        }
    }
}
