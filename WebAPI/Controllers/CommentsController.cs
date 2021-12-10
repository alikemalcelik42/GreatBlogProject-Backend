using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAll();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _commentService.GetAllByUserId(userId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallorderbycreationdate")]
        public IActionResult GetAllOrderByCreationDate()
        {
            var result = _commentService.GetAllOrderByCreationDate();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _commentService.GetById(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getcommentdetails")]
        public IActionResult GetCommentDetails()
        {
            var result = _commentService.GetCommentDetails();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            var result = _commentService.Add(comment);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Comment comment)
        {
            var result = _commentService.Update(comment);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Comment comment)
        {
            var result = _commentService.Delete(comment);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
