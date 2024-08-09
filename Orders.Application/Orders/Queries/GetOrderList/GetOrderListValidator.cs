using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListValidator : AbstractValidator<GetOrderListQuery>
    {
        public GetOrderListValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
