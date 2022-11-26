using System.Collections.ObjectModel;
using Assignment_1.data;

namespace Assignment_1.service;

public interface IUserService
{
    void save(Participant participant, UserDetails userDetails);

    User findByUsername(string username);

    Collection<Participant> findAll();
}