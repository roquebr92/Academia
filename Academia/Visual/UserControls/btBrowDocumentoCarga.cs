using sage.ew.db;
using sage.ew.global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Browser de Documento
    /// </summary>
    public class btBrowDocumentoCarga : sage.ew.botones.btBrowDocumentoBase
    {
        private string empresa = EW_GLOBAL._GetVariable("wc_empresa").ToString();
        private string ejercicio= EW_GLOBAL._GetVariable("wc_any").ToString();

        /// <summary>
        /// Rellena las propiedades necesarias para el browser
        /// </summary>
        protected override void _PopulateBrowser()
        {
            base._PopulateBrowser();
            
            this._Clave = "NUMERO";
            this._DataBase = "ACADEMIA";
            this._Tabla = "c_doccarga";
            this._Condicion = "EMPRESA = " + DB.SQLString(empresa);
            this._Titulo = "DocumentoCarga";

            this._Campos = "Numero, Fecha, Cliente, Profesores, Cursos, Horas, Numeroalbaran, Serie, Ejercicioalbaran";
            this._OrderBy = "NUMERO desc";
            this._Campo_Predet = "NUMERO";

            this._Titulos_Campos = "Número, Fecha, Cliente, Profesores, Cursos, Horas, Número Albarán, Serie, Ejercicio Albarán";

            this._GroupBy = "";            
        }

        /// <summary>
        /// Cargar el nuevo documento
        /// </summary>
        /// <returns></returns>
        protected override bool _Cargar_Documento(bool aceptar)
        {
            aceptar = base._Cargar_Documento(aceptar);

            if (aceptar)
            {
                if (this._Codigo == this._Documento._Numero)
                {
                    return false;
                }

                this._Documento._Abandonar_Documento();
                this._Documento._Numero = this._Codigo;
            }

            return aceptar;
        }
    }
}
