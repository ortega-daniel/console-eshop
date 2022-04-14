using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;
using DataLayer.Enums;

namespace BusinessLogic.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private List<PurchaseOrder> _purchaseOrders = TestData.PurchaseOrderList;

        public void AddPurchaseOrder(PurchaseOrder po) 
            => _purchaseOrders.Add(po);

        public PurchaseOrder ChangeStatus(int poNumber, PurchaseOrderStatus status)
        {
            PurchaseOrder po = _purchaseOrders.Find(po => po.Number == poNumber);

            if (po == null) 
                throw new ApplicationException($"PO {poNumber} doesn't exist");

            po.ChangeStatus(status);
            return po;
        }

        public List<PurchaseOrder> GetPurchaseOrders() 
            => _purchaseOrders;
    }
}
