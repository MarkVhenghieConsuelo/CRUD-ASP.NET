using System.ComponentModel.DataAnnotations;

namespace BarangaySystem.Model.Entities
{
    public class Education
    {
        [Key]
        public int educationId { get; set; }
        public required string educationName { get; set; }

        public ICollection<Resident> Residents { get; set; }
    }
}
