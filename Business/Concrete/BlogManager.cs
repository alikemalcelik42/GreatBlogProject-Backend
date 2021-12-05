using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(), Messages.CommentsListed);
        }

        public IDataResult<List<Blog>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(b => b.UserId == userId), Messages.CommentsListed);
        }

        public IDataResult<List<Blog>> GetAllOrderByCreationDate()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().OrderBy(b => b.CreationDate).ToList(),
                Messages.CommentsListed);
        }

        public IDataResult<List<Blog>> GetAllOrderByLikeCount()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().OrderBy(b => b.LikeCount).ToList(),
                Messages.CommentsListed);
        }

        public IDataResult<List<BlogDetailDto>> GetBlogDetails()
        {
            return new SuccessDataResult<List<BlogDetailDto>>(_blogDal.GetBlogDetails(), Messages.CommentsListed);
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(b => b.Id == id), Messages.CommentsListed);
        }

        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }
    }
}
