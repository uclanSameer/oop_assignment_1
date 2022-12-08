using System;
using Assignment_1.data;

namespace Assignment_1.repository;

/**
 * This class is used to store the data of the user
 */
public interface IUserRepository
{
    public User GetUser(string username);
    public User  AddUser(User user);
}