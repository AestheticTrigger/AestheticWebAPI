using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.Commands.Update_Order
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() 
        {
            RuleFor(updateCommand => updateCommand.OrderStatus).NotEmpty();
            RuleFor(updateCommand => updateCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateCommand => updateCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
