using API_PeopleManagement.Domain.Entities;

namespace API_PeopleManagement.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(Guid id);

        IQueryable<TEntity> GetAll();

        TEntity Get(Guid id);
    }
}
