using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

using sage.ew.global;
using sage.ew.db;
using sage.ew.ewbase;
using System.Windows.Forms;
using sage.ew.ewbase.Attributes;
using System.ComponentModel.DataAnnotations;

namespace sage.addons.Academia.Negocio.Mantes
{
    public partial class cursos : ewMante
    {
        /// <summary>
        /// Indica si el documento está en uso por otro usuario
        /// </summary>
        public bool _EnUso = false;

        /// <summary>
        /// _Horas
        /// </summary>
		[FieldName("Horas")]
        [DisplayName("Horas")]
        public decimal _Horas
        {
            get
            {
                return Convert.ToDecimal(_Campo(GetFieldName(nameof(_Horas))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Horas)), value);
            }
        }

        /// <summary>
        /// _Observaciones
        /// </summary>
		[FieldName("Observaciones")]
        [DisplayName("Observaciones")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Observaciones
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Observaciones))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Observaciones)), value);
            }
        }



        
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public cursos()
        {
            Inicializar();
        }

        /// <summary>
        /// Constructor con código
        /// </summary>
        /// <param name="tcCodigo"></param>
        public cursos(string tcCodigo)
        {
            Inicializar();

            this._Codigo = tcCodigo;
            this._Load();
        }
    
        private void Inicializar()
        {
            // Asignamos las propiedades para el mantenimiento
            this._Clave = "Codigo";
            this._DataBase = "ACADEMIA";
            this._Tabla = "cursos";
            this._TituloMantenimiento = "Mantenimiento de cursos";

            this._Pantalla = "cursos";
            this._FormManteBaseType = typeof(Visual.Forms.frmcursos);

            this._Codigo = string.Empty;
        }
    }
    
    
}
