using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {

        //Metodos para comunicacion con la Capa Datos


        //Metodo insertar que llama al metodo Insertar de la clase DTrabajador
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email,string acceso,
            string usuario,string password)
        {
            DTrabajador obj = new DTrabajador();

            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_Nacimiento = fecha_nacimiento;
            
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Password = password;

            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DTrabajador
        //de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email,string acceso,string usuario,string password)
        {
            DTrabajador obj = new DTrabajador();

            obj.Idtrabajador = idtrabajador;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_Nacimiento = fecha_nacimiento;
          
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Password = password;


            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DTrabajador
        //de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador obj = new DTrabajador();

            obj.Idtrabajador = idtrabajador;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DTrabajador
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //Metodo BuscarApellidos que llama al metodo BuscarApellidos
        //de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarApellidos(obj);
        }

        //Metodo Buscarnum_documento que llama al metodo Buscarnum_documento
        //de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {

            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.Buscar_Num_Documento(obj);

        }


        /// <summary>
        /// metodo para el login que se comunica con el metodo login de la capa Datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static DataTable Login(string usuario,string password)
        {

            DTrabajador obj = new DTrabajador();
            obj.Usuario = usuario;
            obj.Password = password;
            return obj.Login(obj);

        }

    }
}
