using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Secure;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        ILikeService _likeService;
        IDislikeService _dislikeService;
        IFileService _fileService;

        public BlogManager(IBlogDal blogDal, ILikeService likeService, IDislikeService dislikeService, IFileService fileService)
        {
            _blogDal = blogDal;
            _likeService = likeService;
            _dislikeService = dislikeService;
            _fileService = fileService;
        }

        // [SecuredOperation("admin,blog.add")]
        [CacheRemoveAspect("IBlogService.Get")]
        // [ValidationAspect(typeof(BlogValidator))]
        [TransactionScopeAspect]
        public IResult Add(Blog blog, IFormFile imageFile)
        {
            var result = _fileService.Add(imageFile);
            blog.ImageFilePath = result.Data.FilePath;
            blog.ImageRootPath = result.Data.RootPath;
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        [SecuredOperation("admin,blog.delete")]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(), Messages.BlogsListed);
        }

        public IDataResult<List<Blog>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(b => b.UserId == userId), Messages.BlogsListed);
        }

        public IDataResult<List<Blog>> GetAllOrderByCreationDate()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().OrderByDescending(b => b.CreationDate).ToList(),
                Messages.BlogsListed);
        }

        public IDataResult<List<Blog>> GetAllOrderByPopulation()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().OrderByDescending(
                b => (GetLikeCountByBlogId(b.Id).Data - GetDislikeCountByBlogId(b.Id).Data)
                ).ToList(), Messages.BlogsListed);
        }

        public IDataResult<int> GetLikeCountByBlogId(int blogId)
        {
            return new SuccessDataResult<int>(_likeService.GetAllByBlogId(blogId).Data.Count, Messages.LikeCountListed);
        }

        public IDataResult<int> GetDislikeCountByBlogId(int blogId)
        {
            return new SuccessDataResult<int>(_dislikeService.GetAllByBlogId(blogId).Data.Count, Messages.DislikeCountListed);
        }

        [CacheAspect]
        public IDataResult<List<BlogDetailDto>> GetBlogDetails()
        {
            return new SuccessDataResult<List<BlogDetailDto>>(_blogDal.GetBlogDetails(), Messages.BlogsListed);
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(b => b.Id == id), Messages.BlogsListed);
        }

        [SecuredOperation("admin,blog.add")]
        [CacheRemoveAspect("IBlogService.Get")]
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }
    }
}
