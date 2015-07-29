using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2m.Common.Responses
{
    /// <summary>
    /// Códigos de respuesta para las peticiones HTTP
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Códigos de respuesta  JSON
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// Correcta
            /// </summary>
            Ok = 0,
            /// <summary>
            /// Usuario no Autentificado
            /// </summary>
            NotAuthenticated = 1,
            /// <summary>
            /// Se ha producido un error en la petición
            /// </summary>
            Error = 2
        }
    }

}