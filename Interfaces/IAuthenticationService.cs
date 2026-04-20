namespace SchoolJournal.Interfaces
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);
        string GetUserRole(string username);
        bool UserExists(string username);
        bool Register(string username, string password, string role);
        bool IsAuthenticated { get; }
        string CurrentUser { get; }
    }
}