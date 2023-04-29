﻿using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IGenericRepositoryAsync<T> where T : class
{
    //Task<T> GetByIdAsync(Guid id);
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<bool> IsUniqueAsync(Expression<Func<T, bool>> predicate);
}
