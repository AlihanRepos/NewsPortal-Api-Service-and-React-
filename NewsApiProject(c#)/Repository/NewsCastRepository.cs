using NewsApiProject.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NewsApiProject.Models;

namespace NewsApiProject.Repository
{
    public class NewsCastRepository
    {
        private  NewsContext _db;

        public NewsCastRepository(NewsContext db) {  this._db = db; }
        public bool Add(NewsCast entity)
        {
            NewsCast newsCastTitle = _db.NewsCast.FirstOrDefault(x => x.Title == entity.Title);
            NewsSource newsSourceId = _db.NewsSource.FirstOrDefault(x => x.NewsSourceId == entity.NewsSourceId);
            NewsCategory newsCategoryId =_db.NewsCategory.FirstOrDefault(x => x.NewsCategoryId == entity.NewsCategoryId);


            if (newsCastTitle == null && newsSourceId != null && newsCategoryId != null)
            {
                _db.NewsCast.Add(entity);
                _db.SaveChanges();
                return true;
            }
            else { return false; }

        }

        public bool Delete(int id)
        {
            bool exist = _db.NewsCast.Any(x => x.NewsCastId == id);

            if (exist)
            {
                _db.NewsCast.Find(id).IsActive = false;
                _db.SaveChanges();
                return true;

            }
            else { return false; }
        }

        public NewsCast Get(int id)
        {
            NewsCast NewsCast = _db.NewsCast.Find(id);
            return NewsCast;
        }

        public List<NewsCast> GetAll()
        {
            var newsCastList = _db.NewsCast.Include(x=>x.NewsCategory).ToList();

            return newsCastList;
        }
        public List<NewsCategory> GetCategory()
        {
            var newsCastList = _db.NewsCategory.ToList();

            return newsCastList;
        }

        public bool Update(NewsCast entity)
        {

            var NewsCast = _db.NewsCast.Find(entity.NewsCastId);
            bool status = false;
            if (NewsCast != null)
            {
                NewsCast.Title = String.IsNullOrWhiteSpace(entity.Title) ? NewsCast.Title : entity.Title;
                NewsCast.Text = String.IsNullOrWhiteSpace(entity.Text) ? NewsCast.Text : entity.Text;
                NewsCast.MultimediaUrl = String.IsNullOrWhiteSpace(entity.MultimediaUrl) ? NewsCast.MultimediaUrl : entity.MultimediaUrl;
                NewsCast.NewsDate = DateTime.Now;
                NewsCast.IsActive = true;
                NewsCast.NewsSourceId = (_db.NewsSource.Any(x => x.NewsSourceId == entity.NewsSourceId)) ? entity.NewsSourceId : NewsCast.NewsSourceId;
                NewsCast.NewsCategoryId = (_db.NewsCategory.Any(x => x.NewsCategoryId == entity.NewsCategoryId)) ? entity.NewsCategoryId : NewsCast.NewsCategoryId;
                _db.SaveChanges();
                status = true;
            }
            return status;
        }

        public IEnumerable<object> GetMainAllNews()
        {
            var query = from cast in _db.NewsCast
                        join cate in _db.NewsCategory on cast.NewsCategoryId equals cate.NewsCategoryId
                        join source in _db.NewsSource on cast.NewsSourceId equals source.NewsSourceId
                        join comment in _db.NewsComment on cast.NewsCastId equals comment.NewsCastId into commentJoin
                        from comment in commentJoin.DefaultIfEmpty()
                        join user in _db.User on comment.UserId equals user.UserId into userJoin
                        from user in userJoin.DefaultIfEmpty()
                        group new { cast, comment, cate, source, user } by new { cast.Title, cast.Text } into groupedCast
                        select new
                        {
                            Title = groupedCast.Key.Title,
                            Text = groupedCast.Key.Text,
                            NewsCastId = groupedCast.FirstOrDefault().cast.NewsCastId,
                            MultimediaUrl = groupedCast.FirstOrDefault().cast.MultimediaUrl,
                            Category = groupedCast.FirstOrDefault().cate.Category,
                            CorpationName = groupedCast.FirstOrDefault().source.CorpationName,
                            NewsSourceId = groupedCast.FirstOrDefault().source.NewsSourceId,
                            Comments = groupedCast.Select(gc => new
                            {
                                Comment = gc.comment != null ? gc.comment.Comment : null,
                                UserName = gc.user != null ? gc.user.Name : null
                            }).ToList()
                        };
            return query.ToList();
        }
        public IEnumerable<object> GetMainNewsDetails(int newscastid)
        {
            var query = from cast in _db.NewsCast
                        where cast.NewsCastId == newscastid
                        join cate in _db.NewsCategory on cast.NewsCategoryId equals cate.NewsCategoryId
                        join source in _db.NewsSource on cast.NewsSourceId equals source.NewsSourceId
                        join comment in _db.NewsComment on cast.NewsCastId equals comment.NewsCastId into commentJoin
                        from comment in commentJoin.DefaultIfEmpty()
                        join user in _db.User on comment.UserId equals user.UserId into userJoin
                        from user in userJoin.DefaultIfEmpty()
                        group new { cast, comment, cate, source, user } by new { cast.Title, cast.Text } into groupedCast
                        select new
                        {
                            Title = groupedCast.Key.Title,
                            Text = groupedCast.Key.Text,
                            NewsCastId = groupedCast.FirstOrDefault().cast.NewsCastId,
                            MultimediaUrl = groupedCast.FirstOrDefault().cast.MultimediaUrl,
                            Category = groupedCast.FirstOrDefault().cate.Category,
                            CorpationName = groupedCast.FirstOrDefault().source.CorpationName,
                            NewsSourceId = groupedCast.FirstOrDefault().source.NewsSourceId,
                            Comments = groupedCast.Select(gc => new
                            {
                                Comment = gc.comment != null ? gc.comment.Comment : null,
                                UserName = gc.user != null ? gc.user.Name : null
                            }).ToList()
                        };
            return query.ToList();
        }
        public IEnumerable<object> GetMainAllCategoryNews(int newscategoryid)
        {
            var query = from cast in _db.NewsCast
                        where cast.NewsCategoryId == newscategoryid
                        join cate in _db.NewsCategory on cast.NewsCategoryId equals cate.NewsCategoryId
                        join source in _db.NewsSource on cast.NewsSourceId equals source.NewsSourceId
                        join comment in _db.NewsComment on cast.NewsCastId equals comment.NewsCastId into commentJoin
                        from comment in commentJoin.DefaultIfEmpty()
                        join user in _db.User on comment.UserId equals user.UserId into userJoin
                        from user in userJoin.DefaultIfEmpty()
                        group new { cast, comment, cate, source, user } by new { cast.Title, cast.Text } into groupedCast
                        select new
                        {
                            Title = groupedCast.Key.Title,
                            Text = groupedCast.Key.Text,
                            NewsCastId = groupedCast.FirstOrDefault().cast.NewsCastId,
                            MultimediaUrl = groupedCast.FirstOrDefault().cast.MultimediaUrl,
                            Category = groupedCast.FirstOrDefault().cate.Category,
                            CorpationName = groupedCast.FirstOrDefault().source.CorpationName,
                            NewsSourceId = groupedCast.FirstOrDefault().source.NewsSourceId,
                            Comments = groupedCast.Select(gc => new
                            {
                                Comment = gc.comment != null ? gc.comment.Comment : null,
                                UserName = gc.user != null ? gc.user.Name : null
                            }).ToList()
                        };
            return query.ToList();
        }

        public IEnumerable<object> GetMainOrderFavs()
        {
            var query = (from cast in _db.NewsCast
                         join cate in _db.NewsCategory on cast.NewsCategoryId equals cate.NewsCategoryId
                         join source in _db.NewsSource on cast.NewsSourceId equals source.NewsSourceId
                         join comment in _db.NewsComment on cast.NewsCastId equals comment.NewsCastId into commentJoin
                         from comment in commentJoin.DefaultIfEmpty()
                         join user in _db.User on comment.UserId equals user.UserId into userJoin
                         from user in userJoin.DefaultIfEmpty()
                         join fav in _db.NewsFav on cast.NewsCastId equals fav.NewsCastId into favJoin
                         from fav in favJoin.DefaultIfEmpty()
                         where fav.IsActive == true
                         group new { cast, comment, cate, source, user, fav } by new { cast.Title, cast.Text } into groupedCast
                         //let favoriteCount = groupedCast.Select(gc => gc.fav != null ? gc.fav.NewsFavId : (int?)null).Distinct().Count(f => f != null)
                         //orderby favoriteCount descending, groupedCast.Max(gc => gc.cast.NewsDate) descending
                         select new
                         {
                             Title = groupedCast.Key.Title,
                             Text = groupedCast.Key.Text,
                             NewsCastId = groupedCast.FirstOrDefault().cast.NewsCastId,
                             MultimediaUrl = groupedCast.FirstOrDefault().cast.MultimediaUrl,
                             Category = groupedCast.FirstOrDefault().cate.Category,
                             CorpationName = groupedCast.FirstOrDefault().source.CorpationName,
                             NewsSourceId = groupedCast.FirstOrDefault().source.NewsSourceId,
                             NewsDate = groupedCast.FirstOrDefault().cast.NewsDate,
                             //FavoriteCount = favoriteCount,
                             Comments = groupedCast.Select(gc => new
                             {
                                 Comment = gc.comment != null ? gc.comment.Comment : null,
                                 UserName = gc.user != null ? gc.user.Name : null
                             }).ToList()
                         });

            return query.ToList();





        }


        public List<NewsCast> SearchNews(string search)
        {
            var results = _db.NewsCast.Where(n => n.Title.Contains(search)).ToList();
            return results;
        }



      

        public IEnumerable<object> SourceGetMainAllNews(int id)
        {
            var query = from cast in _db.NewsCast
                        join cate in _db.NewsCategory on cast.NewsCategoryId equals cate.NewsCategoryId
                        join source in _db.NewsSource on cast.NewsSourceId equals source.NewsSourceId
                        where source.NewsSourceId == id
                        join comment in _db.NewsComment on cast.NewsCastId equals comment.NewsCastId into commentJoin
                        from comment in commentJoin.DefaultIfEmpty()
                        join user in _db.User on comment.UserId equals user.UserId into userJoin
                        from user in userJoin.DefaultIfEmpty()
                        group new { cast, comment, cate, source, user } by new { cast.Title, cast.Text } into groupedCast
                        select new
                        {
                            Title = groupedCast.Key.Title,
                            Text = groupedCast.Key.Text,
                            NewsCastId = groupedCast.FirstOrDefault().cast.NewsCastId,
                            MultimediaUrl = groupedCast.FirstOrDefault().cast.MultimediaUrl,
                            NewsCategoryId = groupedCast.FirstOrDefault().cate.NewsCategoryId,
                            CorpationName = groupedCast.FirstOrDefault().source.CorpationName,
                            NewsSourceId = groupedCast.FirstOrDefault().source.NewsSourceId,
                            Comments = groupedCast.Select(gc => new
                            {
                                Comment = gc.comment != null ? gc.comment.Comment : null,
                                UserName = gc.user != null ? gc.user.Name : null
                            }).ToList()
                        };
            return query.ToList();
        }


    }
}
