using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using Assignment_1.data;
using Label = System.Windows.Controls.Label;

namespace Assignment_1;

public partial class PrintWindow : Window
{
    private readonly User _user;

    public PrintWindow(RunnerDetails runnerDetails, ParticipantDetails participantDetails,
        VolunteerDetails volunteerDetails, Sponsor sponsor, User user)
    {
        InitializeComponent();
        _user = user;
        if (user.Type == Constants.Amateur)
        {
            AmateurPanel.Visibility = Visibility.Visible;
            ProfessionalPanel.Visibility = Visibility.Collapsed;
            VolunteerPanel.Visibility = Visibility.Collapsed;
            UserLabel.Content = user.Username;
            setStatus(runnerDetails, StatusLabel);

            SponsorLabel.Content = sponsor.Name + " sponsored your marathon";
            CostumeLabel.Content = runnerDetails.Costume + " was your costumer.";
        }
        else if (user.Type == Constants.Professional)
        {
            AmateurPanel.Visibility = Visibility.Collapsed;
            ProfessionalPanel.Visibility = Visibility.Visible;
            VolunteerPanel.Visibility = Visibility.Collapsed;

            ProfessionalUserLabel.Content = user.Username;
            setStatus(runnerDetails, ProfessionalStatusLabel);
            ProfessionalRankLabel.Content = "Your world rank is " + runnerDetails.WorldRank;
        }
        else
        {
            AmateurPanel.Visibility = Visibility.Collapsed;
            ProfessionalPanel.Visibility = Visibility.Collapsed;
            VolunteerPanel.Visibility = Visibility.Visible;

            VolunteerUserLabel.Content = user.Username;

            VolunteerStatusLabel.Content = "participated as " + volunteerDetails.VolunteerType;
        }
    }

    private void setStatus(RunnerDetails runnerDetails, Label label)
    {
        if (runnerDetails.Status == Status.FINISHED)
        {
            label.Content = "completed the race";
        }
        else if (runnerDetails.Status == Status.IN_PROGRESS)
        {
            label.Content = "took part in the race.";
        }
        else
        {
            label.Content = "couldn't take part in the race.";
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        PrintDialog printDialog = new PrintDialog();

        if (_user.Type == Constants.Amateur)
        {
            printDialog.PrintVisual(AmateurPanel, "Amateur");
        }
        else if (_user.Type == Constants.Professional)
        {
            printDialog.PrintVisual(ProfessionalPanel, "Professional");
        }
        else
        {
            printDialog.PrintVisual(VolunteerPanel, "Volunteer");
        }
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}