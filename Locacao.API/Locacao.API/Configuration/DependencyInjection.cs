using Locacao.Domain.Repositories;
using Locacao.Infra.SqlServer.UoW;

namespace Locacao.API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IIdentityManager, IdentityManager>();
        }

    }
}
