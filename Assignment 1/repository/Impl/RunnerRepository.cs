using System;
using System.Linq;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class RunnerRepository : IRunnerRepository, IDisposable
{
    private readonly DataContext _context = new();
    private bool _disposed;

    public void create(RunnerDetails runner)
    {
        _context.RunnerDetails.Add(runner);
        _context.SaveChanges();
    }

    public RunnerDetails read(int id)
    {
        return _context.RunnerDetails.Find(id) ?? throw new NotImplementedException();
    }

    public RunnerDetails read(string ParticipantId)
    {
        return _context.RunnerDetails.FirstOrDefault(details => details.ParticipantDetailsId == ParticipantId) ??
               throw new NotImplementedException();
    }

    public void update(RunnerDetails runner)
    {
        _context.RunnerDetails.Update(runner);
        _context.SaveChanges();
    }

    public void delete(int id)
    {
        _context.RunnerDetails.Remove(read(id));
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