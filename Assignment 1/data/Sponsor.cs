using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.data;

/**
 * Data class for a single row in the database table for sponsor with name and money
 */
public class Sponsor
{
    [Key] public string SponsorId;

    [Required] public string Name { get; set; }

    [Required] public double Money { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Money)}: {Money}";
    }
}