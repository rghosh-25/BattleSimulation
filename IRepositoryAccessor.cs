using System;

public interface IRepository<T>
{
    void Add(T item);
    void Remove(T item);
    T Get(string name);
    IEnumerable<T> GetAll();
    void Update(T item);
}