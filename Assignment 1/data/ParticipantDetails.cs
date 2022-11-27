using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.data;

public class ParticipantDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string ParticipantDetailsId { get; set; }

    [StringLength(50)] [Required] public string FullName { get; set; }

    [StringLength(50)] [Required] public string Address { get; set; }

    [RegularExpression("^[0-9]+$", ErrorMessage = "The Phone Number should consists number only")]
    [MinLength(10)]
    [MaxLength(10)]
    [Required]
    public long PhoneNumber { get; set; }

    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The Email is not valid")]
    public string EmailAddress { get; set; }

    public virtual VolunteerDetails VolunteerDetails { get; set; }

    public virtual RunnerDetails RunnerDetails { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
}