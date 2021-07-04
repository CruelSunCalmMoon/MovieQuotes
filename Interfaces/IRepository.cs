using System.Collections.Generic;

namespace MovieQuotes.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T BringBackId(int id);
        void Insert(T identity);
        void Exclude(int id);
        void Update(int id, T identity);
        int NextId();
    }
}