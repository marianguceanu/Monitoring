namespace SDI_App.DTO.PersonDTOs
{
    public class PersonInClass
    {
        public int Id { get; set; } = default!;
        public string CNP { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}