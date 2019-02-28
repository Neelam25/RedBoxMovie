using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBox.Dtos
{
    public class CustomerDTO
    {
        public int ID { get; set; }
      
        public string Name { get; set; }
        
        public DateTime? DOB { get; set; }
        public bool IsSubscribedToMembership { get; set; }
       
        public byte MembershipTypeId { get; set; }
    }
}