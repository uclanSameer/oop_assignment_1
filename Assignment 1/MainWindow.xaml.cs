using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment_1.data;

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _dataContext = new();

        public MainWindow()
        {
            InitializeComponent();
            _dataContext.Database.EnsureCreated();
            
            // add sponsors only if there are none
            if (!_dataContext.Sponsors.Any())
            {
                _dataContext.Sponsors.AddRange(
                    new Sponsor() {Money = 0, Name = "BBC Sport"},
                    new Sponsor() {Money = 0, Name = "ITV Sport"}, new Sponsor() {Money = 0, Name = "Sky Sports"},
                    new Sponsor() {Money = 0, Name = "Paddy Power"}, new Sponsor() {Money = 0, Name = "Bet365"},
                    new Sponsor() {Money = 0, Name = "Horseracing TV"});
                _dataContext.SaveChanges();   
            }
        }

        private void openRegisterForm(object sender, RoutedEventArgs e)
        {
            Window registerForm = new RegisterWindow();
            registerForm.Show();
        }

        private void openLoginForm(object sender, RoutedEventArgs e)
        {
            Window loginForm = new LoginWindow();
            loginForm.Show();
        }
    }
}