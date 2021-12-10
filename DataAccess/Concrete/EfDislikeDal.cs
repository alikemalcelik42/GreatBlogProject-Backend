using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfDislikeDal : EfEntityRepositoryBase<Dislike, GreatBlogContext>, IDislikeDal
    {

    }
}
