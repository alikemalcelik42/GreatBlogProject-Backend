using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.LileDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c => c.UserId == userId), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetAllByBlogId(int blogId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c => c.BlogId == blogId), Messages.CommentsListed);
        }

        public IDataResult<List<CommentDetailDto>> GetCommentDetails()
        {
            return new SuccessDataResult<List<CommentDetailDto>>(_commentDal.GetCommentDetails(), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetAllOrderByCreationDate()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll().OrderBy(c => c.CreationDate).ToList(),
                Messages.CommentsListed);
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == id), Messages.CommentsListed);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
