using Entities;
using Repository;


namespace Services
{
    public class PasswordService : IPasswordService
    {
        PasswordRepository repository = new PasswordRepository();
        public CheckPassowrd checkStrengthPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int strength = result.Score;
            CheckPassowrd pass = new CheckPassowrd();
            pass.password = password;
            pass.strength = strength;
            return pass;
        }
    }
}
