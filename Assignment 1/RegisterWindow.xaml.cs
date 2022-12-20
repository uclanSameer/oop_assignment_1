using System;
using System.Linq;
using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;
using Assignment_1.service;

namespace Assignment_1;

public partial class RegisterWindow : Window
{
    private readonly ISponsorRepository _sponsorRepository = new SponsorRepository();

    private string _user = "";
    private string _password = "";
    private string _rePassword = "";
    private string _email = "";
    private string _phone = "";
    private string _address = "";
    private string _fullName = "";

    private string _volunteerType = "";

    public RegisterWindow()
    {
        InitializeComponent();
        checkVolunteer.IsChecked = true;
        VolunteerListBox.Items.Add("Marshalling");
        VolunteerListBox.Items.Add("First Aid");
        VolunteerListBox.Items.Add("Drink Station");

        UpdateSponsor(_sponsorRepository);
    }

    private void UpdateSponsor(ISponsorRepository sponsorRepository)
    {
        var sponsors = sponsorRepository.FindAll().ToList();

        SponsorListBox.ItemsSource = sponsors;
    }

    private void Register(object sender, RoutedEventArgs e)
    {
        _user = UsernameBox.Text;
        _password = PasswordBox.Password;
        _rePassword = RePasswordBox.Password;
        _email = EmailBox.Text;
        _phone = PhoneBox.Text;
        _address = AddressBox.Text;
        _fullName = TxtFullName.Text;
        

        if (_user == "" || _password == "" || _rePassword == "" || _email == "" || _phone == "" || _address == "" || _fullName == "")
        {
            MessageBox.Show("Please fill all the fields");
        }
        else
        {
            if (!ValidateFields()) return;
            IUserService service = new UserService();
            var userDetails = new UserDetails() {Username = _user, Password = _password};
            if (checkVolunteer.IsChecked == true)
            {
                HandleVolunteerRegistration(userDetails, service);
            }
            else if (checkAmateur.IsChecked == true)
            {
                HandleAmateurRegistration(userDetails, service);
            }
            else if (checkProfessional.IsChecked == true)
            {
                HandleProfessionalRegistration(userDetails, service);
            }

            MessageBox.Show("Registration Successful");
        }
    }

    /**
     * Handle the registration of a volunteer
     */
    private void HandleProfessionalRegistration(UserDetails userDetails, IUserService service)
    {
        userDetails.Type = Constants.Professional;
        Participant professional =
            new ProfessionalRunner(
                _fullName, _address,
                long.Parse(_phone), _email,
                RankType.PROFFETIONAL, Status.NOT_STARTED, 0, int.Parse(ProfessionalRankTextBox.Text
                ));
        service.save(professional, userDetails);
        MessageBox.Show("Professional Registered Successfully");
        Close();
    }

    /**
     * This method handles the registration of an amateur runner
     */
    private void HandleAmateurRegistration(UserDetails userDetails, IUserService service)
    {
        userDetails.Type = Constants.Amateur;
        Participant amateur =
            new AmateurRunner(
                _fullName, _address,
                int.Parse(_phone), _email,
                RankType.AMATEURE, Status.NOT_STARTED, 0, (Sponsor) SponsorListBox.SelectedItem,
                costumeBox.Text);
        service.save(amateur, userDetails);
        MessageBox.Show("Amateur Registered Successfully");
        Close();
    }

    /**
     * Handles Volunteer Registration
     */
    private void HandleVolunteerRegistration(UserDetails userDetails, IUserService service)
    {
        userDetails.Type = "Volunteer";
        _volunteerType = VolunteerListBox.SelectedItem.ToString() ?? string.Empty;
        Participant volunteer =
            new Volunteer(_fullName, _email, int.Parse(_phone), _address, _volunteerType);

        service.save(volunteer, userDetails);
        MessageBox.Show("Volunteer Registered Successfully");
        Close();
    }

    /**
     * Checks if the fields are valid
     */
    private bool ValidateFields()
    {
        // checks if the password and re-password are the same
        if (_password != _rePassword)
        {
            MessageBox.Show("Password and Re-Password are not the same");
        }

        // checks if the email is valid
        if (!_email.Contains("@") || !_email.Contains("."))
        {
            MessageBox.Show("Email is not valid");
        }

        // checks with regex if the phone number contains only numbers
        else if (!System.Text.RegularExpressions.Regex.IsMatch(_phone, "^[0-9]+$"))
        {
            MessageBox.Show("Phone number is not valid");
        }
        else
        {
            return true;
        }

        return false;
    }

    /**
     * Show hide the fields in UI as per the radio button is checked
     */
    private void ShowHideFields(object sender, RoutedEventArgs e)
    {
        if (checkVolunteer.IsChecked == true)
        {
            VolunteerList.Visibility = Visibility.Visible;
            AmateurPanel.Visibility = Visibility.Collapsed;
            ProfessionalPanel.Visibility = Visibility.Collapsed;
        }
        else if (checkAmateur.IsChecked == true)
        {
            VolunteerList.Visibility = Visibility.Collapsed;
            AmateurPanel.Visibility = Visibility.Visible;
            ProfessionalPanel.Visibility = Visibility.Collapsed;
        }
        else if (checkProfessional.IsChecked == true)
        {
            VolunteerList.Visibility = Visibility.Collapsed;
            AmateurPanel.Visibility = Visibility.Collapsed;
            ProfessionalPanel.Visibility = Visibility.Visible;
        }
    }

    private void SponsorButton_OnClick(object sender, RoutedEventArgs e)
    {
        Window sponsorWindow = new SponsorWindow();
        sponsorWindow.Show();
        UpdateSponsor(_sponsorRepository);
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}