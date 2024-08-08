using AutoMapper;
using Orders.Application.Common.Mapping;
using Orders.Application.Orders.Commands.Create_Order;

namespace Orders.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public string FisrstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(noteCommand => noteCommand.FisrstName,
                opt => opt.MapFrom(noteDto => noteDto.FisrstName))
                .ForMember(noteCommand => noteCommand.LastName,
                opt => opt.MapFrom(noteDto => noteDto.LastName))
                .ForMember(noteCommand => noteCommand.PhoneNumber,
                opt => opt.MapFrom(noteDto => noteDto.PhoneNumber))
                .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
