using DUAM.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUAM.Data.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DeloDb _db;
        private readonly DbSet<T> _set;
        private readonly bool _connectionState;

        public DbRepository(DeloDb db)
        {
            _db = db;
            _set = db.Set<T>();
            _connectionState = _db.Database.CanConnect();
        }

        public virtual IQueryable<T> Items => _set;

        public bool GetConnectionState() => _connectionState;
    }
}
