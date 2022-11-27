namespace Assignment_1.data;

public class Participant
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public long PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    //constructor
    protected Participant(string fullName, string address, long phoneNumber, string emailAddress)
    {
        FullName = fullName;
        Address = address;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
    }
}