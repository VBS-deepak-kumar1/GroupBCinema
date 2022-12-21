using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GroupBCinema.Models
{
    public partial class show
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public show()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int show_id { get; set; }

        public int movie_id { get; set; }

        public int theater_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public TimeSpan? timing { get; set; }

        public double? price { get; set; }

        public virtual movy movy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual theater theater { get; set; }
    }
}
