using CustomerApi.Models;
using CustomerApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Repository
{
    public class CustomerDbRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public CustomerDbRepo(CustomerContext context)
        {
            _context = context;
        }

        public void Create(CustomerModel customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }
            _context.Customers.AddAsync(customer);
        }

        public void Delete(CustomerModel customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException();
            }
            _context.Customers.Remove(customer);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _context.Customers.ToList();
        }

        public CustomerModel GetById(int id)
        {
            return _context.Customers.FirstOrDefault(customer => customer.CustomerId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(CustomerModel user)
        {
            // No need
        }
    }
}
