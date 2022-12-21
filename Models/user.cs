using GroupBCinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace GroupBCinema
{
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int user_id { get; set; }

        [StringLength(25)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Last Name.")]
        [DisplayName("Last Name")]
        public string last_name { get; set; }

        [StringLength(25)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name.")]
        [DisplayName("First Name")]
        public string first_name { get; set; }

        [StringLength(15)]
        [Required]
        [RegularExpression(@"^(\+?1 ?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number.")]
        [DisplayName("Phone No")]
        public string phone { get; set; }

        [StringLength(4)]
        [Required]
        [RegularExpression(@"^((?!(0))[0-9]{4})$", ErrorMessage = "Invalid Street Number.")]
        [DisplayName("Street No")]
        public string street_no { get; set; }

        [StringLength(20)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street Name is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Invalid Street Name.")]
        [DisplayName("Street Name")]
        public string street_name { get; set; }

        [StringLength(15)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Invalid City Name.")]
        [DisplayName("City")]
        public string city { get; set; }

        [StringLength(15)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Province is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Invalid Province Name.")]
        [DisplayName("Province")]
        public string province { get; set; }

        [StringLength(7)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal Code is required.")]

        [DisplayName("Postal Code")]
        public string postal_code { get; set; }

        [StringLength(15)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Invalid Country Name.")]
        [DisplayName("Country")]
        public string country { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [DisplayName("Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Input needs at least 1 Uppercase, Lowecase and Special Character.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [Required]
        [StringLength(100)]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password and Confirm Password does not match")]
        public string confirm_password { get; set; }

        [NotMapped]
        public string LoginErrorMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
    public enum Country
    {
        Canada,
        US,
        India
    }
}
