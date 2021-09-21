using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.Dtos
{
    public class OrderUpdateDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string OrderName { get; set; }
    }
}
