using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApiProject.Repository;

namespace NewsApiProject.Controllers
{
    [Route("news/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private NewsSourceRepository _newsSourceRepository;
        public SourceController(NewsSourceRepository newsSourceRepository)
        {
            _newsSourceRepository = newsSourceRepository;
        }
        [HttpGet]
        [Route("GetSource")]
        public IActionResult GetSource()
        {
            var sources = _newsSourceRepository.GetAll();

            return Ok(sources);
        }
    }
}
