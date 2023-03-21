using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class CollectReq
    {
        public int Id { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? CollectionDate { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}