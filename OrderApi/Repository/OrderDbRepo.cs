using OrderApi.Models;
using OrderApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Repository
{
    public class OrderDbRepo : IOrderRepo
    {
        private readonly OrderContext _context;

        public OrderDbRepo(OrderContext context)
        {
            _context = context;
        }

        public void Create(OrderModel order)
        {
            if (order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.AddAsync(order);
        }

        public void Delete(OrderModel order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.Remove(order);
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return _context.Orders.ToList();
        }

        public OrderModel GetById(int id)
        {
            return _context.Orders.FirstOrDefault(order => order.OrderId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(OrderModel order)
        {
            // Keep Empty
        }
    }
}
