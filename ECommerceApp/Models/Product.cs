using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public int CategoryId { get; set; }

        //Navigation property that makes CategoryId a Foreign Key
        public Category Category { get; set; }
    }
}
