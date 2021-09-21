using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string OrderName { get; set; }
    }
}
