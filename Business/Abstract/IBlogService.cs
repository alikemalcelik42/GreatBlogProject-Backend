using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        IResult Add(Blog blog, IFormFile imageFile);
        IResult Update(Blog blog);
        IResult UpdateWithFile(Blog blog, IFormFile imageFile);
        IResult Delete(Blog blog);
    }
}
