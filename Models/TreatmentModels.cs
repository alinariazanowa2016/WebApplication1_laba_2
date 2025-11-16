using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{


    public class Examination
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID медицинского случая")]
        [Required(ErrorMessage = "ID медицинского случая обязателен")]
        public Guid MedicalCaseId { get; set; }

        [Display(Name = "Дата осмотра")]
        [Required(ErrorMessage = "Дата осмотра обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime ExaminationDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Диагноз")]
        [StringLength(250, ErrorMessage = "Диагноз не должен превышать 250 символов")]
        public string? Diagnosis { get; set; }

        [Display(Name = "Симптомы")]
        [DataType(DataType.MultilineText)]
        public string? Symptoms { get; set; }

        [Display(Name = "Примечания к осмотру")]
        [DataType(DataType.MultilineText)]
        public string? ExaminationNotes { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public MedicalCase? MedicalCase { get; set; }
    }

    public class Treatment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID медицинского случая")]
        [Required(ErrorMessage = "ID медицинского случая обязателен")]
        public Guid MedicalCaseId { get; set; }

        [Display(Name = "Дата назначения")]
        [Required(ErrorMessage = "Дата назначения обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime PrescriptionDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Лекарство")]
        [Required(ErrorMessage = "Название лекарства обязательно")]
        [StringLength(200, ErrorMessage = "Название лекарства не должно превышать 200 символов")]
        public string Medication { get; set; } = string.Empty;

        [Display(Name = "Дозировка")]
        [Required(ErrorMessage = "Дозировка обязательна")]
        [StringLength(100, ErrorMessage = "Дозировка не должна превышать 100 символов")]
        public string Dosage { get; set; } = string.Empty;

        [Display(Name = "Инструкции")]
        [DataType(DataType.MultilineText)]
        public string? Instructions { get; set; }

        [Display(Name = "Длительность (дни)")]
        [Required(ErrorMessage = "Длительность лечения обязательна")]
        [Range(1, 365, ErrorMessage = "Длительность должна быть от 1 до 365 дней")]
        public int DurationDays { get; set; }

        [Display(Name = "ID врача")]
        [Required(ErrorMessage = "ID врача обязателен")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public MedicalCase? MedicalCase { get; set; }
    }

    public class Consultation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID медицинского случая")]
        [Required(ErrorMessage = "ID медицинского случая обязателен")]
        public Guid MedicalCaseId { get; set; }

        [Display(Name = "Дата консультации")]
        [Required(ErrorMessage = "Дата консультации обязательна")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime ConsultationDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "ID консультирующего врача")]
        [Required(ErrorMessage = "ID консультирующего врача обязателен")]
        public Guid ConsultingDoctorId { get; set; }

        [Display(Name = "Резюме консультации")]
        [Required(ErrorMessage = "Резюме консультации обязательно")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; } = string.Empty;

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public MedicalCase? MedicalCase { get; set; }
    }

    public class PatientCard
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "Аллергии")]
        [DataType(DataType.MultilineText)]
        public string? Allergies { get; set; }

        [Display(Name = "Хронические заболевания")]
        [DataType(DataType.MultilineText)]
        public string? ChronicDiseases { get; set; }

        [Display(Name = "Текущие лекарства")]
        [DataType(DataType.MultilineText)]
        public string? CurrentMedications { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
