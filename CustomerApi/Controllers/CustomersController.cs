using CustomerApi.Models.Dtos;
using CustomerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        
        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAll()
        {
            return Ok((List<CustomerReadDto>)await _customerServices.GetAll());
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<CustomerReadDto>> GetById(int id)
        {
            CustomerReadDto customer = (CustomerReadDto) await _customerServices.GetById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> Create(CustomerCreateDto customerCreateDto)
        {
            CustomerReadDto customer = await _customerServices.Create(customerCreateDto);
            if(customer == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute(nameof(GetById), new { Id = customer.CustomerId }, customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CustomerUpdateDto customerUpdateDto)
        {
            bool updateResult = await _customerServices.Update(id, customerUpdateDto);
            if(!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PATCH api/customers/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<CustomerUpdateDto> jsonPatchDocument)
        {
            CustomerUpdateDto customer = await _customerServices.Patch(id, jsonPatchDocument, ModelState);
            if(!TryValidateModel(customer))
            {
                return ValidationProblem(ModelState);
            }
            if(await _customerServices.SavePatchedDetails(id, customer) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleteResult = await _customerServices.Delete(id);
            if(deleteResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
