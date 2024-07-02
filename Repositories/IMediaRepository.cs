using AQRS_import_and_export_archives.Models;
using System.Collections;

namespace AQRS_import_and_export_archives.Repositories
{
    public interface IMediaRepository
    {
        Task<List<Media>> Get();
        Task<Media> Add(Media media);
        Task<List<Media>> AddRange(List<Media> medias);
    }
}
