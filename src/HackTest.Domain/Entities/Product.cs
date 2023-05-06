using HackTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        [NotMapped]
        public Category? Category { get; set; }
    }
}
