using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NCategoria
    {
        //Metodo insertar que llama al metodo Insertar de la clase DCategoria
        //de la CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();

            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DCategoria
        //de la CapaDatos
        public static string Editar(int idcategoria,string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();

            obj.Idcategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DCategoria
        //de la CapaDatos
        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();

            obj.Idcategoria = idcategoria;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
    {
        return new DCategoria().Mostrar();
    }

        //Metodo BuscarNombre que llama al metodo BuscarNombre
        //de la clase DCategoria de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar) 
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
       
    }
}
