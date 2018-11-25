using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId;
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}