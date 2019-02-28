using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBox.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte Discount { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo =1 ;
    }
}