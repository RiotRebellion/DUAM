using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUAM.Data.Interfaces
{
    internal interface IRepository<T> where T : class, new()
    {
        IQueryable<T> Items { get; }

        bool GetConnectionState();
    }
}
