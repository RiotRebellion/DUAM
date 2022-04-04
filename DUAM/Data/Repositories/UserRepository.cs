using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUAM.Models;
using DUAM.Data.Interfaces;

namespace DUAM.Data.Repositories
{
    

    class UserRepository : DbRepository<User>
    {
        private string query =
            "SELECT SURNAME_PATRON as FullName, MAX(DATE_TIME) as LastAccess " +
            "FROM CONNECTION_LOG " +
            "RIGHT JOIN USER_CL ON CONNECTION_LOG.DELO_USER = USER_CL.CLASSIF_NAME " +
            "WHERE DELETED LIKE 0 " +
            "AND SURNAME_PATRON LIKE '%%' " +
            "AND SURNAME_PATRON NOT LIKE '%[123456789]%' " +
            "AND SURNAME_PATRON NOT LIKE '%[b-Z]%' " +
            "GROUP BY SURNAME_PATRON " +
            "order by LastAccess desc ";

        public UserRepository(DeloDb db)
            :base(db)
        {      
        }

        public override IQueryable<User> Items => base._db.Users.FromSqlRaw(query);
    }
}
