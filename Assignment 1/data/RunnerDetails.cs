using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.data;

/**
 * Data class with
 * runner id as primary key and
 * runner position as field
 * and Sponsor name as field  with
 * one to one relationship with ParticipantDetails class 
 */
public class RunnerDetails
{
    [Key]
    [ForeignKey("ParticipantDetails")]
    public int RunnerId { get; set; }

    public Status Status { get; set; }
    
    public string? SponsorId { get; set; }

    public string? Costume { get; set; }

    [Required] public RankType RankType { get; set; }

    public int? WorldRank { get; set; }
    public virtual ParticipantDetails ParticipantDetails { get; set; }
    
    public virtual string ParticipantDetailsId { get; set; }
}