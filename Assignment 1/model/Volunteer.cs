namespace Assignment_1.data;

public class Volunteer : Participant
{
    public string VolunteerType { get; set; }

    //constructor
    public Volunteer(string name, string email, int phone, string address, string volunteerType) :
        base(name, address, phone, email)
    {
        VolunteerType = volunteerType;
    }
}