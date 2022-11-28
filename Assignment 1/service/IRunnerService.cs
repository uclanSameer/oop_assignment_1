using System.Collections.Generic;
using System.Windows.Documents;
using Assignment_1.data;

namespace Assignment_1.service;

public interface IRunnerService
{
    List<ParticipantDetails> getParticipantsBySponsorId(string sponsorId);
}