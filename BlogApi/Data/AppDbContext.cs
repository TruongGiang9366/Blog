using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            var article = modelBuilder.Entity<Article>();
            var category = modelBuilder.Entity<Category>();
            var tag = modelBuilder.Entity<Tag>();
            var comment = modelBuilder.Entity<Comment>();

            user.ToTable("tblUser");
            user.HasMany<Article>(u => u.Articles)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId);

            user.HasMany<Comment>(u => u.Comments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId);

            article.ToTable("tblArticle");
            article.HasOne<User>(a => a.Author)
            .WithMany(u => u.Articles)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

            article.HasOne<Category>(a => a.Category)
            .WithMany(c => c.Articles)
            .HasForeignKey(a => a.CategoryId)
            .IsRequired().OnDelete(DeleteBehavior.NoAction);

            article.HasMany<Tag>(a => a.Tags)
            .WithMany(t => t.Articles)
            .UsingEntity(at => at.ToTable("ArticleTag"));

            article.HasMany<Comment>(a => a.Comments)
            .WithOne(c => c.Article)
            .HasForeignKey(c => c.ArticleId);

            article.HasMany<User>(a => a.Likers);

            category.ToTable("tbCategory");

            category.HasMany<Article>(c => c.Articles)
            .WithOne(a => a.Category)
            .HasForeignKey(c => c.CategoryId);

            category.HasOne<User>(c => c.CreatedBy)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.CreatedById);

            tag.ToTable("TblTag");

            tag.HasMany<Article>(t => t.Articles)
            .WithMany(a => a.Tags)
            .UsingEntity(at => at.ToTable("ArticleTag"));

            comment.HasOne<User>(c => c.Author)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.AuthorId);

            comment.HasOne<Article>(c => c.Article)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.ArticleId);
            
        }
    }
}