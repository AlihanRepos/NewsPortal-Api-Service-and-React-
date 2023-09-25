using NewsApiProject.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NewsApiProject.Models;


namespace NewsApiProject.Repository
{
    public class NewsCategoryRepository
    {
        private NewsContext db;

        public NewsCategoryRepository(NewsContext _db) { this.db = _db; }

        public bool Add(NewsCategory entity)
        {
            NewsCategory newsCategoryCategory = db.NewsCategory.FirstOrDefault(x => x.Category == entity.Category);


            if (newsCategoryCategory == null)
            {
                db.NewsCategory.Add(entity);
                db.SaveChanges();
                return true;
            }
            else { return false; }

        }

        public bool Delete(int id)
        {
            bool exist = db.NewsCategory.Any(x => x.NewsCategoryId == id);

            if (exist)
            {
                db.NewsCategory.Find(id).IsActive = false;
                db.SaveChanges();
                return true;

            }
            else { return false; }
        }

        public NewsCategory Get(int id)
        {
            NewsCategory NewsCategory = db.NewsCategory.Find(id);
            return NewsCategory;
        }

        public List<NewsCategory> GetAll()
        {
            List<NewsCategory> NewsCategoryList = db.NewsCategory.Where(x => x.IsActive == true).ToList();
            return NewsCategoryList;
        }

        public bool Update(NewsCategory entity)
        {

            var NewsCategory = db.NewsCategory.Find(entity.NewsCategoryId);
            bool status = false;
            if (NewsCategory != null)
            {
                NewsCategory.Category = String.IsNullOrWhiteSpace(entity.Category) ? NewsCategory.Category : entity.Category;
                NewsCategory.DateCategory = DateTime.Now;
                NewsCategory.IsActive = true;
                db.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}
