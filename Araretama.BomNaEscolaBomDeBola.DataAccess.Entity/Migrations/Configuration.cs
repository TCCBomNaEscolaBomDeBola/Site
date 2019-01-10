namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context.BomNaEscolaBomDeBolaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context.BomNaEscolaBomDeBolaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
