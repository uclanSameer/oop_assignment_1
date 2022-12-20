using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using static System.Enum;

namespace Assignment_1;

public partial class UpdateDetailsWindow : Window
{
    private readonly IRunnerRepository _runnerRepository;
    private readonly RunnerDetails _runnerDetails;

    public UpdateDetailsWindow(RunnerDetails runnerDetails, IRunnerRepository repository)
    {
        InitializeComponent();
        PositionList.Items.Add("FINISHED");
        PositionList.Items.Add("IN_PROGRESS");
        PositionList.Items.Add("NOT_STARTED");

        _runnerRepository = repository;
        _runnerDetails = runnerDetails;
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        TryParse(PositionList.SelectedItem.ToString(), out Status myStatus);
        _runnerDetails.Status = myStatus;
        _runnerRepository.Update(_runnerDetails);
        Close();
    }
}