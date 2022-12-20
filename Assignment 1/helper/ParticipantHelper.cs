using Assignment_1.data;

namespace Assignment_1.helper;

public static class ParticipantHelper
{
    /**
     * Build a participant object from participant data and user data
     */
    public static ParticipantDetails BuildParticipantDetails(Participant participant, UserDetails userDetails,
        User addedUser)
    {
        return new ParticipantDetails()
        {
            Address = participant.Address,
            UserId = addedUser.UserId,
            FullName = participant.FullName,
            EmailAddress = participant.EmailAddress,
            PhoneNumber = participant.PhoneNumber
        };
    }
}