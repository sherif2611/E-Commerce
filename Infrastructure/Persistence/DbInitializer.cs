namespace Persistence;
public class DbInitializer(StoreDbContext context) : IDbInitializer
{
	public async Task InitializeAsync()
	{
		try
		{
			/// Production => Create Db + Seeding
			/// Dev        => Seeding

			//if ((await context.Database.GetPendingMigrationsAsync()).Any())
			//	await context.Database.MigrateAsync();
			
			if (!context.Set<ProductBrand>().Any())
			{
				// Read from the file
				var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Seeding\brands.json");
				// Convert to C# objects (Deserialization)
				var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);
				// Save to DB
				if (objects is not null && objects.Any())
				{
					context.Set<ProductBrand>().AddRange(objects);
					context.SaveChanges();
				}
			}
			if (!context.Set<ProductType>().Any())
			{
				// Read from the file
				var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Seeding\types.json");
				// Convert to C# objects (Deserialization)
				var objects = JsonSerializer.Deserialize<List<ProductType>>(data);
				// Save to DB
				if (objects is not null && objects.Any())
				{
					context.Set<ProductType>().AddRange(objects);
					context.SaveChanges();
				}
			}
			if (!context.Set<ProductEntity>().Any())
			{
				// Read from the file
				var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Seeding\products.json");
				// Convert to C# objects (Deserialization)
				var objects = JsonSerializer.Deserialize<List<ProductEntity>>(data);
				// Save to DB
				if (objects is not null && objects.Any())
				{
					context.Set<ProductEntity>().AddRange(objects);
					context.SaveChanges();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
		}

	}
}