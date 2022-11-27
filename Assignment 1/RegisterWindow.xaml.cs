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

    private string _volunteerType = "";

    public RegisterWindow()
    {
        InitializeComponent();
        checkVolunteer.IsChecked = true;
        volunteerListBox.Items.Add("Marshalling");
        volunteerListBox.Items.Add("First Aid");
        volunteerListBox.Items.Add("Drink Station");

        updateSponsor(_sponsorRepository);
    }

    private void updateSponsor(ISponsorRepository sponsorRepository)
    {
        var sponsors = sponsorRepository.findAll().ToList();

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

        if (_user == "" || _password == "" || _rePassword == "" || _email == "" || _phone == "" || _address == "")
        {
            MessageBox.Show("Please fill all the fields");
        }
        else
        {
            if (ValidateFields())
            {
                IUserService service = new UserService();
                var userDetails = new UserDetails() {Username = _user, Password = _password};
                if (checkVolunteer.IsChecked == true)
                {
                    userDetails.Type = "Volunteer";
                    _volunteerType = volunteerListBox.SelectedItem.ToString() ?? string.Empty;
                    Participant volunteer =
                        new Volunteer(_user, _email, int.Parse(_phone), _address, _volunteerType);

                    service.save(volunteer, userDetails);
                    MessageBox.Show("Volunteer Registered Successfully");
                    Close();
                }
                else if (checkAmateur.IsChecked == true)
                {
                    userDetails.Type = Constants.Amateur;
                    Participant amateur =
                        new AmateurRunner(
                            _user, _address,
                            int.Parse(_phone), _email,
                            RankType.AMATEURE, Status.NOT_STARTED, 0, (Sponsor) SponsorListBox.SelectedItem,
                            costumeBox.Text);
                    service.save(amateur, userDetails);
                    MessageBox.Show("Amateur Registered Successfully");
                    Close();
                }
                else if (checkProfessional.IsChecked == true)
                {
                    userDetails.Type = Constants.Professional;
                    Participant professional =
                        new ProfessionalRunner(
                            _user, _address,
                            long.Parse(_phone), _email,
                            RankType.PROFFETIONAL, Status.NOT_STARTED, 0, int.Parse(professionalRankTextBox.Text
                            ));
                    service.save(professional, userDetails);
                    MessageBox.Show("Professional Registered Successfully");
                    Close();
                }

                MessageBox.Show("Registration Successful");
            }
        }
    }

    /**
     * Checks if the fields are valid
     */
    private bool ValidateFields()
    {
        // checks if the password and re-password are the same
        // if (_password != _rePassword)
        // {
        //     MessageBox.Show("Password and Re-Password are not the same");
        // }
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
        // checks if the phone number is 10 digits
        // else if (_phone.Length != 10)
        // {
        //     MessageBox.Show("Phone number is not valid");
        // }
        else
        {
            return true;
        }

        return false;
    }

    /**
     * Show hide the fields in UI as per the radio button is checked
     */
    private void showHideFields(object sender, RoutedEventArgs e)
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
        updateSponsor(_sponsorRepository);
    }
}