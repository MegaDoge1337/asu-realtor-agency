using System.Data.Entity.Infrastructure;

namespace Realtors
{
    public class MigrationsContextFactory : IDbContextFactory<RealtorAgencyDbContext>
    {
        public RealtorAgencyDbContext Create()
        {
            return new RealtorAgencyDbContext();
        }
    }
}
