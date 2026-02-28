using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task<IEnumerable<Order>> GetPendingOrderAsync();
    }
}