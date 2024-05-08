using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AQRS_import_and_export_archives.Models
{
    [Table("t_media")]
    public class Media
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public required string Genre { get; set; }
        [StringLength(30)]
        public required string Category { get; set; }
        [StringLength(250)]
        public required string Text { get; set; }
        [StringLength(30)]
        public required string Type { get; set; }
        [StringLength(20)]
        public required string Rating { get; set; }
        [StringLength(50)]
        public required string Participant { get; set; }
    }
}
