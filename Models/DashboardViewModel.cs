namespace WebApplication1.Models
{
    public class DashboardViewModel
    {
        public int TotalPatients { get; set; }
        public int TodayAppointments { get; set; }
        public int ActiveMedicalCases { get; set; }
        public int PendingLaboratoryResults { get; set; }
        public List<AppointmentViewModel> RecentAppointments { get; set; } = new();
        public List<PatientViewModel> RecentPatients { get; set; } = new();

        
    }
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StatusColor { get; set; } = "secondary";
    }

    public class PatientViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
    }
}
