namespace OptiStock.MAUI.Exceptions
{
    public static class AccountDataServiceExceptions
    {
        public static readonly Exception UserDoesntExistException = new("The user you've entered doesn't exist");

        public static readonly Exception PasswordIsWrongException = new("The password seems to be wrong");

        public static readonly Exception PasswordsMisMatchException = new("Passwords mismatch");

        public static readonly Exception EmailAlreadyUsedException = new("The email that you've entered is already used");

        public static readonly Exception UsernameAlreadyUsedException = new("The username that you've entered is already used");
    }
}
