using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwitchPlay.Identity;

namespace SwitchPlay.Data
{
    public class SwitchPlayContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>,
    AppUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public SwitchPlayContext(DbContextOptions<SwitchPlayContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<StudioCategory> StudioCategories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty,
                UserType = "Admini i Lojrave"
            });

            builder.Entity<AppUserRole>().HasData(new AppUserRole
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });


            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 1,
                Name = "PC",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 2,
                Name = "Playstation",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 3,
                Name = "Xbox",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 4,
                Name = "Nintendo",
            });

            builder.Entity<Platform>().HasData(new Platform
            {
                Id = 5,
                Name = "Mobile",
            });

            // Lidhja e Kategorive me Studiot N-N

            builder.Entity<StudioCategory>().HasKey(e => new { e.CategoryId, e.StudioId });

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Studio)
                .WithMany(s => s.StudioCategories)
                .HasForeignKey(sc => sc.StudioId);

            builder.Entity<StudioCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.StudioCategories)
                .HasForeignKey(sc => sc.CategoryId);

            // Lidhja e Lojerave me Kategorite N-N

            builder.Entity<GameCategory>().HasKey(e => new { e.CategoryId, e.GameId });

            builder.Entity<GameCategory>()
                .HasOne(sc => sc.Game)
                .WithMany(s => s.GameCategories)
                .HasForeignKey(sc => sc.GameId);

            builder.Entity<GameCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.GameCategories)
                .HasForeignKey(sc => sc.CategoryId);



            // Lidhja e Lojerave me Platformat N-N

            builder.Entity<GamePlatform>().HasKey(e => new { e.PlatformId, e.GameId });

            builder.Entity<GamePlatform>()
                .HasOne(sc => sc.Game)
                .WithMany(s => s.GamePlatforms)
                .HasForeignKey(sc => sc.GameId);

            builder.Entity<GamePlatform>()
                .HasOne(sc => sc.Platform)
                .WithMany(c => c.GamePlatforms)
                .HasForeignKey(sc => sc.PlatformId);


            // Lidhja e Lojerave me Studion N-1

            builder.Entity<Game>()
                .HasOne(g => g.Studio)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.StudioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
       
    }
}
