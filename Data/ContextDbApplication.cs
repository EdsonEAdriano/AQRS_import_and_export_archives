using AQRS_import_and_export_archives.Models;
using Microsoft.EntityFrameworkCore;

namespace AQRS_import_and_export_archives.Data
{
    public class ContextDbApplication : DbContext
    {
        public ContextDbApplication(DbContextOptions<ContextDbApplication> options) : base(options)
        {
        }

        DbSet<Media> Medias { get; set; }
    }
}
