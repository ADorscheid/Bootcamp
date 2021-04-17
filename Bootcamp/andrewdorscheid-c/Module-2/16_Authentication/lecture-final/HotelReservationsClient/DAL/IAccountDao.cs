namespace HotelReservationsClient.DAL
{
    public interface IAccountDao : IApiDao
    {
        bool Login(string submittedName, string submittedPass);
        void Logout();
    }
}