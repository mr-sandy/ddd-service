using System;

namespace Domain.Repositories;

public interface IRepository<TItem, TKey>
{
    TItem? Get(TKey id);

    void Add(TItem item);
}
