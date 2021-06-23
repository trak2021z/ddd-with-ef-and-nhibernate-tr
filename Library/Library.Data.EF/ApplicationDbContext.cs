using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.Data.EF
{
    public sealed class ApplicationDbContext : DbContext
    {
        private static readonly Type[] EnumerationTypes = { typeof(Book), typeof(Suffix) };
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Library;User Id = dbUser; Password=password;")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(x =>
            {
                x.ToTable("Members").HasKey(k => k.Id);
                x.Property(p => p.Id);
                x.Property(p => p.Email)
                    .HasConversion(p => p.Value, p => Email.Create(p).Value);
                x.OwnsOne(p => p.Name, p =>
                {
                    p.Property<long?>("NameSuffixId").HasColumnName("NameSuffixId");
                    p.Property(pp => pp.First).HasColumnName("FirstName");
                    p.Property(pp => pp.Last).HasColumnName("LastName");
                    p.HasOne(pp => pp.Suffix).WithMany().HasForeignKey("NameSuffixId").IsRequired(false);
                });
                x.HasOne(p => p.FavoriteBook).WithMany();
                x.HasMany(p => p.Borrowings).WithOne(p => p.CurrentBorrower)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });
            modelBuilder.Entity<Suffix>(x =>
            {
                x.ToTable("Suffix").HasKey(p => p.Id);
                x.Property(p => p.Id);
                x.Property(p => p.Name);
            });
            modelBuilder.Entity<Book>(x =>
            {
                x.ToTable("Books").HasKey(k => k.Id);
                x.Property(p => p.Id);
                x.Property(p => p.Title);
                x.OwnsOne(p => p.AuthorName, p =>
                {
                    p.Property<long?>("NameSuffixId").HasColumnName("NameSuffixId");
                    p.Property(pp => pp.First).HasColumnName("FirstName");
                    p.Property(pp => pp.Last).HasColumnName("LastName");
                    p.HasOne(pp => pp.Suffix).WithMany().HasForeignKey("NameSuffixId").IsRequired(false);
                });
                x.HasMany(p => p.Categories).WithMany(p => p.Books);
            });
            modelBuilder.Entity<Borrowing>(x =>
            {
                x.ToTable("Borrowings").HasKey(k => k.Id);
                x.Property(p => p.Id);
                x.HasOne(p => p.CurrentBorrower).WithMany(p => p.Borrowings);
                x.HasOne(p => p.Book).WithMany();
                x.Property(p => p.Date);
            });
            modelBuilder.Entity<Category>(x =>
            {
                x.ToTable("Categories").HasKey(k => k.Id);
                x.Property(p => p.Id);
                x.Property(p => p.Name);
                x.HasMany(p => p.Books).WithMany(p => p.Categories);
            });
        }

        public override int SaveChanges()
        {
            //IEnumerable<EntityEntry> enumerationEntries = ChangeTracker.Entries()
            //    .Where(x => EnumerationTypes.Contains(x.Entity.GetType()));

            //foreach (EntityEntry enumerationEntry in enumerationEntries)
            //{
            //    enumerationEntry.State = EntityState.Unchanged;
            //}

            int result = base.SaveChanges();

            return result;
        }

    }
}
