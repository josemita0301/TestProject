using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Domain.Interfaces;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TEntityId> 
        : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>, ITransaction
    {

    }
}
