using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;

namespace Assignment_1;

public partial class SponsorWindow : Window
{
    private readonly ISponsorRepository _sponsorRepository = new SponsorRepository();

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        _sponsorRepository.create(new Sponsor()
        {
            Money = double.Parse(MoneyBox.Text),
            Name = SponsorNameBox.Text
        });
        MessageBox.Show("Sponsor added");
    }
}