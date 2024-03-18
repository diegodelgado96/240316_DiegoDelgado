using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoExpress.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoExpress.Utility;
using PhotoExpress.BLL.Services.Contratos;
using PhotoExpress.BLL.Services;
using PhotoExpress.DAL.Repositorios.Contrato;
using PhotoExpress.DAL.Repositorios;
using PhotoExpress.Model;

namespace PhotoExpress.IOC
{
    public static class Dependence
    {
        public static void inyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbphotoExpressContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("sqlString"));
            });

            services.AddScoped<IGenericRepository<Evento>, GenericRepository<Evento>>();
            services.AddScoped<IGenericRepository<ModificacionEvento>, GenericRepository<ModificacionEvento>>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IModificacionEventoService, ModificacionEventoService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
