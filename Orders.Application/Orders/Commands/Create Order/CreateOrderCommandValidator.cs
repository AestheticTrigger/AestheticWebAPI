using System;
using FluentValidation;

namespace Orders.Application.Orders.Commands.Create_Order
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(createOrderCommand => createOrderCommand.FisrstName).NotEmpty().MaximumLength(250);
            RuleFor(createOrderCommand => createOrderCommand.LastName).NotEmpty().MaximumLength(250);
            RuleFor(createOrderCommand => createOrderCommand.PhoneNumber.ToString()).NotEmpty()
                .Must(phoneNumber => phoneNumber.Length == 12).Must(phoneNumber => phoneNumber.StartsWith("380"));
            RuleFor(createOrderCommand => createOrderCommand.Details).NotEmpty().MaximumLength(250);
        }
    }
}
