namespace Emplonomy.Logic.Security
{
    public interface ICryptoService
    {
        string CreateSalt();
        string HashPassword(string password, string salt);
    }
}
