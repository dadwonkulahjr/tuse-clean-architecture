using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGentelellaCleanArchitecture.Infrastructure.Persistence;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository;
using MyGentelellaCleanArchitecture.Infrastructure.Services.Repository.IRepository;

namespace MyGentelellaCleanArchitecture.Infrastructure.ConfigureServices
{
    public static class AddInfrastructureService
    {
        public static IServiceCollection AddInfrastructureServiceToPipeline(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
