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
    public partial class alumnos : ewMante
    {
        /// <summary>
        /// Indica si el documento está en uso por otro usuario
        /// </summary>
        public bool _EnUso = false;

        /// <summary>
        /// _Nif
        /// </summary>
		[FieldName("Nif")]
        [DisplayName("N.I.F.")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Nif
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Nif))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Nif)), value);
            }
        }

        /// <summary>
        /// _Direccion
        /// </summary>
		[FieldName("Direccion")]
        [DisplayName("Dirección")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Direccion
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Direccion))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Direccion)), value);
            }
        }

        /// <summary>
        /// _Telefono
        /// </summary>
		[FieldName("Telefono")]
        [DisplayName("Teléfono")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Telefono
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Telefono))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Telefono)), value);
            }
        }

        /// <summary>
        /// _Fechanacimiento
        /// </summary>
		[FieldName("Fechanacimiento")]
        [DisplayName("Fecha Nacimiento")]
        public DateTime _Fechanacimiento
        {
            get
            {
                return Convert.ToDateTime(_Campo(GetFieldName(nameof(_Fechanacimiento))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Fechanacimiento)), value);
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
        public alumnos()
        {
            Inicializar();
        }

        /// <summary>
        /// Constructor con código
        /// </summary>
        /// <param name="tcCodigo"></param>
        public alumnos(string tcCodigo)
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
            this._Tabla = "alumnos";
            this._TituloMantenimiento = "Mantenimiento de alumnos";

            this._Pantalla = "alumnos";
            this._FormManteBaseType = typeof(Visual.Forms.frmalumnos);

            this._Codigo = string.Empty;
        }
    }
    
    
}
