using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IRepositoryDetail<TEntity, TMovementId>
        : IAdd<TEntity>, ITransaction
    {
    }
}
