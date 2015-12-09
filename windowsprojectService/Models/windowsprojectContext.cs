using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using windowsprojectService.DataObjects;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace windowsprojectService.Models
{
    public class windowsprojectContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public windowsprojectContext() : base(connectionStringName)
        {
        }
        //public DbSet<Trip> Trips { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tripsss> Tripsss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public System.Data.Entity.DbSet<windowsprojectService.DataObjects.User> Users { get; set; }

        //public System.Data.Entity.DbSet<windowsprojectService.DataObjects.Tripsss> Tripssses { get; set; }
    }

}
