using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoExpress.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoExpress.IOC
{
    public static class Dependence
    {
        public static void inyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbphotoExpressContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("sqlString"));
            });
        }
    }
}
