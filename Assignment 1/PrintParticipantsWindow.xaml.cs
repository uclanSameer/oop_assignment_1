using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;
using Assignment_1.service;

namespace Assignment_1;

public partial class PrintParticipantsWindow : Window
{
    private readonly ISponsorRepository _sponsorRepository = new SponsorRepository();
    private readonly IRunnerService _runnerService = new RunnerService();

    public PrintParticipantsWindow()
    {
        InitializeComponent();
        var sponsors = _sponsorRepository.FindAll();
        SponsorList.ItemsSource = sponsors;
    }

    /**
     * This method is called when the user clicks on the "Print" button.
     * It prints the list of participants for the selected sponsor.
     */
    private void Print_Click(object sender, RoutedEventArgs e)
    {
        var printDialog = new PrintDialog();
        printDialog.PrintVisual(UserPanel, "Print Participants");
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /**
     * This method is called when the user selects a sponsor from the list.
     * It will display the list of runners for the selected sponsor.
     * 
     */
    private void SponsorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var sponsor = (Sponsor) SponsorList.SelectedItem;
        var participantDetailsList = _runnerService
            .getParticipantsBySponsorId(sponsor.SponsorId);
        if (participantDetailsList.Count > 0)
        {
            UserPanel.Visibility = Visibility.Visible;
            UserListView.ItemsSource = participantDetailsList
                .Select(details => details.FullName);
        }
        else
        {
            UserPanel.Visibility = Visibility.Collapsed;
        }
    }
}