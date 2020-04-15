﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int UPC { get; set; }
        [Required]
        [Range(0,10000)]//sets the required range for the given property. So for this, the price has to be between $0 and $10000
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}