using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBox.Dtos
{
    public class MovieDTO
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime ReleasedDate { get; set; }
       
        public DateTime DateAdded { get; set; }

        public byte NumberInStock { get; set; }

        public short GenreId { get; set; }
    }
}