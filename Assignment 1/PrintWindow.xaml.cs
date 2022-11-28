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
            HandleAmateur(runnerDetails, sponsor, user);
        }
        else if (user.Type == Constants.Professional)
        {
            HandleProfessional(runnerDetails, user);
        }
        else
        {
            HandleVolunteer(volunteerDetails, user);
        }
    }

    /**
     * Builds Volunteer details panel
     */
    private void HandleVolunteer(VolunteerDetails volunteerDetails, User user)
    {
        AmateurPanel.Visibility = Visibility.Collapsed;
        ProfessionalPanel.Visibility = Visibility.Collapsed;
        VolunteerPanel.Visibility = Visibility.Visible;

        VolunteerUserLabel.Content = user.Username;

        VolunteerStatusLabel.Content = "participated as " + volunteerDetails.VolunteerType;
    }

    /**
     * Builds the professional panel
     */
    private void HandleProfessional(RunnerDetails runnerDetails, User user)
    {
        AmateurPanel.Visibility = Visibility.Collapsed;
        ProfessionalPanel.Visibility = Visibility.Visible;
        VolunteerPanel.Visibility = Visibility.Collapsed;

        ProfessionalUserLabel.Content = user.Username;
        setStatus(runnerDetails, ProfessionalStatusLabel);
        ProfessionalRankLabel.Content = "Your world rank is " + runnerDetails.WorldRank;
    }

    /**
     * Build the UI for an amateur runner
     */
    private void HandleAmateur(RunnerDetails runnerDetails, Sponsor sponsor, User user)
    {
        AmateurPanel.Visibility = Visibility.Visible;
        ProfessionalPanel.Visibility = Visibility.Collapsed;
        VolunteerPanel.Visibility = Visibility.Collapsed;
        UserLabel.Content = user.Username;
        setStatus(runnerDetails, StatusLabel);

        SponsorLabel.Content = sponsor.Name + " sponsored your marathon";
        CostumeLabel.Content = runnerDetails.Costume + " was your costumer.";
    }

    /**
     * Sets the status label based on the runner details
     */
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

    /**
     * This method is called when the user clicks print button
     */
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

    /**
     * This method is called when the user clicks on the cancel button.
     */
    private void CancelClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}