using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Locacao.Infra.SqlServer.Data
{
    public class LocacaoDbContextFactory : IDesignTimeDbContextFactory<LocacaoDbContext>
    {
        public LocacaoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocacaoDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
               .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new LocacaoDbContext(optionsBuilder.Options);

        }
    }
}
