namespace AccountCreator.Interfaces
{
    internal interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}
