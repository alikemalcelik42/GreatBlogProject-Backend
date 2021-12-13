using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Secure;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;
        Lazy<IDislikeService> _dislikeService;

        public LikeManager(ILikeDal likeDal, Lazy<IDislikeService> dislikeService)
        {
            _likeDal = likeDal;
            _dislikeService = dislikeService;
        }

        // [SecuredOperation("admin,editor,user,like.add")]
        [CacheRemoveAspect("ILikeService.Get")]
        public IResult Add(Like like)
        {
            var result = BusinessRules.Run(SameUserCannotLikeSameBlogMoreThanOnce(like),
                SameUserCannotBothLikeAndDislike(like));

            if (result != null)
                return result;

            _likeDal.Add(like);
            return new SuccessResult(Messages.LikeAdded);
        }

        // [SecuredOperation("admin,editor,user,like.delete")]
        [CacheRemoveAspect("ILikeService.Get")]
        public IResult Delete(Like like)
        {
            _likeDal.Delete(like);
            return new SuccessResult(Messages.LikeDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Like>> GetAll()
        {
            return new SuccessDataResult<List<Like>>(_likeDal.GetAll(), Messages.LikesListed);
        }

        public IDataResult<List<Like>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Like>>(_likeDal.GetAll(l => l.UserId == userId), Messages.LikesListed);
        }

        public IDataResult<List<Like>> GetAllByBlogId(int blogId)
        {
            return new SuccessDataResult<List<Like>>(_likeDal.GetAll(l => l.BlogId == blogId), Messages.LikesListed);
        }

        public IDataResult<Like> GetById(int id)
        {
            return new SuccessDataResult<Like>(_likeDal.Get(l => l.Id == id), Messages.LikesListed);
        }

        // [SecuredOperation("admin,editor,user,like.update")]
        [CacheRemoveAspect("ILikeService.Get")]
        public IResult Update(Like like)
        {
            var result = BusinessRules.Run(SameUserCannotLikeSameBlogMoreThanOnce(like),
                SameUserCannotBothLikeAndDislike(like));

            if (result != null)
                return result;

            _likeDal.Update(like);
            return new SuccessResult(Messages.LikeUpdated);
        }

        private IResult SameUserCannotLikeSameBlogMoreThanOnce(Like like)
        {
            var result = GetAllByBlogId(like.BlogId);

            foreach(var i in result.Data)
            {
                if(i.UserId == like.UserId)
                    return new ErrorResult(Messages.SameUserCannotLikeSameBlogMoreThanOnce);
            }

            return new SuccessResult();
        }

        private IResult SameUserCannotBothLikeAndDislike(Like like)
        {
            var result = _dislikeService.Value.GetAllByBlogId(like.BlogId);

            foreach (var i in result.Data)
            {
                if (i.UserId == like.UserId)
                    return new ErrorResult(Messages.SameUserCannotBothLikeAndDislike);
            }

            return new SuccessResult();
        }
    }
}
