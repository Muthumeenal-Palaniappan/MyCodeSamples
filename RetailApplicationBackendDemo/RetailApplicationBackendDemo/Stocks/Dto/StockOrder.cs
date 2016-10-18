using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApplicationBackendDemo.Stocks.Dto
{
    public class StockOrder
    {
        public int StockId { get; set; }
        public ProductType StockType { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliverTimeLine { get; set; }
        public DateTime DateRequested { get; set; }
        public int RequestedUserId { get; set; }
    }

    public enum ProductType
    {
        Ammeter,
        Voltmeter,
        Gauge,
        Caliper
    }
}
