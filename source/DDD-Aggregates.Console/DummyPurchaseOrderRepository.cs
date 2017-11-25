using DDD_Aggregates.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Aggregates.Console
{
    public class DummyPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private List<PurchaseOrder> orders = new List<PurchaseOrder>();
        public PurchaseOrder GetOrder(string id)
        {
            return this.orders.FirstOrDefault(o => o.Id == id);
        }

        public void SaveOrder(PurchaseOrder order)
        {
            if(this.orders.Any(o => o.Id == order.Id))
            {
                return;
            }

            this.orders.Add(order);
        }
    }
}
