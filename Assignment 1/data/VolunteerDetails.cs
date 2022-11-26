using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.data;

/**
 * Class representing a single row in the Volunteer table.
 */
public class VolunteerDetails
{
    [Key]
    public int VolunteerId { get; set; }

    [Required] public string VolunteerType { get; set; }

    public virtual ParticipantDetails ParticipantDetails { get; set; }
    
    public virtual string ParticipantId { get; set; }
}