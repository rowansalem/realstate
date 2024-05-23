using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Entity;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace Data
{
    public class DbEntities : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbEntities(DbContextOptions<DbEntities> options) : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbEntities`1" /> class.
        /// </summary>
        protected DbEntities()
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<SalesOffice> SalesOffices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyOwner> PropertyOwners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the Identity primary keys to be of type Guid
            builder.Entity<IdentityUser<Guid>>().Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Entity<IdentityRole<Guid>>().Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Entity<IdentityUserLogin<Guid>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            builder.Entity<IdentityUserRole<Guid>>().HasKey(r => new { r.UserId, r.RoleId });
            builder.Entity<IdentityUserToken<Guid>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            builder.Entity<IdentityRoleClaim<Guid>>().HasKey(c => c.Id);
            builder.Entity<IdentityUserClaim<Guid>>().HasKey(c => c.Id);

            builder.Entity<SalesOffice>()
                .HasOne(s => s.Manager)
                .WithOne()
                .HasForeignKey<SalesOffice>(s => s.ManagedByEmployeeId);

            builder.Entity<SalesOffice>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.SalesOffice)
                .HasForeignKey(e => e.SalesOfficeId);

            builder.Entity<Property>()
                  .HasMany(p => p.PropertyOwners)
                  .WithOne(po => po.Property)
                  .HasForeignKey(po => po.PropertyId);

            builder.Entity<Owner>()
                .HasMany(o => o.PropertyOwners)
                .WithOne(po => po.Owner)
                .HasForeignKey(po => po.OwnerId);

            // Seed data for Address
            builder.Entity<Address>().HasData(
                new Address { Id = Guid.Parse("417fa29a-5a30-487d-a994-dd3d3060f021"), AddressLine = "123 Main St", City = "Texas City", State = "Texas", ZipCode = "12345" },
                new Address { Id = Guid.Parse("4eccc760-57ce-483a-82cd-644caf6d28d9"), AddressLine = "123 Victore St", City = "Alexandria", State = "Alex", ZipCode = "12345" }
            );

            // Seed data for SalesOffice
            builder.Entity<SalesOffice>().HasData(
                new SalesOffice { Id = Guid.Parse("8e56f097-eec5-4b0e-bed5-aa8766212b67"), SalesOfficeName = "Downtown Office", AddressId = Guid.Parse("417fa29a-5a30-487d-a994-dd3d3060f021"), ManagedByEmployeeId = Guid.Parse("64d6ee5f-e553-43a8-8c47-d7a9f447c614") },
                new SalesOffice { Id = Guid.Parse("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), SalesOfficeName = "New Cairo Office", AddressId = Guid.Parse("4eccc760-57ce-483a-82cd-644caf6d28d9"), ManagedByEmployeeId = Guid.Parse("64d6ee5f-e553-43a8-8c47-d7a9f447c614") }
            );

            // Seed data for Employees
            builder.Entity<Employee>().HasData(
                new Employee { Id = Guid.Parse("64d6ee5f-e553-43a8-8c47-d7a9f447c614"), EmpFirstName = "John", EmpLastName = "Doe", SalesOfficeId = Guid.Parse("8e56f097-eec5-4b0e-bed5-aa8766212b67"), DateOfBirth = new DateTime(1980, 1, 1), Age = 40 },
                new Employee { Id = Guid.Parse("0197f334-8f09-41f3-8ec8-f94a9d7d63e7"), EmpFirstName = "Jane", EmpLastName = "Smith", SalesOfficeId = Guid.Parse("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), DateOfBirth = new DateTime(1990, 1, 1), Age = 30 }
            );

            // Seed data for Properties
            builder.Entity<Property>().HasData(
                new Property { Id = Guid.Parse("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), ListPrice = 250000, Status = "For Sale", NoOfBedrooms = 3, NoOfBathrooms = 2, City = "Anytown", SalesOfficeId = Guid.Parse("8e56f097-eec5-4b0e-bed5-aa8766212b67") },
                new Property { Id = Guid.Parse("958de581-e471-4079-b232-3d6900acfd25"), ListPrice = 300000, Status = "For Sale", NoOfBedrooms = 4, NoOfBathrooms = 3, City = "Anytown", SalesOfficeId = Guid.Parse("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23") }
            );

            // Seed data for Owner
            builder.Entity<Owner>().HasData(
                new Owner { Id = Guid.Parse("47a0f14a-b028-403f-8ba3-a1489d8e266e"), OwnerFirstName = "Jane", OwnerLastName = "Smith" }
            );

            // Seed data for Prop_Owner_Table
            builder.Entity<PropertyOwner>().HasData(
                new PropertyOwner { Id = Guid.Parse("9247b51c-c626-44bd-b7b8-414a321e1485"), PropertyId = Guid.Parse("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), PercentOwned = 100, OwnerId = Guid.Parse("47a0f14a-b028-403f-8ba3-a1489d8e266e") },
                new PropertyOwner { Id = Guid.Parse("4e0c5b04-b174-4230-b39c-5ee6aa966313"), PropertyId = Guid.Parse("958de581-e471-4079-b232-3d6900acfd25"), PercentOwned = 100, OwnerId = Guid.Parse("47a0f14a-b028-403f-8ba3-a1489d8e266e") }
            );

            // Seed data for Users
            builder.Entity<User>().HasData(
                new User { Id = Guid.Parse("e354a5cd-5d4a-464e-a356-7cc434c5913d"), UserEmail = "user@example.com" }
            );


        }
    }
}
