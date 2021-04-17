using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    public interface IReviewDao
    {
        List<Review> GetReviews();
        List<Review> GetReviews(int hotelId);
    }
}