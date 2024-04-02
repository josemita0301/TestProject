using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IList<TEntity, TEntityId>
    {
        List<TEntity> List();

        TEntity SelectById(TEntityId entityId);
    }
}
