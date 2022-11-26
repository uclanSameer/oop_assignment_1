using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * CRUD repository for the {@link Assignment_1.data.Sponsor} entity.
 */
public interface ISponsorRepository
{
    void create(Sponsor sponsor);

    Sponsor read(string id);

    Sponsor[] findAll();

    void update(Sponsor sponsor);

    void delete(int id);
}