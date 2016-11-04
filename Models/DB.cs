using Microsoft.EntityFrameworkCore;

public partial class DB : DbContext {

    public DB(DbContextOptions context): base(context){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    public DbSet<Gram> Grams { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
}