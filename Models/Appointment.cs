using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Дата и время приема")]
        [Required(ErrorMessage = "Дата и время приема обязательны")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime AppointmentDateTime { get; set; }

        [Display(Name = "Продолжительность (минуты)")]
        [Required(ErrorMessage = "Продолжительность обязательна")]
        [Range(1, 480, ErrorMessage = "Продолжительность должна быть от 1 до 480 минут")]
        public int DurationMinutes { get; set; } = 30;

        [Display(Name = "Статус")]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Created;

        [Display(Name = "Примечания")]
        [StringLength(1000, ErrorMessage = "Примечания не должны превышать 1000 символов")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        [Display(Name = "ID регистратора")]
        [Required(ErrorMessage = "ID регистратора обязателен")]
        public Guid ScheduledByRegistrarId { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum AppointmentStatus
    {
        [Display(Name = "Создана")]
        Created,

        [Display(Name = "Запланирована")]
        Scheduled,

        [Display(Name = "Отменена")]
        Canceled,

        [Display(Name = "Завершена")]
        Completed
    }

    public class DoctorSchedule
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Дата расписания")]
        [Required(ErrorMessage = "Дата расписания обязательна")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "Время начала")]
        [Required(ErrorMessage = "Время начала обязательно")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Время окончания")]
        [Required(ErrorMessage = "Время окончания обязательно")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Доступен")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Максимум записей")]
        [Required(ErrorMessage = "Максимальное количество записей обязательно")]
        [Range(1, 50, ErrorMessage = "Максимум записей должен быть от 1 до 50")]
        public int MaxAppointments { get; set; } = 10;

        [Display(Name = "Забронировано записей")]
        [Range(0, 50, ErrorMessage = "Количество забронированных записей должно быть от 0 до 50")]
        public int BookedAppointments { get; set; } = 0;
    }
}
