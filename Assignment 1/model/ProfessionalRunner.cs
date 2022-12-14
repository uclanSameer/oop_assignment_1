namespace Assignment_1.data;

public class ProfessionalRunner : Runner
{
    public int WorldRanking { get; }

    public ProfessionalRunner(string fullName, string address, long phoneNumber, string emailAddress, RankType rankType,
        Status status, long number, int worldRanking) : base(fullName, address, phoneNumber, emailAddress, rankType,
        status, number)
    {
        WorldRanking = worldRanking;
    }
}