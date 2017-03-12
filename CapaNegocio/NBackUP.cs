using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NBackUP
    {
        public NBackUP()
        {
        
        }
        /// <summary>
        /// Se comunica con la CapaDatos 
        /// Para realizar la copia de segurida
        /// </summary>
        /// <returns>Devuelve el String De confirmacion</returns>
        public static string Back_UP()
        {
            DBackUp obj = new DBackUp();
        
            return  obj.Back_Up();
        }

    }
}
