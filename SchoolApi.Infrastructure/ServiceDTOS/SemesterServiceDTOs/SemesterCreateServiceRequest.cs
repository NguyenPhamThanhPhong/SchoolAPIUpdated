namespace SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs
{
    public class SemesterCreateServiceRequest
    {
        public string name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}