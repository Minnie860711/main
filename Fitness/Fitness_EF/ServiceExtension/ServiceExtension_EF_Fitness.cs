using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Fitness_EF.Interface;
using Fitness_EF.Interface.ITableRespository;
using Fitness_EF.Repositories.Tablerepository;
using Fitness_EF.Repositories;
using Aplus_EF.Repositories;
using Fitness_EF.DbContextEF;

namespace Fitness_EF.ServiceExtension
{
    /// <summary>
    /// 服務擴充
    /// </summary>
    public static class ServiceExtension_EF_Fitness
    {
        /// <summary>
        /// DI注入服務
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDIServices_ByFitnessEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext_Fitness>(options =>
            {
                // 設定連線字串，依「appsettings.json」檔案內的ConnectionStrings Name抓取
                options.UseSqlServer(configuration.GetConnectionString("Main_DB"));
            });
            services.AddScoped<IUnitOfWork_Fitness, UnitOfWork_Fitness>();
            services.AddScoped<IMember_Fitness, Member_Fitness>();
            return services;
        }
    }
}
