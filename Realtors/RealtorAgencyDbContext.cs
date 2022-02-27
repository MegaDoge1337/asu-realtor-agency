using System.Data.Entity;
using Realtors.Entities;

namespace Realtors
{
    public class RealtorAgencyDbContext : DbContext
    {
        public RealtorAgencyDbContext() : base("DbConnectionString") {}

        public DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriteria { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
