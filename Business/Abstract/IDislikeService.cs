using Core.Utilities.Results.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IDislikeService
    {
        IDataResult<List<Dislike>> GetAll();
        IDataResult<List<Dislike>> GetAllByUserId(int userId);
        IDataResult<List<Dislike>> GetAllByBlogId(int blogId);
        IDataResult<Dislike> GetById(int id);
        IResult Add(Dislike dislike);
        IResult Update(Dislike dislike);
        IResult Delete(Dislike dislike);
    }
}
