using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GroupBCinema.Models
{
    
    
        public partial class theater
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public theater()
            {
                shows = new HashSet<show>();
            }

            [Key]
            public int theater_id { get; set; }

            [Required]
            [StringLength(100)]
            public string theater_name { get; set; }

            [StringLength(20)]
            public string city { get; set; }

            [StringLength(15)]
            public string country { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<show> shows { get; set; }
        }
    }