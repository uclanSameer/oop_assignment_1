using Assignment_1.data;

namespace Assignment_1.helper;

public static class ParticipantHelper
{
    public static ParticipantDetails BuildParticipantDetails(Participant participant, UserDetails userDetails,
        User addedUser)
    {
        return new ParticipantDetails()
        {
            Address = participant.Address,
            UserId = addedUser.UserId,
            FullName = userDetails.Username,
            EmailAddress = participant.EmailAddress,
            PhoneNumber = participant.PhoneNumber
        };
    }
}