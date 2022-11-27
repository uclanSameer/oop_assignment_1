namespace Assignment_1.data;

public class Runner : Participant
{
    public RankType RankType { get; set; }
    public Status Status { get; set; }
    public long Number { get; set; }

    //constructor
    protected Runner(string fullName, string address, long phoneNumber, string emailAddress, RankType rankType, Status status,
        long number) : base(fullName, address, phoneNumber, emailAddress)
    {
        RankType = rankType;
        Status = status;
        Number = number;
    }
}