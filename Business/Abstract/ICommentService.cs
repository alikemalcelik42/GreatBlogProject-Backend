using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetAllByUserId(int userId);
        IDataResult<List<Comment>> GetAllOrderByCreationDate();
        IDataResult<Comment> GetById(int id);
        IDataResult<List<CommentDetailDto>> GetCommentDetails();
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
    }
}
