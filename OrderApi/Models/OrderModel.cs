using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderModel
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string OrderName { get; set; }

    }
}
