using System;
using System.Web.Helpers;
using System.Windows;
using Assignment_1.data;
using Assignment_1.service;

namespace Assignment_1;

public partial class LoginWindow : Window
{
    private readonly IUserService _userService = new UserService();

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
        try
        {
            var user = _userService.login(new UserDetails()
            {
                Username = Username.Text,
                Password = Password.Password
            });
            var mainWindow = new DashboardWindow(user);
            mainWindow.Show();
            Close();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show("Login failed");
        }
    }
}