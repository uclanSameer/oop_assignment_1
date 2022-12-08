using System.Collections.Generic;
using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * CRUD repository for the {@link Assignment_1.data.Sponsor} entity.
 */
public interface ISponsorRepository
{
    void Create(Sponsor sponsor);

    Sponsor Read(string? id);

    IEnumerable<Sponsor> FindAll();
}