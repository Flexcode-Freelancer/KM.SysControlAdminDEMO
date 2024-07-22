#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.EN.Trainer___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace KM.SysControlAdmin.DAL.Trainer___DAL
{
    public class TrainerDAL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Trainer trainers)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                bool trainerExists = await ExistTrainer(trainers, dbContext);
                if (trainerExists == false)
                {
                    dbContext.Trainer.Add(trainers);
                    result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
                }
                else
                    throw new Exception("Instructor/Docente Ya Existente, Vuelve a Intentarlo Nuevamente.");
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente De La Base De Datos
        public static async Task<int> UpdateAsync(Trainer trainers)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var trainerDB = await dbContext.Trainer.FirstOrDefaultAsync(m => m.Id == trainers.Id);
                if (trainerDB != null)
                {
                    bool trainerExists = await ExistTrainer(trainers, dbContext);
                    if (trainerExists == false)
                    {
                        trainerDB.Name = trainers.Name;
                        trainerDB.LastName = trainers.LastName;
                        trainerDB.Dui = trainers.Dui;
                        trainerDB.DateOfBirth = trainers.DateOfBirth;
                        trainerDB.Age = trainers.Age;
                        trainerDB.Gender = trainers.Gender;
                        trainerDB.CivilStatus = trainers.CivilStatus;
                        trainerDB.Phone = trainers.Phone;
                        trainerDB.Address = trainers.Address;
                        trainerDB.Status = trainers.Status;
                        trainerDB.CommentsOrObservations = trainers.CommentsOrObservations;
                        trainerDB.DateCreated = trainers.DateCreated;
                        trainerDB.DateModification = trainers.DateModification;
                        trainerDB.ImageData = trainers.ImageData;

                        dbContext.Update(trainerDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Instructutor/Docente Ya Existente, Vuelve a Intentarlo Nuevamente.");
                    }
                }
                else
                {
                    throw new Exception("Instructor/Docente No Encontrado Para Actualizar.");
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(Trainer trainers)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var trainerDB = await dbContext.Trainer.FirstOrDefaultAsync(m => m.Id == trainers.Id);
                if (trainerDB != null)
                {
                    dbContext.Trainer.Remove(trainerDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<Trainer>> GetAllAsync()
        {
            var trainers = new List<Trainer>();
            using (var dbContext = new ContextDB())
            {
                trainers = await dbContext.Trainer.ToListAsync();
            }
            return trainers;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<Trainer> GetByIdAsync(Trainer trainers)
        {
            var trainerDB = new Trainer();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                trainerDB = await dbContext.Trainer.FirstOrDefaultAsync(m => m.Id == trainers.Id);
            }
            return trainerDB!; // Retornamos el Registro Encontrado
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo Para Buscar Por Filtros
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<Trainer> QuerySelect(IQueryable<Trainer> query, Trainer trainers)
        {
            // Por ID
            if (trainers.Id > 0)
                query = query.Where(m => m.Id == trainers.Id);

            if (!string.IsNullOrWhiteSpace(trainers.Name))
                query = query.Where(m => m.Name.Contains(trainers.Name));

            if (!string.IsNullOrWhiteSpace(trainers.LastName))
                query = query.Where(m => m.LastName.Contains(trainers.LastName));

            if (!string.IsNullOrWhiteSpace(trainers.Dui))
                query = query.Where(m => m.Dui.Contains(trainers.Dui));

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para Buscar Registros Existentes
        public static async Task<List<Trainer>> SearchAsync(Trainer trainer)
        {
            var trainers = new List<Trainer>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Trainer.AsQueryable();
                select = QuerySelect(select, trainer);
                trainers = await select.ToListAsync();
            }
            return trainers;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistTrainer(Trainer trainer, ContextDB contextDB)
        {
            bool result = false;
            var trainers = await contextDB.Trainer.FirstOrDefaultAsync(m => m.Dui == trainer.Dui && m.Id != trainer.Id);
            if (trainers != null && trainers.Id > 0 && trainers.Dui == trainer.Dui)
                result = true;
            return result;
        }
        #endregion
    }
}