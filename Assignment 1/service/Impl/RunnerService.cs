using System.Collections.Generic;
using System.Linq;
using Assignment_1.data;
using Assignment_1.repository;
using Assignment_1.repository.Impl;

namespace Assignment_1.service;

public class RunnerService : IRunnerService
{
    private readonly IRunnerRepository _runnerRepository = new RunnerRepository();
    private readonly IParticipantsRepository _participantsRepository = new ParticipantsRepository();

    public List<ParticipantDetails> getParticipantsBySponsorId(string sponsorId)
    {
        var runners = _runnerRepository
            .FindAllBySponsorId(sponsorId);
        if (runners.Count > 0)
        {
            return runners
                .Select(runnerDetails =>
                    _participantsRepository.GetParticipant(runnerDetails.ParticipantDetailsId)
                ).ToList();
        }

        // return empty list
        return new List<ParticipantDetails>();
    }
}