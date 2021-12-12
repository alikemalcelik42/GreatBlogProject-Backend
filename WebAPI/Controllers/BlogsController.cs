using Business.Abstract;
using Business.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _blogService.GetAll();
            
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _blogService.GetAllByUserId(userId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallorderbycreationdate")]
        public IActionResult GetAllOrderByCreationDate()
        {
            var result = _blogService.GetAllOrderByCreationDate();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallorderbypopulation")]
        public IActionResult GetAllOrderByPopulation()
        {
            var result = _blogService.GetAllOrderByPopulation();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getlikecountbyblogid")]
        public IActionResult GetLikeCountByBlogId(int blogId)
        {
            var result = _blogService.GetLikeCountByBlogId(blogId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getdislikecountbyblogid")]
        public IActionResult GetDislikeCountByBlogId(int blogId)
        {
            var result = _blogService.GetDislikeCountByBlogId(blogId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _blogService.GetById(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getblogdetails")]
        public IActionResult GetBlogDetails()
        {
            var result = _blogService.GetBlogDetails();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] Blog blog, [FromForm] IFormFile imageFile)
        {
            var result = _blogService.Add(blog, imageFile);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] Blog blog, [FromForm] IFormFile imageFile)
        {
            var result = _blogService.Update(blog, imageFile);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Blog blog)
        {
            var result = _blogService.Delete(blog);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
