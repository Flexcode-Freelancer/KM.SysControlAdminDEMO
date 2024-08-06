#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.EN.Course__EN;
using KM.SysControlAdmin.DAL.Course___DAL;

#endregion

namespace KM.SysControlAdmin.BL.Course___BL
{
    public class CourseBL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> CreateAsync(Course course)
        {
            return await CourseDAL.CreateAsync(course);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> UpdateAsync(Course course)
        {
            return await CourseDAL.UpdateAsync(course);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public async Task<int> DeleteAsync(Course course)
        {
            return await CourseDAL.DeleteAsync(course);
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar Una Lista De Registros
        public async Task<List<Course>> GetAllAsync()
        {
            return await CourseDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo Para Mostrar Un Registro Especifico Bajo Un Id
        public async Task<Course> GetByIdAsync(Course course)
        {
            return await CourseDAL.GetByIdAsync(course);
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public async Task<List<Course>> SearchAsync(Course course)
        {
            return await CourseDAL.SearchAsync(course);
        }
        #endregion

        #region METODO PARA INCLUIR HORARIO E INSTRUCTOR
        public async Task<List<Course>> SearchIncludeScheduleAndTrainerAsync(Course course)
        {
            return await CourseDAL.SearchIncludeScheduleAndTrainerAsync(course);
        }
        #endregion
    }
}
