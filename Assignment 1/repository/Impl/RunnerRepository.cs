using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class RunnerRepository : IRunnerRepository, IDisposable
{
    private readonly DataContext _context = new();
    private bool _disposed;

    public void Create(RunnerDetails runner)
    {
        _context.RunnerDetails.Add(runner);
        _context.SaveChanges();
    }

    public RunnerDetails read(int id)
    {
        return _context.RunnerDetails.Find(id) ?? throw new NotImplementedException();
    }

    public RunnerDetails Read(string participantId)
    {
        return _context.RunnerDetails.FirstOrDefault(details => details.ParticipantDetailsId == participantId) ??
               throw new NotImplementedException();
    }

    public List<RunnerDetails> FindAllBySponsorId(string sponserId)
    {
        return _context.RunnerDetails.Where(details => details.SponsorId == sponserId).ToList();
    }
    
    public void Update(RunnerDetails runner)
    {
        _context.RunnerDetails.Update(runner);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }
}