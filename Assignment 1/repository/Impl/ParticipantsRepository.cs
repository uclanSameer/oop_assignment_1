using System;
using System.Linq;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class ParticipantsRepository : IParticipantsRepository, IDisposable
{
    private DataContext _context = new();
    private bool _disposed;

    public ParticipantDetails createParticipant(ParticipantDetails participant)
    {
        _context.ParticipantsDetails.Add(participant);
        _context.SaveChanges();
        return _context.ParticipantsDetails.First(details => details.UserId == participant.UserId);
    }

    public ParticipantDetails getParticipant(int id)
    {
        return _context.ParticipantsDetails.Find(id)
               ?? throw new NotImplementedException();
    }

    public ParticipantDetails getParticipant(string username)
    {
        return _context.ParticipantsDetails.FirstOrDefault(details => details.FullName == username)
               ?? throw new NotImplementedException();
    }

    public void updateParticipant(ParticipantDetails participant)
    {
        _context.ParticipantsDetails.Update(participant);
        _context.SaveChanges();
    }

    public void deleteParticipant(int id)
    {
        var participant = _context.ParticipantsDetails.Find(id);
        _context.ParticipantsDetails.Remove(participant ?? throw new NotImplementedException());
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