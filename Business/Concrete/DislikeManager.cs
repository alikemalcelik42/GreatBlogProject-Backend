using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Secure;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class DislikeManager : IDislikeService
    {
        IDislikeDal _dislikeDal;

        public DislikeManager(IDislikeDal dislikeDal)
        {
            _dislikeDal = dislikeDal;
        }

        [SecuredOperation("admin,editor,user,dislike.add")]
        [CacheRemoveAspect("IDislikeService.Get")]
        public IResult Add(Dislike dislike)
        {
            var result = BusinessRules.Run(SameUserCannotDislikeSameBlogMoreThanOnce(dislike));

            if (result != null)
                return result;

            _dislikeDal.Add(dislike);
            return new SuccessResult(Messages.DislikeAdded);
        }

        [SecuredOperation("admin,editor,user,dislike.delete")]
        [CacheRemoveAspect("IDislikeService.Get")]
        public IResult Delete(Dislike dislike)
        {
            _dislikeDal.Delete(dislike);
            return new SuccessResult(Messages.DislikesListed);
        }

        [CacheAspect]
        public IDataResult<List<Dislike>> GetAll()
        {
            return new SuccessDataResult<List<Dislike>>(_dislikeDal.GetAll(), Messages.DislikesListed);
        }

        public IDataResult<List<Dislike>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Dislike>>(_dislikeDal.GetAll(d => d.UserId == userId), Messages.DislikesListed);
        }

        public IDataResult<List<Dislike>> GetAllByBlogId(int blogId)
        {
            return new SuccessDataResult<List<Dislike>>(_dislikeDal.GetAll(d => d.BlogId == blogId), Messages.DislikesListed);
        }

        public IDataResult<Dislike> GetById(int id)
        {
            return new SuccessDataResult<Dislike>(_dislikeDal.Get(d => d.Id == id), Messages.DislikesListed);
        }

        [SecuredOperation("admin,editor,user,dislike.update")]
        [CacheRemoveAspect("IDislikeService.Get")]
        public IResult Update(Dislike dislike)
        {
            _dislikeDal.Update(dislike);
            return new SuccessResult(Messages.DislikeUpdated);
        }

        private IResult SameUserCannotDislikeSameBlogMoreThanOnce(Dislike dislike)
        {
            var result = GetAllByBlogId(dislike.BlogId);

            foreach (var i in result.Data)
            {
                if (i.UserId == dislike.UserId)
                    return new ErrorResult(Messages.SameUserCannotDislikeSameBlogMoreThanOnce);
            }

            return new SuccessResult();
        }
    }
}
