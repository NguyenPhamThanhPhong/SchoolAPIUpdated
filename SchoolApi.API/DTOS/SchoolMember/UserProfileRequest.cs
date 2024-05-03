namespace SchoolApi.API.DTOS.SchoolMember
{
    public class UserProfileRequest
    {
#pragma warning disable CS8618
        public string name { get; set; }
        public string? avatarUrl { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? joinYear { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string program { get; set; }
        public string facultyId { get; set; }
        public string IDcard { get; set; }

    }
}
