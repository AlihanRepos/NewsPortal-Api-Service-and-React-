using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApiProject.DataAccessLayer;
using NewsApiProject.Models;
using NewsApiProject.Repository;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace NewsApiProject.Controllers
{
    [ApiController]
    [Route("newscast/[controller]")]
    public class NewsController : ControllerBase
    {
        private NewsCastRepository _newsCastRepository;
        public NewsController(NewsCastRepository newsCastRepository)
        {
            _newsCastRepository = newsCastRepository;
        }



        [HttpGet]
        [Route("GetCategory")]

        public IActionResult GetCategory()
        {
            var category = _newsCastRepository.GetCategory();

            return Ok(category);
        }



        [HttpGet]
        [Route("GetMainAllNews")]

        public IActionResult GetMainAllNews()
        {
            var newsCasts = _newsCastRepository.GetMainAllNews();

            return Ok(newsCasts);
        }


        [HttpGet]
        [Route("GetMainOrderFavs")]

        public IActionResult GetMainOrderFavs()

        {
            var newsCasts = _newsCastRepository.GetMainOrderFavs();
            return Ok(newsCasts);
        }






        [HttpGet("details/{newcastid}")]

        public IActionResult GetMainNewsDetails(int newcastid)

        {
            var newsCasts = _newsCastRepository.GetMainNewsDetails(newcastid);
            return Ok(newsCasts);

        }
        [HttpGet("category/{newscategoryid}")]

        public IActionResult GetMainAllCategoryNews(int newscategoryid)

        {
            var newsCasts = _newsCastRepository.GetMainAllCategoryNews(newscategoryid);
            return Ok(newsCasts);
        }


        [HttpPost]
        public IActionResult AddNewsCast([FromBody] NewsCast newsCast)
        {
            try
            {
                if (newsCast != null)
                {
                    _newsCastRepository.Add(newsCast);
                    return Ok("NewsCast added successfully.");
                }

                return BadRequest("Invalid JSON data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }






        [HttpPut("{id}")]
        public IActionResult Update(int id, NewsCast newsCast)
        {
            newsCast.NewsCastId = id;
            _newsCastRepository.Update(newsCast);
            return Ok();
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _newsCastRepository.Delete(id);
            return Ok();

        }

    }

}
