using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sage.ew.botones;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Browser del mantenimiento de profesores
    /// </summary>
    public class browserprofesores : btBrowser
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public browserprofesores()
        {
            this._Campos = "Codigo,Nombre";
            this._Campo_Predet = "Nombre";
            this._Clave = "Codigo";
            this._DataBase = "ACADEMIA";
            this._Tabla = "profesores";
            this._Titulo = "Listado de mantenimiento de profesores";
            this._Titulos_Campos = "Código,Nombre";
        }
    }
}
