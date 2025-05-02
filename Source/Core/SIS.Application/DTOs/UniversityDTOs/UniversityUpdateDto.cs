namespace SIS.Application.DTOs.UniversityDTOs
{
    public class UniversityUpdateDto
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public required string Address { get; set; }
        public required string Domain { get; set; }
        public required string RectorId { get; set; }
    }
}
