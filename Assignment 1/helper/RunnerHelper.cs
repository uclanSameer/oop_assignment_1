using Assignment_1.data;

namespace Assignment_1.helper;

public static class RunnerHelper
{
    public static RunnerDetails BuildRunnerDetails(Runner participant, ParticipantDetails details)
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
}