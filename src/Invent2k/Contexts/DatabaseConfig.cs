using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Invent2k.Contexts
{
    internal class EfConfig : DbConfiguration
    {
        public EfConfig()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }

    }

    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }

}