using System;
using System.Collections.Generic;

namespace sql_deneme.Models;

public partial class StockMovement
{
    public int StockMovementId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
