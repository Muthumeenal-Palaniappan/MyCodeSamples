using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RetailApplicationBackendDemo;
using RetailApplicationBackendDemo.Stocks;
using RetailApplicationBackendDemo.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApplicationBackendDemo.Tests
{
    [TestClass()]
    public class RetailManagerTests
    {
        [TestMethod()]
        public void GetRequiredStocksTest()
        {
            Mock<IStockOrderManager> mockStockOrderManager = new Mock<IStockOrderManager>();
            List<StockOrder> stockOrderList = new List<StockOrder>()
                {
                    new StockOrder() { StockType= ProductType.Ammeter,Quantity=6 },
                    new StockOrder() {StockType=ProductType.Voltmeter,Quantity=3 },
                    new StockOrder() {StockType=ProductType.Ammeter,Quantity=4 },
                    new StockOrder() {StockType=ProductType.Caliper,Quantity=5 },
                    new StockOrder() {StockType=ProductType.Gauge,Quantity=1 }
                };
            mockStockOrderManager.Setup(fn => fn.RetreiveOrdersByDate(It.IsAny<DateTime>())).Returns(
               stockOrderList);

            RetailManager retailManager = new RetailManager(mockStockOrderManager.Object);

            List<StockOrderLevels> actualStockOrderLevels = retailManager.GetRequiredStocks(DateTime.Now);
            List<StockOrderLevels> expectedStockOrderLevels = stockOrderList.GroupBy(g => g.StockType).Select(grp => new StockOrderLevels() { stockType = grp.Key, quantity = grp.Sum(s => s.Quantity) }).ToList();
            Assert.AreEqual(expectedStockOrderLevels.Count, actualStockOrderLevels.Count);
            
        }
    }
}