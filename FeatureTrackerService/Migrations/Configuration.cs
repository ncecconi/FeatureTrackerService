namespace FeatureTrackerService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FeatureTrackerService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FeatureTrackerService.Models.FeatureTrackerServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FeatureTrackerService.Models.FeatureTrackerServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Authors.AddOrUpdate(x => x.Id,
        new Author() { Id = 1, Name = "Nick Cecconi" }
        
        );

            context.Features.AddOrUpdate(x => x.Id,
                new Feature()
                {
                    Id = 1,
                    AuthorId = 1,
                    FeatName = "SVI Endpoint Viewer",
                    Description = "Displays all current OLB test envs and the corresponding SVI endpoint.  Collected in real-time",
                    isComplete = true
                }
                );


        }
    }
}
