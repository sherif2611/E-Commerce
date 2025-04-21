namespace Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
	public void Configure(EntityTypeBuilder<ProductEntity> builder)
	{
		builder.HasOne(p => p.ProductBrand)
			.WithMany()
			.HasForeignKey(p => p.BrandId);
		builder.HasOne(p => p.ProductType)
			.WithMany()
			.HasForeignKey(p => p.TypeId);

		builder.Property(p => p.Price)
			.HasColumnType("decimal(10,3)");
	}
}
