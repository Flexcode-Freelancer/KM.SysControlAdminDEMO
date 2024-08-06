#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KM.SysControlAdmin.EN.Schedules___EN;
using KM.SysControlAdmin.EN.Trainer___EN;


#endregion

namespace KM.SysControlAdmin.EN.Course__EN
{
    public class Course
    {
        #region Atributos de la Entidad
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Codigo es requerido")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Display(Name = "Codigo del Curso")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [DataType(DataType.Currency, ErrorMessage = "Por favor, introduce una precio valido")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Por favor, introduce una fecha válida")]
        [Display(Name = "Hora de Inicio")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Por favor, introduce una fecha válida")]
        [Display(Name = "Hora de Fin")]
        public DateTime EndTime { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Máximo de Estudiantes")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Máximo de Estudiantes debe contener solo números")]
        public string? MaxStudent { get; set; }

        [Required(ErrorMessage = "El horario es requerido")]
        [ForeignKey("Schedule")]
        [Display(Name = "Horario")]
        public int IdSchedule { get; set; }

        [Required(ErrorMessage = "El instructor es requerido")]
        [ForeignKey("Trainer")]
        [Display(Name = "Instructor")]
        public int IdTrainer { get; set; }

        [Required(ErrorMessage = "El estatus es Requerido")]
        [Display(Name = "Estatus")]
        public byte Status { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime DateModification { get; set; }
        #endregion

        public Schedule? Schedule { get; set; } // Propiedad de navegacion
        public Trainer? Trainer { get; set; } // Propiedad de navegacion
    }
}
