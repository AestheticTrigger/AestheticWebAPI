using System;

namespace Orders.Domain
{
    public class Order
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string FisrstName { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
