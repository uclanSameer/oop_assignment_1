using Assignment_1.data;

namespace Assignment_1.helper;

public static class VolunteerHelper
{
    public static VolunteerDetails BuildVolunteerDetails(Participant participant, ParticipantDetails details)
    {
        return new VolunteerDetails()
        {
            VolunteerType = ((Volunteer) participant).VolunteerType,
            ParticipantId = details.ParticipantDetailsId
        };
    }
}