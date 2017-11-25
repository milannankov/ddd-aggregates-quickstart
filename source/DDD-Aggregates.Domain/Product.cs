using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_Aggregates.Domain
{
    public class Product
    {
        public Product(string name, double price)
            : this(Guid.NewGuid().ToString(), name, price)
        {

        }

        public Product(string id, string name, double price)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (price < 0)
            {
                throw new Exception("Price cannot be negative");
            }

            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public string Id
        {
            get;
        }

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
    }
}
