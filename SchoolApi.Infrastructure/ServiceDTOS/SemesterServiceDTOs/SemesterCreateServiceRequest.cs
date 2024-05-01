namespace SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs
{
    public class SemesterCreateServiceRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public SemesterCreateServiceRequest()
        {
            id = Guid.NewGuid().ToString();
            name = string.Empty;
        }
    }
}