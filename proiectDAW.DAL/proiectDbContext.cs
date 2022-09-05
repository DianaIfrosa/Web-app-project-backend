using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL
{
    public class proiectDbContext: IdentityDbContext<
        User,
        Role,
        int, //cheia folosita pt aceste clase 
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public proiectDbContext(DbContextOptions<proiectDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DIYIdea> DIYIdeas { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<IdeaMaterial> MaterialsDIYIdeas { get; set; }
        public DbSet<PresentationVideo> PresentationVideos{ get; set; }
        public object IdeaMaterial { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //adaug logger pt a vedea query-urile in sql 
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many
            modelBuilder.Entity<Category>()
                .HasMany(di => di.DIYIdeas)
                .WithOne(c => c.Category);

            // One to One
            modelBuilder.Entity<DIYIdea>()
                .HasOne(pv => pv.PresentationVideo)
                .WithOne(di => di.DIYIdea);

            // Many to Many
            // pk compusa din MaterialId si IdeaId
            modelBuilder.Entity<IdeaMaterial>().HasKey(x => new {x.MaterialId, x.IdeaId });

            modelBuilder.Entity<IdeaMaterial>()
                .HasOne(di => di.DIYIdea)
                .WithMany(im => im.MaterialsDIYIdeas)
                .HasForeignKey(iid => iid.IdeaId);

            modelBuilder.Entity<IdeaMaterial>()
                .HasOne(m => m.Material)
                .WithMany(im => im.MaterialsDIYIdeas)
                .HasForeignKey(mid => mid.MaterialId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
