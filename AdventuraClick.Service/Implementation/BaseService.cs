using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class BaseService<TModel, TDatabase, TSearch> : IBaseService<TModel, TSearch> where TModel : class
       where TDatabase : class where TSearch : BaseSearchObject
    {
        public readonly AdventuraClickInitContext _context;
        public readonly IMapper _mapper;

        public BaseService(AdventuraClickInitContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IQueryable<TDatabase> AddFilter(IQueryable<TDatabase> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDatabase> AddInclude(IQueryable<TDatabase> query, TSearch search = null)
        {
            return query;
        }

        public virtual async Task<IEnumerable<TModel>> Get(TSearch search = null)
        {
            var entity = _context.Set<TDatabase>().AsQueryable();

            entity = AddFilter(entity, search);
            entity = AddInclude(entity, search);

            var list = entity.ToList();
            var mapped = _mapper.Map<IList<TModel>>(list);
            return mapped;
        }


        public virtual TModel GetById(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TDatabase>().Find(id));
        }

    }
}
