using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _likeService.GetAll();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _likeService.GetAllByUserId(userId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyblogid")]
        public IActionResult GetAllByBlogId(int blogId)
        {
            var result = _likeService.GetAllByBlogId(blogId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _likeService.GetById(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Like like)
        {
            var result = _likeService.Add(like);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Like like)
        {
            var result = _likeService.Update(like);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Like like)
        {
            var result = _likeService.Delete(like);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
