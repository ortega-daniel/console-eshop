using DataInterface.Enums;

namespace DataInterface.Entities
{
    public class PurchaseOrderHeader
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public PurchaseOrderStatus Status { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
