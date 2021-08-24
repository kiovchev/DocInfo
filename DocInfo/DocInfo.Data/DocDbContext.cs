namespace DocInfo.Data
{
    using DocInfo.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DocDbContext : IdentityDbContext<ApplicationUser>
    {
        public DocDbContext(DbContextOptions<DocDbContext> options) : base(options){}

        //public DbSet<Profile> Profiles { get; set; }

        //public DbSet<Document> Documents { get; set; }

        //public DbSet<Publication> Publications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Profile>()
            //    .HasOne(a => a.ApplicationUser)
            //    .WithOne(p => p.Profile)
            //    .HasForeignKey<Profile>(a => a.ApplicationUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
