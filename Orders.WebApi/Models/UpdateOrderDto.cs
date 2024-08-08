using AutoMapper;
using Orders.Application.Common.Mapping;
using Orders.Application.Orders.Commands.Update_Order;

namespace Orders.WebApi.Models
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public Guid id { get; set; }
        public string OrderStatus { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Id,
                opt => opt.MapFrom(orderDto => orderDto.id))
                .ForMember(orderCommand => orderCommand.OrderStatus,
                opt => opt.MapFrom(orderDto => orderDto.OrderStatus));
        }
    }
}
