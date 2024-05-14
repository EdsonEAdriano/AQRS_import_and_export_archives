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
        public string Genre { get; set; }
        [StringLength(30)]
        public string Category { get; set; }
        [Column("media_name")]
        [StringLength(250)]
        public string MediaName { get; set; }
        [StringLength(30)]
        public string Type { get; set; }
        [StringLength(20)]
        public string Rating { get; set; }
        [StringLength(50)]
        public string Participant { get; set; }

        public Media()
        {

        }

        public Media(string line)
        {
            Genre = line.Substring(0, Math.Min(30, line.Length)).TrimEnd();
            Category = line.Substring(30, Math.Min(30, line.Length - 30)).TrimEnd();
            MediaName = line.Substring(60, Math.Min(250, line.Length - 60)).TrimEnd();
            Type = line.Substring(310, Math.Min(30, line.Length - 310)).TrimEnd();
            Rating = line.Substring(340, Math.Min(20, line.Length - 340)).TrimEnd();
            Participant = line.Substring(360, Math.Min(50, line.Length - 360)).TrimEnd();
        }
    }
}
