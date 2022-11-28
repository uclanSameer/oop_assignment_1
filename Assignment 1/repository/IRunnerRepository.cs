using System.Collections.Generic;
using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * CRUD repository for Runner entity
 */
public interface IRunnerRepository
{
    void create(RunnerDetails runner);

    RunnerDetails read(int id);
    RunnerDetails read(string ParticipantId);

    List<RunnerDetails> FindAllBySponsorId(string sponserId);

    void update(RunnerDetails runner);

    void delete(int id);
}