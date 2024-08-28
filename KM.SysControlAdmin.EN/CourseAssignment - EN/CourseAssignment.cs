﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KM.SysControlAdmin.EN.Student___EN;
using KM.SysControlAdmin.EN.Course__EN;

#endregion

namespace KM.SysControlAdmin.EN.CourseAssignment___EN
{
    public class CourseAssignment
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        [Required(ErrorMessage = "El Estudiante Es Requerido")]
        [Display(Name = "Estudiante")]
        public int IdStudent { get; set; }

        [ForeignKey("Course")]
        [Required(ErrorMessage = "El Curso Es Requerido")]
        [Display(Name = "Curso")]
        public int IdCourse { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime DateModification { get; set; }
        #endregion

        public Student? Student { get; set; } // Propiedadd de Navegacion

        public Course? Course { get; set; }// Propiedad de Navegacion
    }
}
