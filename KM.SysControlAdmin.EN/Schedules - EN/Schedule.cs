﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;


#endregion

namespace KM.SysControlAdmin.EN.Schedules___EN
{
    public class Schedule
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        [Display(Name = "Hora de Inicio")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es requerida")]
        [Display(Name = "Hora de Fin")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        #endregion
    }
}