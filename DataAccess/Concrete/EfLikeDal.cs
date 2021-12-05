using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfLikeDal : EfEntityRepositoryBase<Like, GreatBlogContext>, ILikeDal
    {

    }
}
