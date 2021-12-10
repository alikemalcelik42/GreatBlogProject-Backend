using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetAllByUserId(int userId);
        IDataResult<List<Blog>> GetAllOrderByCreationDate();
        IDataResult<List<Blog>> GetAllOrderByPopulation();
        IDataResult<int> GetLikeCountByBlogId(int blogId);
        IDataResult<int> GetDislikeCountByBlogId(int blogId);
        IDataResult<Blog> GetById(int id);
        IDataResult<List<BlogDetailDto>> GetBlogDetails();
        IResult Add(Blog blog);
        IResult Update(Blog blog);
        IResult Delete(Blog blog);
    }
}
