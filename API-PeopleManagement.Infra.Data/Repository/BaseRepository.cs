using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using API_PeopleManagement.Infra.Data.Context;

namespace API_PeopleManagement.Infra.Data.Repository
{
    public class BaseRepository<TEntity>(PeopleManagementContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Create(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return obj;
        }

        public void Delete(Guid id)
        {
            context.Set<TEntity>().Remove(Get(id));
            context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll() =>
            context.Set<TEntity>().AsQueryable();

        public TEntity Get(Guid id) =>
            context.Set<TEntity>().Find(id);
    }
}
