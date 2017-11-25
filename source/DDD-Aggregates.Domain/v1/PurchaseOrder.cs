using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DDD_Aggregates.v1.Domain
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
    }
}
