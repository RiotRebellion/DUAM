using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUAM.Data.Repositories
{
    class UserRepository<User>
    {
        private readonly DeloDb _db;
        private readonly bool _connectionState;
        private string query = """
            USE DELO_DB
SELECT SURNAME_PATRON, MAX(DATE_TIME) as max_date
FROM CONNECTION_LOG
RIGHT JOIN USER_CL ON CONNECTION_LOG.DELO_USER = USER_CL.CLASSIF_NAME
WHERE DELETED LIKE 0
AND SURNAME_PATRON LIKE '%%'
 GROUP BY SURNAME_PATRON
 order by max_date desc
            """

        public UserRepository(DeloDb db)
        {
            _db = db;
            _connectionState = _db.Database.CanConnect();
        }

        public IQueryable<User> Items => _db.Users.FromSqlRaw(query);

        public bool GetConnectionState() => _connectionState;
    }
}
