using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = new DashboardViewModel
            {
                TotalPatients = await _context.Patients.CountAsync(),
                TodayAppointments = await _context.Appointments
                    .Where(a => a.AppointmentDateTime.Date == DateTime.Today)
                    .CountAsync(),
                ActiveMedicalCases = await _context.MedicalCases
                    .Where(mc => mc.Status == MedicalCaseStatus.Open || mc.Status == MedicalCaseStatus.InProgress)
                    .CountAsync(),
                PendingLaboratoryResults = await _context.AdditionalInvestigations
                    .Where(ai => ai.Status == InvestigationStatus.Requested)
                    .CountAsync()
            };

            // Получаем ближайшие приемы
            var recentAppointments = await _context.Appointments
                .Where(a => a.AppointmentDateTime >= DateTime.Now)
                .OrderBy(a => a.AppointmentDateTime)
                .Take(5)
                .ToListAsync();

            foreach (var appointment in recentAppointments)
            {
                var patient = await _context.Patients.FindAsync(appointment.PatientId);
                dashboard.RecentAppointments.Add(new AppointmentViewModel
                {
                    Id = appointment.Id,
                    PatientName = patient != null ? $"{patient.LastName} {patient.FirstName}" : "Неизвестный пациент",
                    AppointmentDateTime = appointment.AppointmentDateTime,
                    Notes = appointment.Notes ?? "",
                    Status = GetAppointmentStatusRussian(appointment.Status),
                    StatusColor = GetAppointmentStatusColor(appointment.Status)
                });
            }

            // Получаем недавно добавленных пациентов
            var recentPatients = await _context.Patients
                .OrderByDescending(p => p.RegistrationDate)
                .Take(5)
                .ToListAsync();

            foreach (var patient in recentPatients)
            {
                dashboard.RecentPatients.Add(new PatientViewModel
                {
                    Id = patient.Id,
                    FullName = $"{patient.LastName} {patient.FirstName} {patient.MiddleName}",
                    Age = DateTime.Now.Year - patient.DateOfBirth.Year,
                    PhoneNumber = patient.PhoneNumber ?? "Не указан",
                    RegistrationDate = patient.RegistrationDate
                });
            }

            return View(dashboard);
        }

        private string GetAppointmentStatusRussian(AppointmentStatus status)
        {
            return status switch
            {
                AppointmentStatus.Created => "Создана",
                AppointmentStatus.Scheduled => "Запланирована",
                AppointmentStatus.Completed => "Завершена",
                AppointmentStatus.Canceled => "Отменена",
                _ => "Неизвестно"
            };
        }

        private string GetAppointmentStatusColor(AppointmentStatus status)
        {
            return status switch
            {
                AppointmentStatus.Created => "warning",
                AppointmentStatus.Scheduled => "success",
                AppointmentStatus.Completed => "primary",
                AppointmentStatus.Canceled => "danger",
                _ => "secondary"
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
