using DDD_Aggregates.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Aggregates.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DummyPurchaseOrderRepository();

            var order1 = new PurchaseOrder();
            var product1 = new Product("Dell Printer", 200.0);
            var product2 = new Product("Wireless router - Cisco", 500);
            var product3 = new Product("IBM Server", 15000);

            order1.AddLineItem(product1, 10);
            order1.AddLineItem(product2, 30);
            order1.AddLineItem(product3, 1);

            repository.SaveOrder(order1);

            System.Console.ReadLine();
        }
    }
}
