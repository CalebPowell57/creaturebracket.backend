using Db;
using Model.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
using Model.Db.Interfaces;

namespace Service
{
    public class DataService<T> where T : DataModel
    {
        protected CreatureBracketContext _context { get; private set; }
        protected IMapper _mapper { get; private set; }

        protected DbSet<T> _dbSet => _context.Set<T>();

        public DataService (CreatureBracketContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<T> GetById(long id)
        {
            var model = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);

            return model;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = _dbSet.AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var models = await query.ToListAsync();

            return models;
        }

        public void Upsert<D>(D dto) where D : IUpdate
        {
            var model = _mapper.Map<T>(dto);

            Upsert(model);
        }

        public void Upsert(T model)
        {
            //if (model.Id == 0)
            //{
            //    model.CreatedBy = "calebpowell57";
            //    model.CreatedAt = DateTime.UtcNow;
            //}

            if (model.Id == 0)
            {
                _context.Add(model);
            }
            else
            {
                _context.Update(model);
            }

        }

        public void Upsert<D>(IEnumerable<D> models) where D : IUpdate
        {
            foreach (var model in models)
            {
                Upsert(model);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}