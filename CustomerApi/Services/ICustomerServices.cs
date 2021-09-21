using CustomerApi.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerReadDto>> GetAll();

        Task<CustomerReadDto> GetById(int id);

        Task<CustomerReadDto> Create(CustomerCreateDto commandCreateDto);

        Task<bool> Update(int id, CustomerUpdateDto customerUpdateDto);

        Task<CustomerUpdateDto> Patch(int id, JsonPatchDocument<CustomerUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState);

        Task<bool> SavePatchedDetails(int id, CustomerUpdateDto customerPatchUpdateDto);

        Task<bool> Delete(int id);
    }
}
