using FreshShop.Data;
using FreshShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FreshShopContext _freshShopContext;
        private readonly Item _item;

        public OrderRepository(FreshShopContext freshShopContext, Item item)
        {
            _freshShopContext = freshShopContext;
            _item = item;
        }
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _freshShopContext.Orders.Add(order);

            var CartItems = _item.Products;
            var orderDetail = new OrderDetails()
            {
                Price = CartItems.Price,
                Id = CartItems.Id,
                OrderId = order.OrderId,
            };
            _freshShopContext.OrderDetails.Add(orderDetail);
            _freshShopContext.SaveChanges();
        }
    }
}
