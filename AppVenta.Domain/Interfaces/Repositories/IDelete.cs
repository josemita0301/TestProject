using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface IDelete<TEntityId>
    {
        void Delete(TEntityId entityId);
    }
}
