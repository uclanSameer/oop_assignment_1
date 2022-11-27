namespace Assignment_1.data;

public class Participant
{
    public string FullName { get; }
    public string Address { get; }
    public long PhoneNumber { get; }
    public string EmailAddress { get; }

    //constructor
    protected Participant(string fullName, string address, long phoneNumber, string emailAddress)
    {
        FullName = fullName;
        Address = address;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
    }
}