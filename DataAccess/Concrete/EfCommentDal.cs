using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, GreatBlogContext>, ICommentDal
    {
        public List<CommentDetailDto> GetCommentDetails()
        {
            using (GreatBlogContext context = new GreatBlogContext())
            {
                var result = from c in context.Comments
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CommentDetailDto()
                             {
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 UserEmail = u.Email,
                                 Content = c.Content,
                                 CreationDate = c.CreationDate
                             };

                return result.ToList();
            }
        }
    }
}
