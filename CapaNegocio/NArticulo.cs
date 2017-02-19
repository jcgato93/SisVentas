using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using CapaDatos;
using System.Data;

namespace CapaNegocio
{
     public class NArticulo
    {
        //Metodo insertar que llama al metodo Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string codigo, string nombre, string descripcion,byte[] imagen,int idcategoria,int idpresentacion)
        {
            DArticulo obj = new DArticulo();

            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;
            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();

            obj.Idarticulo = idarticulo;
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;
            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            DArticulo obj = new DArticulo();

            obj.Idarticulo = idarticulo;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Metodo BuscarNombre que llama al metodo BuscarNombre
        //de la clase DArticulo de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo obj = new DArticulo();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
    }
}
