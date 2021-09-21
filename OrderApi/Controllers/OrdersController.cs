using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models.Dtos;
using OrderApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        // GET api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
        {
            return Ok((List<OrderReadDto>)await _orderServices.GetAll());
        }

        // GET api/orders/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<OrderReadDto>> GetById(int id)
        {
            OrderReadDto order = (OrderReadDto)await _orderServices.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/orders
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> Create(OrderCreateDto customerCreateDto)
        {
            OrderReadDto order = await _orderServices.Create(customerCreateDto);
            if (order == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute(nameof(GetById), new { Id = order.OrderId }, order);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrderUpdateDto orderUpdateDto)
        {
            bool updateResult = await _orderServices.Update(id, orderUpdateDto);
            if (!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PATCH api/orders/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<OrderUpdateDto> jsonPatchDocument)
        {
            OrderUpdateDto order = await _orderServices.Patch(id, jsonPatchDocument, ModelState);
            if (!TryValidateModel(order))
            {
                return ValidationProblem(ModelState);
            }
            if (await _orderServices.SavePatchedDetails(id, order) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleteResult = await _orderServices.Delete(id);
            if (deleteResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
