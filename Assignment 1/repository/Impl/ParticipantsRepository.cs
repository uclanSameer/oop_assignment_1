using System;
using System.Linq;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class ParticipantsRepository : IParticipantsRepository, IDisposable
{
    private readonly DataContext _context = new();
    private bool _disposed;

    public ParticipantDetails CreateParticipant(ParticipantDetails participant)
    {
        _context.ParticipantsDetails.Add(participant);
        _context.SaveChanges();
        return _context.ParticipantsDetails.First(details => details.UserId == participant.UserId);
    }

    public ParticipantDetails GetParticipant(string id)
    {
        return _context.ParticipantsDetails.Find(id)
               ?? throw new NotImplementedException();
    }

    public ParticipantDetails GetParticipantByUsername(string username)
    {
        return _context.ParticipantsDetails.FirstOrDefault(details => details.FullName == username)
               ?? throw new NotImplementedException();
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