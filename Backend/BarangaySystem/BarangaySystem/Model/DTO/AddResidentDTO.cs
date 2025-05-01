namespace BarangaySystem.Model.DTO
{
    public class AddResidentDTO
    {
        public required string residentName { get; set; }
        public required string residentAddress { get; set; }
        public DateTime? residentDOB { get; set; }
        public string? residentGender { get; set; }
        public int? residentEducation { get; set; }
    }
}
