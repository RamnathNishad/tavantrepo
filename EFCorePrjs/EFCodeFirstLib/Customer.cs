﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstLib
{
    [Table("customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string City { get; set; }
        public string Country {  get; set; }
    }
}
