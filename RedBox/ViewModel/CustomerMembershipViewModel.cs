using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedBox.Models;

namespace RedBox.ViewModel
{
    public class CustomerMembershipViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public CustomerModel Customer { get; set; }
    }
}