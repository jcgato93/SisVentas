using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Metodo insertar que llama al metodo Insertar de la clase DPresentacion
        //de la CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();

            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DPresentacion
        //de la CapaDatos
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();

            obj.Idpresentacion = idpresentacion;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DPresentacion
        //de la CapaDatos
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion obj = new DPresentacion();

            obj.Idpresentacion = idpresentacion;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DPresentacion
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //Metodo BuscarNombre que llama al metodo BuscarNombre
        //de la clase DPresentacion de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion obj = new DPresentacion();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }

    }
}
