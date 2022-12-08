using System.Collections.Generic;
using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * CRUD repository for Runner entity
 */
public interface IRunnerRepository
{
    void Create(RunnerDetails runner);

    RunnerDetails Read(string participantId);

    List<RunnerDetails> FindAllBySponsorId(string sponserId);

}