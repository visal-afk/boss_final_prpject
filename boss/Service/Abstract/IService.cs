namespace boss.Service.Abstract;

public interface IService<T>
{
    void Add(T item);
    void Delete(int id);
    void Update(int id,T item);
    T GetById(int id);
    List<T> GetAll();
}
