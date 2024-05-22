using Data.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Core;
using System.Reflection;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbEntities DbContext;
        public UnitOfWork( DbEntities context)
        {
            this.DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void SaveChanges()
        {
            UpdateBaseProperty();
            UpdateSoftDeleteStatuses();
            DbContext.SaveChanges();

        }

        private void UpdateBaseProperty()
        {
            var x = DbContext.ChangeTracker.Entries();
            List<EntityEntry> addedEntities = DbContext.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Added).ToList();
            List<EntityEntry> updatedEntities = DbContext.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Modified).ToList();

            addedEntities.ForEach(entity =>
            {           

                entity.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = DateTime.UtcNow;
            });
            updatedEntities.ForEach(entity =>
            {
                entity.Property(nameof(BaseEntity.ModifiedAt)).CurrentValue = DateTime.UtcNow;
            });
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in DbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.CurrentValues["IsDeleted"] != null)
                            entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        if (entry.CurrentValues["IsDeleted"] != null)
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                        }
                        break;
                }
            }
        }
    }
}
