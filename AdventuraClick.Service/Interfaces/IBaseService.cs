namespace AdventuraClick.Service.Interfaces
{
    public interface IBaseService<T, TSearch> where T : class where TSearch : class
    {
        Task<IEnumerable<T>> Get(TSearch search = null);
        T GetById(int id);
    }
}
