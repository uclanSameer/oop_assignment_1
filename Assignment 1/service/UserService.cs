using System;
using System.Collections.ObjectModel;
using System.Web.Helpers;
using System.Windows;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;

namespace Assignment_1.service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly IParticipantsRepository _participantsRepository;
    private readonly IRunnerRepository _runnerRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
        _volunteerRepository = new VolunteerRepository();
        _participantsRepository = new ParticipantsRepository();
        _runnerRepository = new RunnerRepository();
    }

    public void save(Participant participant, UserDetails userDetails)
    {
        try
        {
            var user = BuildUser(userDetails);
            var addedUser = _userRepository.addUser(user);

            var participantDetails = BuildParticipantDetails(participant, userDetails, addedUser);

            var details = _participantsRepository.createParticipant(participantDetails);

            if (participant.GetType() == typeof(Volunteer))
            {
                var volunteerDetails = BuildVolunteerDetails(participant, details);
                _volunteerRepository.create(volunteerDetails);
            }
            else if (participant.GetType() == typeof(AmateurRunner) ||
                     participant.GetType() == typeof(ProfessionalRunner))
            {
                var runnerDetails = BuildRunnerDetails((Runner) participant, details);
                _runnerRepository.create(runnerDetails);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show("Error while saving user");
        }
    }

    public void save(Participant participant)
    {
        throw new System.NotImplementedException();
    }

    public User findByUsername(string username)
    {
        return _userRepository.getUser(username);
    }

    public Collection<Participant> findAll()
    {
        throw new System.NotImplementedException();
    }

    /*
     * Build the runner details from the participant details
     */
    private static RunnerDetails BuildRunnerDetails(Runner participant, ParticipantDetails details)
    {
        var runnerDetails = new RunnerDetails
        {
            Status = participant.Status,
            ParticipantDetailsId = details.ParticipantDetailsId
        };
        if (participant.GetType() == typeof(AmateurRunner))
        {
            BuildObjectForAmateur(participant, runnerDetails);
        }
        else if (participant.GetType() == typeof(ProfessionalRunner))
        {
            BuildObjectForProfessional(participant, runnerDetails);
        }

        return runnerDetails;
    }

    private static void BuildObjectForProfessional(Runner participant, RunnerDetails runnerDetails)
    {
        runnerDetails.WorldRank = ((ProfessionalRunner) participant).WorldRanking;
        runnerDetails.RankType = RankType.PROFFETIONAL;
        runnerDetails.Costume = "Standard";
    }

    private static void BuildObjectForAmateur(Runner participant, RunnerDetails runnerDetails)
    {
        runnerDetails.RankType = RankType.AMATEURE;
        runnerDetails.SponsorId = ((AmateurRunner) participant).Sponsor.SponsorId;
        runnerDetails.Costume = ((AmateurRunner) participant).Costume;
    }

    private static VolunteerDetails BuildVolunteerDetails(Participant participant, ParticipantDetails details)
    {
        return new VolunteerDetails()
        {
            VolunteerType = ((Volunteer) participant).VolunteerType,
            ParticipantId = details.ParticipantDetailsId
        };
    }

    private static ParticipantDetails BuildParticipantDetails(Participant participant, UserDetails userDetails,
        User addedUser)
    {
        return new ParticipantDetails()
        {
            Address = participant.Address,
            UserId = addedUser.UserId,
            FullName = userDetails.Username,
            EmailAddress = participant.EmailAddress,
            PhoneNumber = participant.PhoneNumber
        };
    }

    private static User BuildUser(UserDetails userDetails)
    {
        return new User()
        {
            // hash the password before saving it for security reasons
            Password = Crypto.HashPassword(userDetails.Password),
            Username = userDetails.Username
        };
    }
}