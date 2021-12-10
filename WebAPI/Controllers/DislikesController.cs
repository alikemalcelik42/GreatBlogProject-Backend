using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DislikesController : ControllerBase
    {
        IDislikeService _dislikeService;

        public DislikesController(IDislikeService dislikeService)
        {
            _dislikeService = dislikeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dislikeService.GetAll();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _dislikeService.GetAllByUserId(userId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyblogid")]
        public IActionResult GetAllByBlogId(int blogId)
        {
            var result = _dislikeService.GetAllByBlogId(blogId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _dislikeService.GetById(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Dislike dislike)
        {
            var result = _dislikeService.Add(dislike);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Dislike dislike)
        {
            var result = _dislikeService.Update(dislike);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Dislike dislike)
        {
            var result = _dislikeService.Delete(dislike);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
