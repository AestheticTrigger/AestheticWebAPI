﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Orders.Application.Orders.Commands.Create_Order
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string FisrstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Details { get; set; }
    }
}