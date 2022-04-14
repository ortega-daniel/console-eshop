using DataLayer.Entities;
using DataLayer.Enums;
using System.Collections.Generic;

namespace BusinessLogic.Services.Abstractions
{
    public interface IPurchaseOrderService
    {
        public void AddPurchaseOrder(PurchaseOrder po);
        public List<PurchaseOrder> GetPurchaseOrders();
        public PurchaseOrder ChangeStatus(int poNumber, PurchaseOrderStatus status);
    }
}
