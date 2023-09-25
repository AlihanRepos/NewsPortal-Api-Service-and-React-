using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApiProject.Models;
using NewsApiProject.Repository;

namespace NewsApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private NewsCommentRepository _newsCommentRepository;
        public CommentController(NewsCommentRepository newsCommentRepository)
        {
            _newsCommentRepository = newsCommentRepository;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] NewsComment newsComment)
        {
            try
            {
                if (newsComment != null)
                {
                    newsComment.UserId = 1;
                    _newsCommentRepository.Add(newsComment);
                    return Ok("NewsCast added successfully.");
                }

                return BadRequest("Invalid JSON data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



    }
}
