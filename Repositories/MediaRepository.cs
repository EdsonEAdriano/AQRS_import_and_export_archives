using AQRS_import_and_export_archives.Data;
using AQRS_import_and_export_archives.Models;
using Microsoft.EntityFrameworkCore;

namespace AQRS_import_and_export_archives.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ContextDbApplication _context;

        public MediaRepository(ContextDbApplication context)
        {
            _context = context;
        }

        public async Task<Media> Add(Media media)
        {
            await _context
                    .Set<Media>()
                    .AddAsync(media);

            await _context
                    .SaveChangesAsync();

            return media;
        }

        public async Task<List<Media>> Get()
        {
            return await _context
                     .Set<Media>()
                     .ToListAsync();
        }
    }
}
