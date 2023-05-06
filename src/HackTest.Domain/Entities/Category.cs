using HackTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
