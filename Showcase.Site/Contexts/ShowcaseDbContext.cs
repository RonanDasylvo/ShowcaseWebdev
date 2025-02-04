using Microsoft.EntityFrameworkCore;
using Showcase.Models;

namespace Showcase.Contexts;

public class ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<ItemListModel> ItemListModels { get; set; }
}