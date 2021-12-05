using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;

        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public IResult Add(Like like)
        {
            _likeDal.Add(like);
            return new SuccessResult(Messages.LikeAdded);
        }

        public IResult Delete(Like like)
        {
            _likeDal.Delete(like);
            return new SuccessResult(Messages.LileDeleted);
        }

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

        public IResult Update(Like like)
        {
            _likeDal.Update(like);
            return new SuccessResult(Messages.LikeUpdated);
        }
    }
}
