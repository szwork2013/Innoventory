namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Innoventory.Lotus.Database.DataEntities;

    internal sealed class Configuration : DbMigrationsConfiguration<Innoventory.Lotus.Database.DataEntities.InnoventoryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            Database.SetInitializer<InnoventoryDBContext>(null);
        }

        protected override void Seed(Innoventory.Lotus.Database.DataEntities.InnoventoryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
