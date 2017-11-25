using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DDD_Aggregates.Domain
{
    public class PurchaseOrder
    {
        private List<PurchaseOrderLineItem> lineItems = new List<PurchaseOrderLineItem>();

        public PurchaseOrder()
            : this(Guid.NewGuid().ToString(), DateTime.Now, Enumerable.Empty<PurchaseOrderLineItem>())
        {

        }

        public PurchaseOrder(string id, DateTime date, IEnumerable<PurchaseOrderLineItem> items)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            this.EnsureOrderTotal(items);

            this.Id = id;
            this.Date = date;
            this.lineItems = items.ToList();
        }

        public DateTime Date
        {
            get;
        }

        public IEnumerable<PurchaseOrderLineItem> LineItems
        {
            get;
        }

        public string Id
        {
            get;
        }

        private void EnsureOrderTotal(IEnumerable<PurchaseOrderLineItem> lineItems)
        {
            var orderTotal = lineItems.Sum(o => o.Total);

            if(orderTotal > 20000)
            {
                throw new Exception("Order total must not exceed 20000");
            }
        }

        public string AddLineItem(Product product, double quantity)
        {
            var item = new PurchaseOrderLineItem(product, quantity);
            var newItems = this.lineItems.ToList();
            newItems.Add(item);

            this.EnsureOrderTotal(newItems);
            this.lineItems = newItems;

            return item.Id;
        }

        public void UpdateLineItem(string lineItemId, double quantity)
        {
            var item = this.lineItems.FirstOrDefault(l => l.Id == lineItemId);

            if(item == null)
            {
                return;
            }

            var oldQuantity = item.Quantity;
            item.UpdateQuantity(quantity);

            this.EnsureOrderTotal(this.lineItems);
        }
    }
}
