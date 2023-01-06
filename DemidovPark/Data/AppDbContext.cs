namespace DemidovPark.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class AppDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<Mileage> Mileages => Set<Mileage>();
        public DbSet<Maintenance> Maintenances => Set<Maintenance>();
        public DbSet<MainHistory> MainHistories => Set<MainHistory>();
        public DbSet<SegmentItem> Segments => Set<SegmentItem>();
        public DbSet<DistanceItem> Distances => Set<DistanceItem>();
        public DbSet<Request> Requests => Set<Request>();
        public DbSet<Photo> Photos => Set<Photo>();

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.EnsureCreated();
            Database.Migrate();
        }

        public override int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            var added = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity)
                .Where(e => e.State == EntityState.Added);

            var modified = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity)
                .Where(e => e.State == EntityState.Modified);

            foreach (var entity in added)
                ((BaseEntity)entity.Entity).CreatedDate = DateTime.Now;

            foreach (var entity in modified)
                ((BaseEntity)entity.Entity).UpdatedDate = DateTime.Now;


            return await base.SaveChangesAsync(token);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.LogTo(Console.WriteLine, LogLevel.Warning);
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(_configuration["SchemaName"]);

            var adminRole = new IdentityRole { Id = "33fbf4a6-31b3-4285-bbea-5929f98be3a3", Name = "admin", NormalizedName = "admin".ToUpper() };
            var managerRole = new IdentityRole { Id = "36888aa0-fddb-46e4-a016-a687b7d4d538", Name = "manager", NormalizedName = "manager".ToUpper() };
            builder.Entity<IdentityRole>().HasData(adminRole, managerRole);

            var hasher = new PasswordHasher<IdentityUser>();

            var adminName = "Director1";
            var adminUser = new IdentityUser
            {
                Id = "519774b7-dd1b-430a-8b25-eef507ca1091",
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "519774b7-dd1b-430a-8b25-eef507ca1091",
                LockoutEnabled = false
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Dpdirector2022");

            builder.Entity<IdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = adminUser.Id });

            var type1 = new SegmentItem { Id = 1, Name = "Инвестор" };
            var type2 = new SegmentItem { Id = 2, Name = "ДемидовПарк" };
            var type3 = new SegmentItem { Id = 3, Name = "Премиум" };
            var type4 = new SegmentItem { Id = 4, Name = "Комфорт" };
            builder.Entity<SegmentItem>().HasData(type1, type2, type3, type4);

            var dist1 = new DistanceItem { Id = 1, Name = "Город" };
            var dist2 = new DistanceItem { Id = 2, Name = "Город и область" };
            var dist3 = new DistanceItem { Id = 3, Name = "За пределы области" };
            var dist4 = new DistanceItem { Id = 4, Name = "Смешанная" };
            builder.Entity<DistanceItem>().HasData(dist1, dist2, dist3, dist4);

            base.OnModelCreating(builder);
        }
    }
}