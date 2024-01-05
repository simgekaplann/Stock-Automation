using System;
using System.Collections.Generic;

namespace sql_deneme.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactTitle { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
