namespace SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs
{
    public class FacultyCreateServiceRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public FacultyCreateServiceRequest()
        {
            id = Guid.NewGuid().ToString();
            name = string.Empty;
        }

    }
}