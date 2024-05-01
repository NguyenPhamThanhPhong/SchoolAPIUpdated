namespace SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs
{
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
