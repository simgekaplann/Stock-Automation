using sql_deneme.Models;
using System.Collections.Generic;

namespace sql_deneme.ViewModels
{
    public class HomeViewModel
    {
        public List<Supplier> Suppliers { get; set; }
        public List<Customer> Customers { get; set; }
        public List <Product> Products { get; set; }
        public List<StockMovement> StockMovements { get; set; }
     
    }
}
