using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using API_PeopleManagement.Infra.Data.Context;

namespace API_PeopleManagement.Infra.Data.Repository
{
    public class BaseRepository<TEntity>(PeopleManagementContext Context) : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PeopleManagementContext Context = Context;

        public void Create(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Context.Set<TEntity>().Remove(Get(id));
            Context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll() =>
            Context.Set<TEntity>().AsQueryable();

        public TEntity Get(Guid id) =>
            Context.Set<TEntity>().Find(id);
    }
}
