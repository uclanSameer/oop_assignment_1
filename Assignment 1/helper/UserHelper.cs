using System.Web.Helpers;
using Assignment_1.data;

namespace Assignment_1.helper;

public static class UserHelper
{
    public static User BuildUser(UserDetails userDetails)
    {
        return new User()
        {
            // hash the password before saving it for security reasons
            Password = Crypto.HashPassword(userDetails.Password),
            Username = userDetails.Username,
            Type = userDetails.Type
        };
    }
}