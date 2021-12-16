using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        [SecuredOperation("admin,editor,user,comment.add")]
        [CacheRemoveAspect("ICommentService.Get")]
        [ValidationAspect(typeof(CommentValidator))]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        [SecuredOperation("admin,editor,user,comment.delete")]
        [CacheRemoveAspect("ICommentService.Get")]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        [CacheAspect]
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

        [PerformanceAspect(3)]
        [CacheAspect]
        public IDataResult<List<CommentDetailDto>> GetCommentDetails()
        {
            return new SuccessDataResult<List<CommentDetailDto>>(_commentDal.GetCommentDetails(), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetAllOrderByCreationDate()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll().OrderByDescending(c => c.CreationDate).ToList(),
                Messages.CommentsListed);
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == id), Messages.CommentsListed);
        }

        [SecuredOperation("admin,editor,user,comment.update")]
        [CacheRemoveAspect("ICommentService.Get")]
        [ValidationAspect(typeof(CommentValidator))]
        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
