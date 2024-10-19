namespace NikeDLL.DLInterfaces
{
    public interface IUserDL
    {
        string SignIn(string username, string password);
        void SignUp(string username, string password, string role);
        bool ChangePassword(string username, string newPassword);
    }
}
