using System;
using System.Linq;
using Assignment_1.data;

namespace Assignment_1.repository.Impl;

public class UserRepository : IUserRepository, IDisposable
{
    private readonly DataContext _context = new();

    private bool _disposed;

    public User getUser(string username)
    {
        return _context
                   .Users.FirstOrDefault(u => u.Username == username) ??
               throw new InvalidOperationException();
    }

    public User addUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return getUser(user.Username);
    }

    public void updateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void deleteUser(User user)
    {
        _context.Users.Remove(user);
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