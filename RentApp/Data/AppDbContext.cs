namespace RentApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public partial class AppDbContext : IdentityDbContext
    {
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

        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.EnsureCreated();
            Database.Migrate();
        }

        public override int SaveChanges() => throw new NotImplementedException();

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
            base.OnModelCreating(builder);
        }

    }
}