﻿using System;
using System.Collections.ObjectModel;
using System.Web.Helpers;
using System.Windows;
using Assignment_1.data;
using Assignment_1.helper;
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
            var user = UserHelper.BuildUser(userDetails);
            var addedUser = _userRepository.addUser(user);

            var participantDetails = ParticipantHelper.BuildParticipantDetails(participant, userDetails, addedUser);

            var details = _participantsRepository.createParticipant(participantDetails);

            if (participant.GetType() == typeof(Volunteer))
            {
                var volunteerDetails = VolunteerHelper
                    .BuildVolunteerDetails(participant, details);
                _volunteerRepository.create(volunteerDetails);
            }
            else if (participant.GetType() == typeof(AmateurRunner) ||
                     participant.GetType() == typeof(ProfessionalRunner))
            {
                var runnerDetails = RunnerHelper.BuildRunnerDetails((Runner) participant, details);
                _runnerRepository.create(runnerDetails);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show("Error while saving user");
        }
    }

    public User findByUsername(string username)
    {
        return _userRepository.getUser(username);
    }
}