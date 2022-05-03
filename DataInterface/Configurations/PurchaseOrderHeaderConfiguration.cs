using DataInterface.Entities;
using DataInterface.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataInterface.Configurations
{
    public class PurchaseOrderHeaderConfiguration : IEntityTypeConfiguration<PurchaseOrderHeader>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderHeader> builder)
        {
            builder
                .Property(poh => poh.Date)
                .HasDefaultValueSql("getdate()");

            builder
                .Property(poh => poh.Status)
                .HasDefaultValue(PurchaseOrderStatus.Pending);
        }
    }
}
