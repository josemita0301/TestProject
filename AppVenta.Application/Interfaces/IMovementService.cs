using AppVenta.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Application.Interfaces
{
    public interface IMovementService<TEntity, TEntityId>
        : IAdd<TEntity>, IList<TEntity, TEntityId>
    {
        void RollbackMovement(TEntityId entityId);
    }
}
