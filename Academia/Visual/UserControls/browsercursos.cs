using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sage.ew.botones;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Browser del mantenimiento de cursos
    /// </summary>
    public class browsercursos : btBrowser
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public browsercursos()
        {
            this._Campos = "Codigo,Nombre";
            this._Campo_Predet = "Nombre";
            this._Clave = "Codigo";
            this._DataBase = "ACADEMIA";
            this._Tabla = "cursos";
            this._Titulo = "Listado de mantenimiento de cursos";
            this._Titulos_Campos = "Código,Nombre";
        }
    }
}
