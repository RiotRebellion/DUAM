using DUAM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUAM.Services
{
    static class DbServiceRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<DeloDb>(opt =>
            {
                var type = configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определен тип БД");
                        
                    case "MSSQL":
                        opt.UseSqlServer(configuration.GetConnectionString(type));
                        break;

                    default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");

                }
            });
    }
}
