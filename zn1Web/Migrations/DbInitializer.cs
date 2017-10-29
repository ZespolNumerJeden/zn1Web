using System.Data.Entity;

namespace zn1Web.Migrations
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
    }
}