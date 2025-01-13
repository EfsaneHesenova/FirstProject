using FirstProject.DAL.Contexts;
using FirstProject.DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Extensions
{
    public static class DALRegistration
    {
        public static void DalServices(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(ConnectionStr.GetconnectionStr());
            });
        }
    }
}
