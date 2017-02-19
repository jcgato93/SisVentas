using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Metodos para comunicacion con la Capa Datos


        //Metodo insertar que llama al metodo Insertar de la clase DCliente
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,string tipo_documento,string num_documento,
            string direccion,string telefono,string email)
        {
            DCliente obj = new DCliente();

            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_Nacimiento = fecha_nacimiento;
            obj.Tipo_Documento = tipo_documento;
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;


            return obj.Insertar(obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            DCliente obj = new DCliente();

            obj.Idcliente=idcliente;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_Nacimiento = fecha_nacimiento;
            obj.Tipo_Documento = tipo_documento;
            obj.Num_Documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;


            return obj.Editar(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DCliente obj = new DCliente();

            obj.Idcliente = idcliente;
            return obj.Eliminar(obj);
        }

        //Metodo Mostrar que llama al Metodo de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Metodo BuscarApellidos que llama al metodo BuscarApellidos
        //de la clase DCliente de la CapaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente obj = new DCliente();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarApellidos(obj);
        }

        //Metodo Buscarnum_documento que llama al metodo Buscarnum_documento
        //de la clase DCliente de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {

            DCliente obj = new DCliente();
            obj.TextoBuscar = textobuscar;
            return obj.Buscar_Num_Documento(obj);

        }

    }
}
