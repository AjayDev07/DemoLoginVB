using System.ComponentModel.DataAnnotations;

namespace Mousetrackfunctionality.Models
{
    public class MouseActivity
    {
        [Key]
            public int Id { get; set; }
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
            public DateTime Timestamp { get; set; }
        
    }
}
