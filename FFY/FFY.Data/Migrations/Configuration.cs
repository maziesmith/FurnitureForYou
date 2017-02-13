using System.Data.Entity.Migrations;

namespace FFY.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FFYContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FFYContext context)
        {
        }
    }
}