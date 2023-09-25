using Microsoft.EntityFrameworkCore;
using NewsApiProject.Models;

namespace NewsApiProject.DataAccessLayer
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<NewsCast> NewsCast { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<NewsFav> NewsFav { get; set; }
        public DbSet<NewsShare> NewsShare { get; set; }
        public DbSet<NewsSource> NewsSource { get; set; }
        public DbSet<NewsSubscriber> NewsSubscriber { get; set; }
        internal object Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
