using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * CRUD repository for the {@link Assignment_1.data.VolunteerDetails} entity.
 */
public interface IVolunteerRepository
{
    void create(VolunteerDetails volunteer);

    VolunteerDetails read(int id);

    void update(VolunteerDetails volunteer);

    void delete(int id);
}