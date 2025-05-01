using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarangaySystem.Model.Entities
{
    public class Resident
    {
        [Key]
        public int residentId { get; set; }
        public required string residentName { get; set; }
        public DateTime? residentDOB { get; set; }

        public required string residentAddress { get; set; }
        public required string residentGender { get; set; }

        [ForeignKey("Education")]
        public int? residentEducation { get; set; }

        public Education Education { get; set; }


    }
}
