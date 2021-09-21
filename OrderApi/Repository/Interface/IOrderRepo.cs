using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Repository.Interface
{
    public interface IOrderRepo
    {
        bool SaveChanges();

        IEnumerable<OrderModel> GetAll();

        OrderModel GetById(int id);

        void Create(OrderModel order);

        void Update(OrderModel order);

        void Delete(OrderModel order);
    }
}
