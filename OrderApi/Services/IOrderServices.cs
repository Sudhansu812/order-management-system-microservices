using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderReadDto>> GetAll();

        Task<OrderReadDto> GetById(int id);

        Task<OrderReadDto> Create(OrderCreateDto orderCreateDto);

        Task<bool> Update(int id, OrderUpdateDto orderUpdateDto);

        Task<OrderUpdateDto> Patch(int id, JsonPatchDocument<OrderUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState);

        Task<bool> SavePatchedDetails(int id, OrderUpdateDto orderPatchUpdateDto);

        Task<bool> Delete(int id);
    }
}
