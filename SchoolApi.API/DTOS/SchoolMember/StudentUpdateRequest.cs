namespace SchoolApi.API.DTOS.SchoolMember
{
#pragma warning disable CS8618
    public class StudentUpdateRequest
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public UserProfileRequest userProfile { get; set; }
    }
}
