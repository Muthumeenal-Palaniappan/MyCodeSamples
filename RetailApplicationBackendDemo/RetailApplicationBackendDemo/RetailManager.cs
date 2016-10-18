using RetailApplicationBackendDemo.Stocks;
using RetailApplicationBackendDemo.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApplicationBackendDemo
{
    public class RetailManager
    {
        private IStockOrderManager _stockOrderManager;
        public RetailManager(IStockOrderManager stockOrderManager)
        {
            _stockOrderManager = stockOrderManager;
        }
        public List<StockOrderLevels> GetRequiredStocks(DateTime requestedDate)
        {

            List<StockOrderLevels> requiredStockLevels = new List<StockOrderLevels>();
            var stockOrderList = _stockOrderManager.RetreiveOrdersByDate(requestedDate);
            var stockGroup = from stockOrders in stockOrderList
                             group stockOrders by stockOrders.StockType
                             // by new { prodType = stockOrders.StockType}
                             into g
                             select new
                             {
                                 stockType = g.Key,//g.Key.prodType
                                 quantity = g.Sum(q => q.Quantity)

                             };
            foreach (var item in stockGroup)
            {
                StockOrderLevels stockOrderLevels = new StockOrderLevels()

                {
                    quantity = item.quantity,
                    stockType = item.stockType

                };
                requiredStockLevels.Add(stockOrderLevels);
            }

            return requiredStockLevels;
        }
        public void InsertStockOrderList(List<StockOrder> stockOrderList)
        {
            try
            {
                foreach (var stockOrder in stockOrderList)
                {
                    _stockOrderManager.CreateNewOrder(stockOrder);
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
