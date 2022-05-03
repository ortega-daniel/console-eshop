namespace DataInterface.Entities
{
    public class PurchaseOrderDetail
    {
        public int Quantity { get; set; }

        public int PurchaseOrderHeaderId { get; set; }
        public PurchaseOrderHeader PurchaseOrderHeader { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
