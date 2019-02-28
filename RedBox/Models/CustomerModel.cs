using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedBox.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="* Required")]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? DOB { get; set; }
        public bool  IsSubscribedToMembership { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
         public byte MembershipTypeId { get; set; }
       
    }
}