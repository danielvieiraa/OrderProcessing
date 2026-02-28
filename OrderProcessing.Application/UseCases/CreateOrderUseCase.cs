using OrderProcessing.Application.DTOs;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.Interfaces;

namespace OrderProcessing.Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> ExecuteAsync(CreateOrderRequest request)
        {
            var order = new Order(request.CustomerName, request.TotalAmount);

            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}