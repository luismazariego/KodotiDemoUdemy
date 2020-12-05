using System.Collections.Generic;
using MediatR;

namespace Catalog.Service.EventHandlers.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
    {
        public IEnumerable<ProducInStockUpdateItem> Items { get; set; } 
            = new List<ProducInStockUpdateItem>();
    }

    public class ProducInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }

    public enum ProductInStockAction 
    {
        Add, 
        Subtract
    }
}