namespace ChallengeBank.Infra.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T Find(int id);
    }
}
