using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NProveedor
    {
        //Metodo insertar que llama al metodo Insertar de la clase DProveedor
        //de la CapaDatos
        public static string Insertar(string razon_proveedor, string sector_comercial,string tipo_documento,string num_documento,string direccion,string telefono,string email,string url)
        {
            DProveedor obj = new DProveedor();

            obj.Razon_Social = razon_proveedor;
            obj.Sector_Comercial = sector_comercial;
            obj.Tipo_Documento = tipo_documento;
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DProveedor
        //de la CapaDatos
        public static string Editar(int idproveedor,string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();

            obj.Idproveedor = idproveedor;
            obj.Razon_Social = razon_proveedor;
            obj.Sector_Comercial = sector_comercial;
            obj.Tipo_Documento = tipo_documento;
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DProveedor
        //de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor obj = new DProveedor();

            obj.Idproveedor = idproveedor;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DProveedor
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Metodo BuscarRazon_social que llama al metodo BuscarRazon_social
        //de la clase DProveedor de la CapaDatos
        public static DataTable BuscarRazon_social(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.TextoBuscar = textobuscar;
            return obj.Buscar_Razon_Social(obj);
        }

        //Metodo Buscarnum_documento que llama al metodo Buscarnum_documento
        //de la clase DProveedor de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            
                DProveedor obj = new DProveedor();
                obj.TextoBuscar = textobuscar;
                return obj.Buscar_Num_Documento(obj);
            
        }

    }
}
