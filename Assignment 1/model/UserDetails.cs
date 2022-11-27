namespace Assignment_1.data;

public class UserDetails
{
    public string Username { get; init; }
    public string Password { get; init; }
    public string Type { get; set; }

    public UserDetails(string username, string password, string type)
    {
        Username = username;
        Password = password;
        Type = type;
    }

    public UserDetails()
    {
    }
}