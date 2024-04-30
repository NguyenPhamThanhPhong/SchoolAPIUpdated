namespace SchoolApi.API.DTOS.SchoolMember
{
    public class UserProfileRequest
    {
        public string name { get; set; }
        public string? avatarUrl { get; set; }
        public IFormFile? file { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? joinYear { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string program { get; set; }
    }
}
