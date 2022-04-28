using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class cousework3kursContext : DbContext
    {
        public cousework3kursContext()
        {
        }

        public cousework3kursContext(DbContextOptions<cousework3kursContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<BookPublish> BookPublishes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publishing> Publishings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security = True; Server=LAPTOP-7UIHGPKE\\SQLEXPRESS; Initial Catalog=cousework 3 kurs;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIO");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TitleBook)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.ToTable("bookAuthors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK_bookAuthors_Author");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK_bookAuthors_Title");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("bookGenre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdGenre).HasColumnName("idGenre");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK_bookGenre_Title");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.IdGenre)
                    .HasConstraintName("FK_bookGenre_Gente");
            });

            modelBuilder.Entity<BookPublish>(entity =>
            {
                entity.ToTable("bookPublish");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdPublish).HasColumnName("idPublish");

                entity.Property(e => e.YearOfPublication)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookPublishes)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK_Year_Title");

                entity.HasOne(d => d.IdPublishNavigation)
                    .WithMany(p => p.BookPublishes)
                    .HasForeignKey(d => d.IdPublish)
                    .HasConstraintName("FK_Year_publishing");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre1)
                    .HasMaxLength(10)
                    .HasColumnName("Genre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Publishing>(entity =>
            {
                entity.ToTable("publishing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PublishingHouse)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
