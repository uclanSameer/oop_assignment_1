using System.Web.Helpers;
using System.Windows;
using Assignment_1.service;

namespace Assignment_1;

public partial class LoginWindow : Window
{
    private IUserService _userService = new UserService();

    public LoginWindow()
    {
        InitializeComponent();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var user = _userService.findByUsername(Username.Text);
        var verifyHashedPassword = Crypto.VerifyHashedPassword(user.Password, Password.Password);
        MessageBox.Show(verifyHashedPassword
            ? "Login successful"
            : "Login failed");
    }
}