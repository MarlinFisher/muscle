namespace Muscle
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : DbContext
    {
        private const string IdProp = @"Id";
        private const string CreatedAtProp = @"CreatedAt";
        private const string UpdatedAtProp = @"UpdatedAt";

        public DataContext()
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var exercises = modelBuilder.Entity<Exercise>().ToTable("Exercises");
            exercises.HasMany(x => x.Aliases).WithMany();

            var muscles = modelBuilder.Entity<Muscle>().ToTable("Muscles");
            muscles.HasMany(x => x.Aliases).WithMany();

            var heads = modelBuilder.Entity<Head>().ToTable("Heads");
            heads.HasMany(x => x.Aliases).WithMany();

            var equipment = modelBuilder.Entity<Equipment>().ToTable("Equipment");
            equipment.HasMany(x => x.Aliases).WithMany();

            var regions = modelBuilder.Entity<Region>().ToTable("Regions");
            var names = modelBuilder.Entity<Alias>().ToTable("Aliases");

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                var now = DateTimeOffset.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        var current = entry.CurrentValues;
                        this.TrySetPropValue(current, DataContext.IdProp, Guid.NewGuid().ToString());
                        this.TrySetPropValue(current, DataContext.CreatedAtProp, now);
                        this.TrySetPropValue(current, DataContext.UpdatedAtProp, now);
                        break;
                    case EntityState.Modified:
                        this.TrySetPropValue(entry.CurrentValues, DataContext.UpdatedAtProp, now);
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChangesAsync();
        }


        private void TrySetPropValue(DbPropertyValues propValues, string propName, object propValue)
        {
            if (!propValues.PropertyNames.Contains(propName))
            {
                return;
            }
            propValues[propName] = propValue;
        }
    }
}