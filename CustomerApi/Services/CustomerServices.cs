using AutoMapper;
using CustomerApi.Models;
using CustomerApi.Models.Dtos;
using CustomerApi.Repository.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;

        public CustomerServices(ICustomerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<CustomerReadDto> Create(CustomerCreateDto commandCreateDto)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(commandCreateDto);
            try
            {
                _repository.Create(customer);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<CustomerReadDto>(customer));
        }

        public Task<bool> Delete(int id)
        {
            CustomerModel customer = _repository.GetById(id);
            if(customer == null)
            {
                return Task.Run(() => false);
            }
            try
            {
                _repository.Delete(customer);
            }
            catch
            {
                return Task.Run(() => false);
            }
            return Task.Run(() => _repository.SaveChanges());
        }
        
        /// <summary>
        ///     Get all customers from the repository
        /// </summary>
        /// <returns>list of customers</returns>
        public Task<IEnumerable<CustomerReadDto>> GetAll()
        {
            List<CustomerModel> customers = (List<CustomerModel>) _repository.GetAll();
            return Task.Run(() => _mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        /// <summary>
        ///     Get the customer with the id as param
        /// </summary>
        /// <param name="id"></param>
        /// <returns>customer/null</returns>
        public Task<CustomerReadDto> GetById(int id)
        {
            CustomerModel customer = _repository.GetById(id);
            if(customer == null)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<CustomerReadDto>(customer));
        }

        public Task<CustomerUpdateDto> Patch(int id, JsonPatchDocument<CustomerUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState)
        {
            CustomerModel customer = _repository.GetById(id);
            if(customer == null)
            {
                return null;
            }
            CustomerUpdateDto customerUpdateDto = _mapper.Map<CustomerUpdateDto>(customer);
            jsonPatchDocument.ApplyTo(customerUpdateDto, ModelState);
            return Task.Run(() => customerUpdateDto);
        }

        public Task<bool> SavePatchedDetails(int id, CustomerUpdateDto customerPatchUpdateDto)
        {
            CustomerModel customer = _repository.GetById(id);
            _mapper.Map(customerPatchUpdateDto, customer);
            _repository.Update(customer);
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<bool> Update(int id, CustomerUpdateDto customerUpdateDto)
        {
            CustomerModel customer = _repository.GetById(id);
            if(customer == null)
            {
                return Task.Run(() => false);
            }
            _mapper.Map(customerUpdateDto,customer);
            _repository.Update(customer);
            return Task.Run(() => _repository.SaveChanges());
        }
    }
}
