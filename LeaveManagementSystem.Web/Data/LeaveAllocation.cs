namespace LeaveManagementSystem.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; } //FK

        public ApplicationUser Employee { get; set; }
        public string EmployeeId { get; set; } //FK

        public Period Period { get; set; }
        public int PeriodId { get; set; } //FK

        public int Days { get; set; }
    }
}
