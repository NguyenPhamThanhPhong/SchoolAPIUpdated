namespace SchoolApi.API.DTOS.Semester
{
#pragma warning disable cs8618
    public class SemesterUpdateRequest
    {
        public string name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
