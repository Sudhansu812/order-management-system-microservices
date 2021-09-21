using CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Repository.Interface
{
    public interface ICustomerRepo
    {
        bool SaveChanges();

        IEnumerable<CustomerModel> GetAll();

        CustomerModel GetById(int id);

        void Create(CustomerModel user);

        void Update(CustomerModel user);

        void Delete(CustomerModel user);
    }
}
