namespace LeaveManagementSystem.Web.Models
{
    public class ErrorViewModel
    {
        // this class has 2 properties:
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // show or not
    }
}
