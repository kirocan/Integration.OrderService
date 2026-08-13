using Microsoft.EntityFrameworkCore;

namespace Integration.OrderService.Data
{
    public static class DbInitializer
    {
        public static void MigrateAndSeed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.Migrate();
        }
    }
}
