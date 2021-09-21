using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Models.Dtos
{
    public class CustomerReadDto
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CustomerContactNumber { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
