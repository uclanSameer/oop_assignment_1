using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;

namespace Assignment_1;

public partial class SponsorWindow
{
    private readonly ISponsorRepository _sponsorRepository = new SponsorRepository();

    public SponsorWindow()
    {
        InitializeComponent();
    }

    private void ADD_SPONSOR(object sender, RoutedEventArgs e)
    {
        // check if money is double
        if (!double.TryParse(Money.Text, out _))
        {
            MessageBox.Show("Money must be a number");
            return;
        }

        _sponsorRepository.create(new Sponsor
        {
            Name = Name.Text,
            Money = int.Parse(Money.Text)
        });
        Close();
    }
}