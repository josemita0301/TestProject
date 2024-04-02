using AppVenta.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppVenta.Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityId>
        :IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>
    {
    }
}
