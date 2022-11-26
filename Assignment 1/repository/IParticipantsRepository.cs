using Assignment_1.data;

namespace Assignment_1.repository;

// repository interface for the entity class "ParticipantDetails"
public interface IParticipantsRepository
{
    ParticipantDetails createParticipant(ParticipantDetails participant);

    ParticipantDetails getParticipant(int id);

    void updateParticipant(ParticipantDetails participant);

    void deleteParticipant(int id);
}