using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IRepositoryMovement<TEntity, TEntityId>
        : IAdd<TEntity>, IList<TEntity, TEntityId>, ITransaction
    {
        void RollbackSale(TEntityId entityId);
    }
}
