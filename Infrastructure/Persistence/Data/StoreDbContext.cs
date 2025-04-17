﻿namespace Persistence.Data;
public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<ProductBrand> ProductBrands { get; set; }
	public DbSet<ProductType> ProductTypes { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
	}
}
