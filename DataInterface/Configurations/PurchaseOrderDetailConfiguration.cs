using DataInterface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataInterface.Configurations
{
    public class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            builder
                .HasKey(pod => new { pod.PurchaseOrderHeaderId, pod.ProductId });

            builder
                .HasOne(pod => pod.PurchaseOrderHeader)
                .WithMany(poh => poh.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.PurchaseOrderHeaderId);

            builder
                .HasOne(pod => pod.Product)
                .WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.ProductId);
        }
    }
}
