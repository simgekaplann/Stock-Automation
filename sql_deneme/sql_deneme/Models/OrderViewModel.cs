
using sql_deneme.Models;

namespace sql_deneme.ViewModels
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
