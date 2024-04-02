using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IEdit<TEntity>
    {
        void Edit(TEntity entity);
    }
}
