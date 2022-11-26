using System;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class VolunteerRepository : IVolunteerRepository, IDisposable
{
    private readonly DataContext _context = new();
    private bool _disposed = false;

    public void create(VolunteerDetails volunteer)
    {
        _context.VolunteerDetails.Add(volunteer);
        _context.SaveChanges();
    }

    public VolunteerDetails read(int id)
    {
        return _context.VolunteerDetails.Find(id) ?? throw new NotImplementedException();
    }

    public void update(VolunteerDetails volunteer)
    {
        _context.VolunteerDetails.Update(volunteer);
        _context.SaveChanges();
    }

    public void delete(int id)
    {
        var volunteer = _context.VolunteerDetails.Find(id);
        _context.VolunteerDetails.Remove(volunteer ?? throw new NotImplementedException());
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