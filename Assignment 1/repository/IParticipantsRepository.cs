using Assignment_1.data;

namespace Assignment_1.repository;

// repository interface for the entity class "ParticipantDetails"
public interface IParticipantsRepository
{
    ParticipantDetails CreateParticipant(ParticipantDetails participant);

    ParticipantDetails GetParticipant(string id);
    ParticipantDetails GetParticipantByUsername(string username);
}