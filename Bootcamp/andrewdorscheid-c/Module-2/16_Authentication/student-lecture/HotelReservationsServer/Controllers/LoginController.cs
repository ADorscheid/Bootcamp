using HotelReservations.DAO;
using HotelReservations.Security;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDao userDao;

        public LoginController(ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher, IUserDao userDao)
        {
            this.tokenGenerator = tokenGenerator;
            this.passwordHasher = passwordHasher;
            this.userDao = userDao;
        }

        // TODO 02: Hit the /login endpoint with Postman (username, password) to test it out (test/test) or (admin/admin)
        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = BadRequest(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDao.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            // TODO 03: Note: we do not store password, we store a hash, so that's how we compare.
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.Id, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                ReturnUser retUser = new ReturnUser() { Id = user.Id, Username = user.Username, Role = user.Role, Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            // TODO 04: After we return a token, take a look at it on http://jwt.io
            return result;
        }
    }
}
