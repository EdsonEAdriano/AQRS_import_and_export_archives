using AQRS_import_and_export_archives.Models;

namespace AQRS_import_and_export_archives.Repositories
{
    public interface IMediaRepository
    {
        Task<List<Media>> Get();
    }
}
