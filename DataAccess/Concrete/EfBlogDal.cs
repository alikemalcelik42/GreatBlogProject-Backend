using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Concrete
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, GreatBlogContext>, IBlogDal
    {
        public List<BlogDetailDto> GetBlogDetails()
        {
            using(GreatBlogContext context = new GreatBlogContext())
            {
                var result = from b in context.Blogs
                             join u in context.Users
                             on b.UserId equals u.Id
                             select new BlogDetailDto()
                             {
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 UserEmail = u.Email,
                                 Title = b.Title,
                                 Content = b.Content,
                                 ImagePath = b.ImagePath,
                                 LikeCount = b.LikeCount,
                                 CreationDate = b.CreationDate
                             };

                return result.ToList();
            }
        }
    }
}
