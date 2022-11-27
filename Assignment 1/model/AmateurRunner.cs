namespace Assignment_1.data;

public class AmateurRunner : Runner
{
    public Sponsor Sponsor { get; }

    public string Costume { get; }

    //constructor
    public AmateurRunner(string fullName, string address, int phoneNumber, string emailAddress, RankType rankType,
        Status status, int number, Sponsor sponsor, string costume) : base(fullName, address, phoneNumber, emailAddress,
        rankType, status, number)
    {
        Sponsor = sponsor;
        Costume = costume;
    }
}