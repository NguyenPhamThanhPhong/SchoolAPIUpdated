namespace SchoolApi.API.DTOS.SchoolMember
{
    public class StudentLogRequest
    {
        public string schoolMemberId { get; set; }
        public string schoolClassId { get; set; }
        public float progress { get; set; }
        public float midterm { get; set; }
        public float practice { get; set; }
        public float final { get; set; }
        public float average { get; set; }

    }
}
