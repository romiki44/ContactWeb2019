using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWeb2019.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ContactWebConstants.MAX_FIRST_NAME_LEGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ContactWebConstants.MAX_LAST_NAME_LEGTH)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(ContactWebConstants.MAX_EMAIl_LEGTH)]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [StringLength(ContactWebConstants.MAX_PHONE_LEGTH)]
        public string PhonePrimary { get; set; }
        
        [StringLength(ContactWebConstants.MAX_PHONE_LEGTH)]
        public string PhoneSecondary { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true)]
        public DateTime Birtday { get; set; }
        
        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LEGTH)]
        public string StreetAddress1 { get; set; }

        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LEGTH)]
        public string StreetAddress2 { get; set; }
        
        [Required]
        [StringLength(ContactWebConstants.MAX_CITY_LEGTH)]
        public string City { get; set; }

        [Display(Name ="Zip Code")]
        [Required]
        [StringLength(maximumLength: ContactWebConstants.MAX_ZIP_CODE_LEGTH, MinimumLength =ContactWebConstants.MIN_ZIP_CODE_LEGTH)]
        public string Zip { get; set; }

        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User {get; set;}

        [Display(Name ="Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name ="Full Address")]
        public string FullAddress => string.IsNullOrEmpty(StreetAddress2)
                                    ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                                    : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";
    }
}
