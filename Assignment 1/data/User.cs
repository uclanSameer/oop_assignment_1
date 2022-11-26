using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.data;

// User model class with username and password
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string UserId { get; set; }

    [StringLength(20)] [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }

    public ParticipantDetails ParticipantDetails { get; set; }
}