namespace SchoolApi.API.DTOS.SchoolMember
{
    public class StudentUpdateRequest
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public UserProfileRequest userProfile { get; set; }
    }
}
