using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperApp.Models
{
    [Table("Products")]
    public class product
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

    }
}