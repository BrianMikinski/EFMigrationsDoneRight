using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World! Welcome to EF Migrations Done Right");

var blogContext = new BlogDbContext();

blogContext.Database.EnsureDeleted();
blogContext.Database.EnsureCreated();

// add post tags
var tagA = new Tag("DotNet 8");
var tagB = new Tag("EF Core");
blogContext.SaveChanges();

// add category
var category = blogContext.Categories.Add(new Category());
blogContext.SaveChanges();

// add post
var post = new Post();
blogContext.Add(post);
blogContext.SaveChanges();

var postTagA = new PostTag(post, tagA);
var postTagB = new PostTag(post, tagA);

blogContext.PostTags.AddRange(postTagA, postTagB);
blogContext.SaveChanges();

var results = blogContext.Posts.Where(p => true).ToList();

Console.WriteLine($"Total Count: {results.Count}");

public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<PostTag> PostTags { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostTag>()
            .HasIndex(t => new { t.PostId, t.TagId });

        modelBuilder.Entity<PostTag>()
        .HasOne(pt => pt.Post)
        .WithMany(p => p.PostTags)
        .HasForeignKey(pt => pt.PostId);

        modelBuilder.Entity<PostTag>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.PostTags)
            .HasForeignKey(pt => pt.TagId);
    }
}

public class Post
{
    public Post(string title = "EF Core is awesome!", string content = "Some cool EF Core stuff")
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
    }

    public Guid Id { get; private set; }

    [StringLength(50)]
    public string? Title { get; private set; }

    [StringLength(1000)]
    public string? Content { get; init; }

    public Guid? CategoryId { get; init; }

    public Category? Category { get; init; }

    public IEnumerable<PostTag>? PostTags { get; set; }
}

public class Category
{
    public Category(string name = "Software Engineering")
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; init; }

    [StringLength(50)]
    public string Name { get; init; }
}

public class PostTag
{
    public PostTag()
    {
        Id = Guid.NewGuid();
        Post = new Post();
        Tag = new Tag();
    }

    public PostTag(Post post, Tag tag)
    {
        Id = Guid.NewGuid();
        Post = post;
        PostId = Post.Id;
        Tag = tag;
        TagId = Tag.Id;
    }
    public Guid Id { get; set; }

    public Guid PostId { get; init; }

    public Post Post { get; init; }

    public Guid TagId { get; init; }

    public Tag Tag { get; init; }
}

public class Tag
{
    public Tag(string name = "EF Core")
    {
        Id = Guid.NewGuid();
        Name = name;
        PostTags = new List<PostTag>();
    }

    public Guid Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    public IEnumerable<PostTag> PostTags { get; set; }
}