using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_Aggregates.v1.Domain
{
    public class PurchaseOrderLineItem
    {
        public PurchaseOrderLineItem(Product product, double quantity)
            : this(Guid.NewGuid().ToString(), product, quantity)
        {

        }

        public PurchaseOrderLineItem(string id, Product product, double quantity)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
            this.Product = product;
            this.UpdateQuantity(quantity);
        }

        public string Id
        {
            get;
        }

        public Product Product
        {
            get;
        }

        public double Quantity
        {
            get;
            set;
        }

        private void EnsureLimit(Product product, double quantity)
        {
            var total = product.Price * quantity;

            if (total > 5000)
            {
                throw new Exception("Line item cannot exceep 5000");
            }
        }

        public void UpdateQuantity(double newQuantity)
        {
            this.EnsureLimit(this.Product, newQuantity);

            this.Quantity = newQuantity;
        }
    }
}
