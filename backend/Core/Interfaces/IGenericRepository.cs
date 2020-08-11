using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityByIdAsync(int id);

        Task<IReadOnlyList<T>> GetEntitiesAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetEntitiesWithSpecAsync(ISpecification<T> spec);
    }
}
