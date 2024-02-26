namespace RegistrationApp.Domein.Exceptions.UsersLogins
{
    public class UserLoginNotFoundException : Exception
    {
        public UserLoginNotFoundException() : base("You're not logged in!") { }
    }
}
