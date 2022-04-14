using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;

namespace BusinessLogic.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders = TestData.OrderList;
        public void CreateOrder(Order order) 
            => _orders.Add(order);

        public Order GetOrder(int id) 
            => _orders.Find(order => order.Id == id);

        public List<Order> GetOrders() 
            => _orders;
    }
}
