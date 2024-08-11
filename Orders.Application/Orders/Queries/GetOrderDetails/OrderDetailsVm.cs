using AutoMapper;
using Orders.Application.Common.Mapping;
using Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string FisrstName { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateStatus { get; set; }
        public string OrderStatus { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.FisrstName,
                opt => opt.MapFrom(order => order.FisrstName))
                .ForMember(orderVm => orderVm.LastName,
                opt => opt.MapFrom(order => order.LastName))
                .ForMember(orderVm => orderVm.Details,
                opt => opt.MapFrom(order => order.Details))
                .ForMember(orderVm => orderVm.PhoneNumber,
                opt => opt.MapFrom(order => order.PhoneNumber))
                .ForMember(orderVm => orderVm.CreationDate,
                opt => opt.MapFrom(order => order.CreationDate))
                .ForMember(orderVm => orderVm.UpdateStatus,
                opt => opt.MapFrom(order => order.UpdateStatus))
                .ForMember(orderVm => orderVm.OrderStatus,
                opt => opt.MapFrom(order => order.OrderStatus));
        }
    }
}
