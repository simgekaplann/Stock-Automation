using System;
using System.Collections.Generic;

namespace sql_deneme.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();

    public virtual Supplier Supplier { get; set; } = null!;
}
