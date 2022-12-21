using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupBCinema.Models
{
    public class movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movy()
        {
            shows = new HashSet<show>();
        }

        [Key]
        public int movie_id { get; set; }

        [Required]
        [StringLength(100)]
        public string movie_name { get; set; }

        [Required]
        [StringLength(100)]
        public string genre { get; set; }

        [Required]
        [StringLength(100)]
        public string runtime { get; set; }

        [Required]
        [StringLength(100)]
        public string release_date { get; set; }

        [Required]
        [StringLength(100)]
        public string language { get; set; }

        [Required]
        [StringLength(100)]
        public string subtitle { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(100)]
        public string image_path { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(1000)]
        public string video_path { get; set; }

        [Required]
        [StringLength(100)]
        public string rating { get; set; }

        [Required]
        [StringLength(100)]
        public string director { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<show> shows { get; set; }
    }
}
