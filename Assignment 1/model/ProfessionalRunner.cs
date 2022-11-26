namespace Assignment_1.data;

public class ProfessionalRunner : Runner
{
    public int WorldRanking { get; set; }

    public ProfessionalRunner(string fullName, string address, int phoneNumber, string emailAddress, RankType rankType,
        Status status, int number, int worldRanking) : base(fullName, address, phoneNumber, emailAddress, rankType,
        status, number)
    {
        WorldRanking = worldRanking;
    }
}