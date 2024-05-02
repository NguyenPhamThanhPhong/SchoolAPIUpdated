namespace SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs
{
#pragma warning disable CS8618
    public class FacultyUpdateServiceRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public FacultyUpdateServiceRequest()
        {
            name = string.Empty;
        }
    }
}
