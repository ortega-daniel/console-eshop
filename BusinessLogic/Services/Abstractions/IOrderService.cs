using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogic.Services.Abstractions
{
    public interface IOrderService
    {
        public void CreateOrder(Order order);
        public List<Order> GetOrders();
        public Order GetOrder(int id);
    }
}
