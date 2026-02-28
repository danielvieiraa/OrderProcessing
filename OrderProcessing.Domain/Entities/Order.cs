using OrderProcessing.Domain.Enums;

namespace OrderProcessing.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public Order(string customerName, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            TotalAmount = totalAmount;
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsProcessing() => Status = OrderStatus.Processing;

        public void MarkAsCompleted() => Status = OrderStatus.Completed;

        public void MarkAsFailed() => Status = OrderStatus.Failed;

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(CustomerName)) throw new ArgumentException("Customer name is required");

            if (TotalAmount <= 0) throw new ArgumentException("Total amount must be greater than 0");
        }
    }
}