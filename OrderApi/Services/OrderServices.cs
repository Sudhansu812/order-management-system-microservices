using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderApi.Models;
using OrderApi.Models.Dtos;
using OrderApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepo _repository;
        private readonly IMapper _mapper;

        public OrderServices(IOrderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<OrderReadDto> Create(OrderCreateDto orderCreateDto)
        {
            OrderModel order = _mapper.Map<OrderModel>(orderCreateDto);
            try
            {
                _repository.Create(order);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<OrderReadDto>(order));
        }

        public Task<bool> Delete(int id)
        {
            OrderModel order = _repository.GetById(id);
            if (order == null)
            {
                return Task.Run(() => false);
            }
            try
            {
                _repository.Delete(order);
            }
            catch
            {
                return Task.Run(() => false);
            }
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<IEnumerable<OrderReadDto>> GetAll()
        {
            List<OrderModel> orders = (List<OrderModel>)_repository.GetAll();
            return Task.Run(() => _mapper.Map<IEnumerable<OrderReadDto>>(orders));
        }

        public Task<OrderReadDto> GetById(int id)
        {
            OrderModel order = _repository.GetById(id);
            if (order == null)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<OrderReadDto>(order));
        }

        public Task<OrderUpdateDto> Patch(int id, JsonPatchDocument<OrderUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState)
        {
            OrderModel order = _repository.GetById(id);
            if (order == null)
            {
                return null;
            }
            OrderUpdateDto customerUpdateDto = _mapper.Map<OrderUpdateDto>(order);
            jsonPatchDocument.ApplyTo(customerUpdateDto, ModelState);
            return Task.Run(() => customerUpdateDto);
        }

        public Task<bool> SavePatchedDetails(int id, OrderUpdateDto orderPatchUpdateDto)
        {
            OrderModel order = _repository.GetById(id);
            _mapper.Map(orderPatchUpdateDto, order);
            _repository.Update(order);
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<bool> Update(int id, OrderUpdateDto orderUpdateDto)
        {
            OrderModel order = _repository.GetById(id);
            if (order == null)
            {
                return Task.Run(() => false);
            }
            _mapper.Map(orderUpdateDto, order);
            _repository.Update(order);
            return Task.Run(() => _repository.SaveChanges());
        }
    }
}
