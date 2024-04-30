namespace SchoolApi.API.DTOS.Semester
{
#pragma warning disable CS8618
    public class SemesterCreateRequest
    {
        public string name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
