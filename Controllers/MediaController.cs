using AQRS_import_and_export_archives.Models;
using AQRS_import_and_export_archives.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AQRS_import_and_export_archives.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IMediaRepository _repository;

        public MediaController(IMediaRepository repository) 
        { 
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Media>>> Get() 
        {
            return await _repository
                            .Get();
        }

        [HttpPost("import")]
        public async Task<ActionResult<List<Media>>> Import(IFormFile file)
        {
            var list = new List<Media>();


            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid File.");
            }

            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    Media media = new Media(line);
                    await _repository.Add(media);
                    list.Add(media);
                }
            }

            return list;
        }
    }
}
