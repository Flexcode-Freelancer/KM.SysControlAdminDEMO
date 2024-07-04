﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.EntityFrameworkCore;
using KM.SysControlAdmin.EN.Role___EN;
using KM.SysControlAdmin.EN.User___EN;


#endregion

namespace KM.SysControlAdmin.DAL
{
    public class ContextDB : DbContext
    {
        #region REFERENCIAS DE TABLAS DE LA BD
        //Coleccion que hace referencia a la tabla de la base de datos
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }   
        #endregion

        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=KMSysControlAdminDB;Integrated Security=True;Trust Server Certificate=True"); // String de Conexion
        }
    }
}
