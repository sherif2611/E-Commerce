﻿namespace Domain.Contracts;
public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
{
	void Add(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntity entity);
	Task<TEntity?> GetAsync(TKey key);
	Task<IEnumerable<TEntity>> GetAllAsync();
}