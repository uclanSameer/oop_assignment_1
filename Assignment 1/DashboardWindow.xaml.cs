using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;

namespace Assignment_1;

public partial class DashboardWindow : Window
{
    private readonly IVolunteerRepository _volunteerRepository = new VolunteerRepository();
    private readonly IRunnerRepository _runnerRepository = new RunnerRepository();
    private readonly IParticipantsRepository _participantsRepository = new ParticipantsRepository();
    private readonly ISponsorRepository _sponsorRepository = new SponsorRepository();

    public DashboardWindow(User user)
    {
        InitializeComponent();
        var participantDetails = _participantsRepository.getParticipant(user.Username);
        UsernameBlock.Text = user.Username;
        if (user.Type == Constants.Volunteer)
        {
            Runner.Visibility = Visibility.Collapsed;
            Costume.Visibility = Visibility.Collapsed;
            Sponsor.Visibility = Visibility.Collapsed;
            Amount.Visibility = Visibility.Collapsed;
            Result.Visibility = Visibility.Collapsed;
            WorldRank.Visibility = Visibility.Collapsed;
            Volunteer.Visibility = Visibility.Visible;

            var volunteerDetails = _volunteerRepository.read(participantDetails.ParticipantDetailsId);
            VolunteerType.Text = volunteerDetails.VolunteerType;

            UpdatePosition.Visibility = Visibility.Collapsed;
        }
        else
        {
            var runnerDetails = _runnerRepository.read(participantDetails.ParticipantDetailsId);
            if (user.Type == Constants.Amateur)
            {
                Runner.Visibility = Visibility.Visible;
                Costume.Visibility = Visibility.Visible;
                Sponsor.Visibility = Visibility.Visible;
                Amount.Visibility = Visibility.Visible;
                Result.Visibility = Visibility.Visible;
                Volunteer.Visibility = Visibility.Collapsed;
                WorldRank.Visibility = Visibility.Collapsed;

                ResultBlock.Text = runnerDetails.Status.ToString();
                CostumeBlock.Text = runnerDetails.Costume;
                RunnerBlock.Text = "Runner" + runnerDetails.RunnerId;
                var sponsor = _sponsorRepository.read(runnerDetails.SponsorId);
                SponsorBlock.Text = sponsor.Name;
                AmountBlock.Text = sponsor.Money.ToString();
            }
            else if (user.Type == Constants.Professional)
            {
                Runner.Visibility = Visibility.Visible;
                Costume.Visibility = Visibility.Collapsed;
                Sponsor.Visibility = Visibility.Collapsed;
                Amount.Visibility = Visibility.Collapsed;
                Result.Visibility = Visibility.Visible;
                Volunteer.Visibility = Visibility.Collapsed;
                WorldRank.Visibility = Visibility.Visible;

                ResultBlock.Text = runnerDetails.Status.ToString();
                WorldRankBlock.Text = runnerDetails.WorldRank.ToString();
                RunnerBlock.Text = "Runner" + runnerDetails.RunnerId;
            }
        }
    }

    private void Update_Position(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void PrintCertificate_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}