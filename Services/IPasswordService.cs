using Entities;

namespace Services
{
    public interface IPasswordService
    {
        CheckPassowrd checkStrengthPassword(string password);
    }
}