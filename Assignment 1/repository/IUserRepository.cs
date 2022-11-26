using System;
using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * This class is used to store the data of the user
 */
public interface IUserRepository
{
    public User getUser(string username);
    public User  addUser(User user);
    public void updateUser(User user);
    public void deleteUser(User user);
}