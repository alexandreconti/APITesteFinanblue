namespace ApiTeste.Repositories;

public interface IRepository<T> where T : class
{
    List<T>? GetAll();
    T GetById(int id);
    void Add(T entity);
    void Delete(T entityToDelete);
    void Update(T entityToUpdate, T entity);
}