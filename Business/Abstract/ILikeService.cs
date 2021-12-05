using Core.Utilities.Results.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ILikeService
    {
        IDataResult<List<Like>> GetAll();
        IDataResult<List<Like>> GetAllByUserId(int userId);
        IDataResult<List<Like>> GetAllByBlogId(int blogId);
        IDataResult<Like> GetById(int id);
        IResult Add(Like like);
        IResult Update(Like like);
        IResult Delete(Like like);
    }
}
