using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IAdd<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
