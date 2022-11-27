using System;
using System.Linq;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class SponsorRepository : ISponsorRepository, IDisposable
{
    private readonly DataContext _context = new();

    private bool _disposed;

    public void create(Sponsor sponsor)
    {
        _context.Sponsors.Add(sponsor);
        _context.SaveChanges();
    }

    public Sponsor read(string? id)
    {
        return _context.Sponsors.FirstOrDefault(sponsor => sponsor.SponsorId == id) ??
               throw new NotImplementedException();
    }

    public Sponsor[] findAll()
    {
        return _context.Sponsors.ToArray();
    }

    public void update(Sponsor sponsor)
    {
        _context.Sponsors.Update(sponsor);
        _context.SaveChanges();
    }

    public void delete(int id)
    {
        var sponsor = _context.Sponsors.Find(id);
        _context.Sponsors.Remove(sponsor ?? throw new NotImplementedException());
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