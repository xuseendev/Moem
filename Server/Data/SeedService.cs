using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoeSystem.Server.Data;

namespace Server.Data
{
    public class SeedService
    {
        public SeedService(IServiceProvider sp) => Initialize(sp);
        private static void Initialize(IServiceProvider sp)
        {
            System.Console.WriteLine("Initializing Seed");
            using var scope = sp.CreateScope();
            try
            {
                var storage = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                //var fileConfig = scope.ServiceProvider.GetRequiredService<FileConfig>();
                //var hash = scope.ServiceProvider.GetRequiredService<IPasswordHash>();

                Initializer.Initialize(storage, configuration);
                // Initializer.InitializeBlock(fileConfig);

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while seeding the database {0}", e);
                throw;
            }

        }
    }
}