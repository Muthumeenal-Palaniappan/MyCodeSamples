using RetailApplicationBackendDemo.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApplicationBackendDemo.Stocks
{
    public class StockOrderManager : IStockOrderManager
    {
        public void CreateNewOrder(StockOrder stockOrder)
        {
            throw new NotImplementedException();
        }


        public List<StockOrder> RetreiveOrdersByDate(DateTime RequestedDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateStockOrder(StockOrder stockOrder)
        {
            throw new NotImplementedException();
        }
    }
}
