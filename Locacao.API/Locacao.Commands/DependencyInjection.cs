using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Locacao.Commands
{
    public static class DependencyInjection
    {
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection));
        }
    }
}
