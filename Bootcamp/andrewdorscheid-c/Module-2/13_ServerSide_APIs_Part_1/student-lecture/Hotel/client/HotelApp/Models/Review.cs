using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.Models
{
    public class Review
    {
        public int HotelID { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string Author { get; set; }
        public int Stars { get; set; }
    }
}
