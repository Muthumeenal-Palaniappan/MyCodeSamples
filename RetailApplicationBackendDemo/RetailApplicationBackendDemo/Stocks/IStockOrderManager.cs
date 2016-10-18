using RetailApplicationBackendDemo.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApplicationBackendDemo.Stocks
{
    public interface IStockOrderManager
    {
        void CreateNewOrder(StockOrder stockOrder);
        List<StockOrder> RetreiveOrdersByDate(DateTime RequestedDate);
        void UpdateStockOrder(StockOrder stockOrder);
    }
}
