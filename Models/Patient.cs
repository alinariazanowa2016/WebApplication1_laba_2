using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Отчество")]
        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов")]
        public string? MiddleName { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Поле 'Дата рождения' обязательно для заполнения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Поле 'Пол' обязательно для заполнения")]
        [StringLength(10, ErrorMessage = "Пол не должен превышать 10 символов")]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Телефон")]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [StringLength(20, ErrorMessage = "Телефон не должен превышать 20 символов")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        public string? Email { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(250, ErrorMessage = "Адрес не должен превышать 250 символов")]
        public string? Address { get; set; }

        [Display(Name = "Медицинская история")]
        [DataType(DataType.MultilineText)]
        public string? MedicalHistorySummary { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class PatientHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ID пациента")]
        [Required(ErrorMessage = "ID пациента обязателен")]
        public Guid PatientId { get; set; }

        [Display(Name = "Действие")]
        [Required(ErrorMessage = "Действие обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Действие не должно превышать 50 символов")]
        public string Action { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Описание обязательно для заполнения")]
        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Patient? Patient { get; set; }
    }
}
