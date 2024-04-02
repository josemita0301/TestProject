using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain.Interfaces.Repositories
{
    public interface ITransaction
    {
        void SaveAllChanges();
    }
}
