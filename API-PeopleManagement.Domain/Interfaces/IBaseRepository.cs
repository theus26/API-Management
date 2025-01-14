using API_PeopleManagement.Domain.Entities;

namespace API_PeopleManagement.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(Guid id);

        IQueryable<TEntity> GetAll();

        TEntity Get(Guid id);
    }
}
