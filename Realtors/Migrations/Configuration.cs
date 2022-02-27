namespace Realtors.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bogus;
    using Realtors.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Realtors.RealtorAgencyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Realtors.RealtorAgencyDbContext context)
        {
            var random = new Random();

            /* Seeding data values */

            var criteria = new List<string>();
            criteria.Add("Location");
            criteria.Add("Square");
            criteria.Add("Layout");
            criteria.Add("Type");
            criteria.Add("Structure");
            criteria.Add("Floor");

            var _districtsCount = 10;
            var _buildingMaterialsCount = 5;
            var _realtorsCount = 5;
            var _realEstateCount = 10;

            /* Seeding process */

            Console.WriteLine("Creating Districts...");
            for (int districtsCount = context.Districts.Count(); districtsCount < _districtsCount; districtsCount++) 
            {
                var districtEntity = new Faker<District>()
                    .RuleFor(d => d.Title, d => d.Address.State())
                    .Generate();

                context.Districts.AddOrUpdate(districtEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Building Materials...");
            for (int buildingMaterialsCount = context.BuildingMaterials.Count(); buildingMaterialsCount < _buildingMaterialsCount; buildingMaterialsCount++)
            {
                var buildingMaterialEntity = new Faker<BuildingMaterial>()
                    .RuleFor(b => b.Title, b => b.Commerce.ProductMaterial())
                    .Generate();

                context.BuildingMaterials.AddOrUpdate(buildingMaterialEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Realtors...");
            for (int realtorsCount = context.Realtors.Count(); realtorsCount < _realtorsCount; realtorsCount++)
            {
                var realtorEntity = new Faker<Realtor>()
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.Phone, r => r.Person.Phone)
                    .Generate();


                context.Realtors.AddOrUpdate(realtorEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Evaluation Criteria...");
            for (int criteriaCount = context.EvaluationCriteria.Count(); criteriaCount < 5; criteriaCount++)
            {
                var criteriaEntity = new EvaluationCriteria();
                criteriaEntity.Title = criteria[criteriaCount];

                context.EvaluationCriteria.AddOrUpdate(criteriaEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Real Estate...");
            for (int realEstateCount = context.RealEstate.Count(); realEstateCount < _realEstateCount; realEstateCount++) 
            {
                var realEstateEntity = new Faker<RealEstate>()
                    .RuleFor(r => r.Address, r => r.Address.StreetAddress())
                    .RuleFor(r => r.Amount, r => random.Next(1000000, 10000000))
                    .RuleFor(r => r.Description, r => r.Lorem.Sentence())
                    .RuleFor(r => r.Date, r => r.Date.Past())
                    .Generate();

                var districtId = random.Next(1, context.Districts.Count());
                realEstateEntity.District = context.Districts.Where(d => d.Id == districtId).FirstOrDefault();
                var buildingMaterialId = random.Next(1, context.BuildingMaterials.Count());
                realEstateEntity.BuildingMaterial = context.BuildingMaterials.Where(d => d.Id == buildingMaterialId).FirstOrDefault();
                realEstateEntity.Floor = random.Next(1, 10);
                realEstateEntity.RoomsCount = random.Next(1, 5);
                realEstateEntity.Type = random.Next(1, 4);
                realEstateEntity.Status = random.Next(0, 2);
                realEstateEntity.Square = random.Next(30, 101);

                context.RealEstate.AddOrUpdate(realEstateEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Sales...");
            foreach (var realEstate in context.RealEstate.Where(r => r.Status == 0)) 
            {
                var saleEntity = new Faker<Sale>()
                    .RuleFor(s => s.Date, s => s.Date.Future(1, realEstate.Date))
                    .RuleFor(s => s.Amount, s => random.Next(1000000, 10000000))
                    .Generate();

                saleEntity.RealEstate = realEstate;
                var realtorId = random.Next(1, context.Realtors.Count());
                saleEntity.Realtor = context.Realtors.Where(r => r.Id == realtorId).FirstOrDefault();

                context.Sales.AddOrUpdate(saleEntity);
            }
            context.SaveChanges();

            Console.WriteLine("Creating Evaluations...");
            foreach (var evaluationCriteria in context.EvaluationCriteria) 
            {
                foreach (var realEstate in context.RealEstate) 
                {
                    var evaluationEntity = new Evaluation();

                    evaluationEntity.RealEstate = realEstate;
                    evaluationEntity.Date = realEstate.Date;
                    evaluationEntity.EvaluationCriteria = evaluationCriteria;
                    evaluationEntity.Rating = random.Next(0, 6);

                    context.Evaluations.AddOrUpdate(evaluationEntity);
                }
            }
            context.SaveChanges();
        }
    }
}
