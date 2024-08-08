using AutoMapper;
using Orders.WebApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Orders.Queries.GetOrderList;
using System.Threading;
using Orders.Application.Orders.Queries.GetOrderDetails;
using Orders.Application.Orders.Commands.Create_Order;
using Orders.Application.Orders.Commands.Update_Order;
using Orders.WebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Orders.Application.Orders.Commands.Update_Order;

namespace Orders.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsVm>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
