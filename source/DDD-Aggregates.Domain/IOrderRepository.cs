using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Aggregates.Domain
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder GetOrder(string id);
        void SaveOrder(PurchaseOrder order);
    }
}
