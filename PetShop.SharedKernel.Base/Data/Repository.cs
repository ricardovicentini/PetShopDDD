using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.SharedKernel.Base.Data
{
    public abstract class Repository<TEntity> : IDisposable where TEntity : class,ITableModel
    {
        public abstract IUnitOfWork UnityOfWork { get; }
        public DbContext dbContext { get; }
        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> Entity => _dbSet;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this._dbSet = dbContext.Set<TEntity>();
        }

        #region "Queries"
        public async Task<TEntity> PorId(Guid id)
        {

            return await dbContext.Set<TEntity>().Where(x => x.ID == id).SingleAsync();

        }

        public virtual async Task<IEnumerable<TEntity>> Todos(Expression<Func<TEntity, bool>> filtro = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (noTracking)
                query = query.AsNoTracking();

            if (filtro != null)
                query = query.Where(filtro);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (take != null)
                query.Take((int)take);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return  await query.ToListAsync();
        }
        #endregion "Queries"

        public async Task Adicionar(TEntity model)
        {
            await dbContext.AddAsync(model);
        }

        public void Atualizar(TEntity model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Remover(TEntity model)
        {
            dbContext.Remove(model);
        }

        public virtual void Dispose()
        {
            this.dbContext.Dispose();
            this.Dispose();
        }
    }
}
