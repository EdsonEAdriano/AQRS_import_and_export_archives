using AQRS_import_and_export_archives.Models;
using AQRS_import_and_export_archives.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
