using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LaboratoryResult
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID медицинского случая")]
        [Required(ErrorMessage = "ID медицинского случая обязателен")]
        public Guid MedicalCaseId { get; set; }

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "Тип анализа")]
        [Required(ErrorMessage = "Тип анализа обязателен")]
        [StringLength(100, ErrorMessage = "Тип анализа не должен превышать 100 символов")]
        public string AnalysisType { get; set; } = string.Empty;

        [Display(Name = "Результаты (JSON)")]
        [Required(ErrorMessage = "Результаты анализа обязательны")]
        [DataType(DataType.MultilineText)]
        public string ResultValueJson { get; set; } = string.Empty;

        [Display(Name = "Дата результата")]
        [Required(ErrorMessage = "Дата результата обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime ResultDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "ID лаборанта")]
        [Required(ErrorMessage = "ID лаборанта обязателен")]
        public Guid PerformedByLabAssistantId { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class AdditionalInvestigation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID медицинского случая")]
        [Required(ErrorMessage = "ID медицинского случая обязателен")]
        public Guid MedicalCaseId { get; set; }

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid RequestedByDoctorId { get; set; }

        [Display(Name = "Тип исследования")]
        [Required(ErrorMessage = "Тип исследования обязателен")]
        [StringLength(100, ErrorMessage = "Тип исследования не должен превышать 100 символов")]
        public string InvestigationType { get; set; } = string.Empty;

        [Display(Name = "Дата запроса")]
        [Required(ErrorMessage = "Дата запроса обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Статус")]
        public InvestigationStatus Status { get; set; } = InvestigationStatus.Requested;

        [Display(Name = "Результаты")]
        [DataType(DataType.MultilineText)]
        public string? ResultNotes { get; set; }

        [Display(Name = "Дата завершения")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime? CompletionDate { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum InvestigationStatus
    {
        [Display(Name = "Запрошено")]
        Requested,

        [Display(Name = "Завершено")]
        Completed,

        [Display(Name = "Отменено")]
        Canceled
    }

    public class MedicalCase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Дата открытия")]
        [Required(ErrorMessage = "Дата открытия обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime OpeningDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата закрытия")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime? ClosingDate { get; set; }

        [Display(Name = "Статус")]
        public MedicalCaseStatus Status { get; set; } = MedicalCaseStatus.Open;

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Осмотры")]
        public ICollection<Examination> Examinations { get; set; } = new List<Examination>();

        [Display(Name = "Лечения")]
        public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

        [Display(Name = "Консультации")]
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    }

    public enum MedicalCaseStatus
    {
        [Display(Name = "Открыт")]
        Open,

        [Display(Name = "В процессе")]
        InProgress,

        [Display(Name = "Закрыт")]
        Closed
    }
}
