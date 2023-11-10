using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to EF Migrations Done Right");

var blogContext = new BlogDbContext();

public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    // public DbSet<PostTag> PostTags { get; set; }

    // public DbSet<Category> Categories { get; set; }

    // public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;");
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<PostTag>()
    //         .HasIndex(t => new { t.PostId, t.TagId });

    //     modelBuilder.Entity<PostTag>()
    //     .HasOne(pt => pt.Post)
    //     .WithMany(p => p.PostTags)
    //     .HasForeignKey(pt => pt.PostId);

    //     modelBuilder.Entity<PostTag>()
    //         .HasOne(pt => pt.Tag)
    //         .WithMany(t => t.PostTags)
    //         .HasForeignKey(pt => pt.TagId);
    // }
}

public class Post
{
    // public static (Post, IEnumerable<PostTag>) NewPostWithCategoriesAndTags(Category category, IEnumerable<Tag> tags)
    // {
    //     var post = new Post()
    //     {
    //         Id = Guid.NewGuid(),
    //         Category = category,
    //         Title = "EF Core is awesome!",
    //         Content = "Some ramblings on EF Core",
    //     };

    //     var postTags = new List<PostTag>();

    //     foreach (var tag in tags)
    //     {
    //         postTags.Add(new PostTag()
    //         {
    //             TagId = tag.Id,
    //             PostId = post.Id
    //         });
    //     }

    //     return (post, postTags);
    // }

    public Post()
    {
        Id = Guid.NewGuid();
        Title = "EF Core is awesome!";
        Content = "Some cool EF Core stuff";
    }

    public Guid Id { get; private set; }

    [StringLength(50)]
    public string? Title { get; private set; }

    [StringLength(1000)]
    public string? Content { get; init; }

    public Guid? CategoryId { get; init; }

    //public Category? Category { get; init; }

    //public IEnumerable<PostTag>? PostTags { get; set; }
}

// public class Category
// {
//     public Category()
//     {
//         Id = Guid.NewGuid();
//         Name = "Software Engineering";
//     }

//     public Guid Id { get; init; }

//     [StringLength(50)]
//     public string Name { get; init; }
// }

// public class PostTag
// {
//     public PostTag()
//     {
//         Post = new();
//         Tag = new();
//     }
//     public Guid Id { get; set; }

//     public Guid PostId { get; init; }

//     public Post Post { get; init; }

//     public Guid TagId { get; init; }
//     public Tag Tag { get; init; }
// }

// public class Tag
// {
//     public Tag()
//     {
//         Name = "Ef Core";
//         PostTags = new List<PostTag>();
//     }

//     public Guid Id { get; set; }

//     [StringLength(50)]
//     public string Name { get; set; }

//     public IEnumerable<PostTag> PostTags { get; set; }
// }