using System.Windows;
using System.Windows.Controls;
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

    private readonly RunnerDetails _runnerDetails;
    private readonly ParticipantDetails _participantDetails;
    private readonly VolunteerDetails _volunteerDetails;
    private readonly User user;
    private Sponsor _sponsor;

    public DashboardWindow(User user)
    {
        InitializeComponent();
        this.user = user;
        _participantDetails = _participantsRepository.GetParticipantByUsername(user.Username);
        UsernameBlock.Text = user.Username;
        if (user.Type == Constants.Volunteer)
        {
            _volunteerDetails = _volunteerRepository.Read(_participantDetails.ParticipantDetailsId);
            HandleVolunteer();
        }
        else
        {
            _runnerDetails = _runnerRepository.Read(_participantDetails.ParticipantDetailsId);
            if (user.Type == Constants.Amateur)
            {
                HandleAmateur();
            }
            else if (user.Type == Constants.Professional)
            {
                HandleProfessional();
            }
        }
    }

    private void HandleProfessional()
    {
        Runner.Visibility = Visibility.Visible;
        Costume.Visibility = Visibility.Collapsed;
        Sponsor.Visibility = Visibility.Collapsed;
        Amount.Visibility = Visibility.Collapsed;
        Result.Visibility = Visibility.Visible;
        Volunteer.Visibility = Visibility.Collapsed;
        WorldRank.Visibility = Visibility.Visible;

        ResultBlock.Text = _runnerDetails.Status.ToString();
        WorldRankBlock.Text = _runnerDetails.WorldRank.ToString();
        RunnerBlock.Text = "Runner" + _runnerDetails.RunnerId;
    }

    private void HandleAmateur()
    {
        Runner.Visibility = Visibility.Visible;
        Costume.Visibility = Visibility.Visible;
        Sponsor.Visibility = Visibility.Visible;
        Amount.Visibility = Visibility.Visible;
        Result.Visibility = Visibility.Visible;
        Volunteer.Visibility = Visibility.Collapsed;
        WorldRank.Visibility = Visibility.Collapsed;

        ResultBlock.Text = _runnerDetails.Status.ToString();
        CostumeBlock.Text = _runnerDetails.Costume;
        RunnerBlock.Text = "Runner" + _runnerDetails.RunnerId;
        _sponsor = _sponsorRepository.Read(_runnerDetails.SponsorId);
        SponsorBlock.Text = _sponsor.Name;
        AmountBlock.Text = _sponsor.Money.ToString();
    }

    private void HandleVolunteer()
    {
        Runner.Visibility = Visibility.Collapsed;
        Costume.Visibility = Visibility.Collapsed;
        Sponsor.Visibility = Visibility.Collapsed;
        Amount.Visibility = Visibility.Collapsed;
        Result.Visibility = Visibility.Collapsed;
        WorldRank.Visibility = Visibility.Collapsed;
        Volunteer.Visibility = Visibility.Visible;

        VolunteerType.Text = _volunteerDetails.VolunteerType;

        UpdatePosition.Visibility = Visibility.Collapsed;
    }

    private void Update_Position(object sender, RoutedEventArgs e)
    {
        Window updatePositionWindow = new UpdateDetailsWindow(_runnerDetails, _runnerRepository);
        updatePositionWindow.Show();
        Close();
    }

    private void PrintCertificate_OnClick(object sender, RoutedEventArgs e)
    {
        Window printCertificateWindow =
            new PrintWindow(_runnerDetails, _participantDetails, _volunteerDetails, _sponsor, user);
        printCertificateWindow.Show();
        Close();
    }
}