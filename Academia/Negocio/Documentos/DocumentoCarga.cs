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
using sage.ew.interficies;
using sage.ew.functions;
using sage.ew.formul.Forms;
using sage.ew.reports;
using System.IO;
using sage.ew.usuario;
using System.Reflection;
using sage.ew.ewbase.Clases;
using sage.ew.ewbase.Attributes;
using System.ComponentModel.DataAnnotations;

namespace sage.addons.Academia.Negocio.Documentos
{
    public partial class DocumentoCarga : DocumentoBase
    {       
        #region Propiedades públicas

        /// <summary>
        /// _Ejercicio
        /// </summary>
		[FieldName("Ejercicio")]
        [DisplayName("EJERCICIO")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Ejercicio
        {
           get
            {
                if (_lisCampos.ContainsKey("EJERCICIO"))
                {
                    return Convert.ToString(_lisCampos["EJERCICIO"]._NewVal);
                }
                else
                {
                     return String.Empty;
                }
            }
            set
            {
                if (_lisCampos.ContainsKey("EJERCICIO"))
                {			
					

                    _lisCampos["EJERCICIO"]._NewVal = value;                                                         
                }
            }
        }

        /// <summary>
        /// _Empresa
        /// </summary>
		[FieldName("Empresa")]
        [DisplayName("EMPRESA")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Empresa
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Empresa))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Empresa)), value);
            }
        }

        /// <summary>
        /// _Numero
        /// </summary>
		[FieldName("Numero")]
        [DisplayName("Número")][ReportProperty("Numero", "", "Número:")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Numero
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Numero))));
            }
            set
            {
				                    AsignarValoresClave();
                    value = value.PadLeft(10);

                // Descomentar para _Numero de documento
                // value = value.PadLeft(10);

				_Campo(GetFieldName(nameof(_Numero)), value);
            }
        }

        /// <summary>
        /// _Fecha
        /// </summary>
		[FieldName("Fecha")]
        [DisplayName("Fecha")][ReportProperty("Fecha", "", "Fecha:")]
        public DateTime _Fecha
        {
            get
            {
                return Convert.ToDateTime(_Campo(GetFieldName(nameof(_Fecha))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Fecha)), value);
            }
        }

        /// <summary>
        /// _Cliente
        /// </summary>
		[FieldName("Cliente")]
        [DisplayName("Cliente")][ReportProperty("Cliente", "", "Cliente:")]
        public string _Cliente
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Cliente))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Cliente)), value);
            }
        }

        /// <summary>
        /// _Profesores
        /// </summary>
		[FieldName("Profesores")]
        [DisplayName("Profesores")][ReportProperty("Profesores", "", "Profesores:")]
        public string _Profesores
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Profesores))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Profesores)), value);
            }
        }

        /// <summary>
        /// _Cursos
        /// </summary>
		[FieldName("Cursos")]
        [DisplayName("Cursos")][ReportProperty("Cursos", "", "Cursos:")]
        public string _Cursos
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Cursos))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Cursos)), value);
            }
        }

        /// <summary>
        /// _Horas
        /// </summary>
		[FieldName("Horas")]
        [DisplayName("Horas")][ReportProperty("Horas", "", "Horas:")]
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
        /// _Numeroalbaran
        /// </summary>
		[FieldName("Numeroalbaran")]
        [DisplayName("Número Albarán")][ReportProperty("Numeroalbaran", "", "Número Albarán:")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Numeroalbaran
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Numeroalbaran))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Numeroalbaran)), value);
            }
        }

        /// <summary>
        /// _Serie
        /// </summary>
		[FieldName("Serie")]
        [DisplayName("Serie")][ReportProperty("Serie", "", "Serie:")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Serie
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Serie))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Serie)), value);
            }
        }

        /// <summary>
        /// _Ejercicioalbaran
        /// </summary>
		[FieldName("Ejercicioalbaran")]
        [DisplayName("Ejercicio Albarán")][ReportProperty("Ejercicioalbaran", "", "Ejercicio Albarán:")]
        [DefaultValue("")]
        [DataType(DataType.Text)]
        public string _Ejercicioalbaran
        {
            get
            {
                return Convert.ToString(_Campo(GetFieldName(nameof(_Ejercicioalbaran))));
            }
            set
            {
				
				_Campo(GetFieldName(nameof(_Ejercicioalbaran)), value);
            }
        }



        #endregion Propiedades públicas



        #region Métodos override

        /// <summary>
        /// Métodoo para incializar el documento
        /// </summary>
        protected override void Inicializar()
        {
            // Asignamos las propiedades para el mantenimiento
            this._Clave = "Ejercicio,Empresa,Numero";
            this._DataBase = "ACADEMIA";
            this._Tabla = "c_doccarga";
            this._TituloMantenimiento = "Nuevo documento";

            this._Pantalla = "DocumentoCarga";
            this._FormManteBaseType = typeof(Visual.Forms.frmDocumentoCarga);
            this._DetalleDocumentoType = typeof(DocumentoCargaDetalle);
            this._TypeLinea = typeof(DocumentoCargaDetalle.Linia);

            this._ReportTitlePreview = this._TituloMantenimiento;
            this._ReportBase = "ACADEMIA.DocumentoCarga";
            this._NombreAddon = "ACADEMIA";
        }

        /// <summary>
        /// Asigna los valores de la clave a _Codigo
        /// </summary>
        protected override void AsignarValoresClave()
        {
            if (string.IsNullOrWhiteSpace(_Ejercicio))
                _Ejercicio = EW_GLOBAL._GetVariable("wc_any").ToString();

            if (string.IsNullOrWhiteSpace(_Empresa))
                _Empresa = EW_GLOBAL._GetVariable("wc_empresa").ToString();




			if (_FormMante != null)
				_FormMante._Cargar_Documento();
        }

        /// <summary>
        /// Busca el siguiente número de documento
        /// </summary>
        /// <returns></returns>
        public override bool _Suma_Numero()
        {
            string numero = string.Empty;
            string clave = "";
            bool sumanumero = true;

            // Preparamos la clave de búsqueda del contador
            clave += EW_GLOBAL._GetVariable("wc_any").ToString();
            clave += EW_GLOBAL._GetVariable("wc_empresa").ToString();



            // La pasamos a la base para que busque número
            numero = base._Suma_Numero(clave);

            if (!string.IsNullOrWhiteSpace(numero))
            {
                _Numero = numero;
            }
            else
            {
                sumanumero = false;
            }

            return sumanumero;
        }

        /// <summary>
        /// Resta el numero del contador
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="numeroactual"></param>
        /// <returns></returns>
        public override bool _Resta_Numero(string numeroactual)
        {
            bool restanumeroresult = false;
            string clave = "";

            // Preparamos la clave de búsqueda del contador
            clave += EW_GLOBAL._GetVariable("wc_any").ToString();
            clave += EW_GLOBAL._GetVariable("wc_empresa").ToString();



            restanumeroresult = base._Resta_Numero(clave, numeroactual);

            return restanumeroresult;
		}

        /// <summary>
        /// Comprobar si el documento existe
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public override bool _Comprobar_Existe_Documento(string numero)
        {
            bool existedocumento = false;
            bool sqlresult;
            DataTable numeroDataTable = new DataTable();

            string camposclave = "";
            string clave = "";

            // Preparamos la clave de búsqueda del documento
            camposclave = "ejercicio+empresa";

            clave += EW_GLOBAL._GetVariable("wc_any").ToString();
            clave += EW_GLOBAL._GetVariable("wc_empresa").ToString();




            // Recuperamos el nuevo número
            sqlresult = DB.SQLExec("Select Numero " +
                                "From " + DB.SQLDatabase(this._DataBase, this._Tabla) + " " +
                                "Where  " + camposclave + " = " + DB.SQLString(clave) + " And Numero = " + DB.SQLString(numero.PadLeft(10, ' ')), ref numeroDataTable);

            if (sqlresult && numeroDataTable.Rows.Count > 0)
            {
                existedocumento = true;
            }

            return existedocumento;
        }

        /// <summary>
        /// Elimina el registro actual
        /// </summary>
        /// <returns></returns>
        public override bool _Delete()
        {
            bool borrado = false;
            string numeroactual = _Numero;

            borrado = base._Delete(numeroactual);

            return borrado;
        }

        #endregion Métodos override


    /// <summary>
    /// Clase para tabla relacionada
    /// </summary>
    public class DocumentoCargaDetalle : ewManteTRel<DocumentoCargaDetalle.Linia, DocumentoCargaDetalle.Clave>
    {
        /// <summary>
        /// Se dispara al añadir un nuevo registro cuando el DataSource no es un DataTable
        /// </summary>
        public delegate void _Error_Validar_DocumentoCargaDetalle_Handler(string tcErrorMessage);

        /// <summary>
        /// Se dispara al añadir un nuevo registro cuando el DataSource no es un DataTable
        /// </summary>
        public event _Error_Validar_DocumentoCargaDetalle_Handler _Error_Validar_DocumentoCargaDetalle;

        /// <summary>
        /// Inicializa una nueva intancia de la clase
        /// </summary>
        public DocumentoCargaDetalle()
        {
            CrearEstructura();
        }

        /// <summary>
        /// Inicializa una nueva intancia de la clase y carga los registros correspondientes al código del mantenimiento asociado
        /// </summary>
        public DocumentoCargaDetalle(string codigo)
        {
            CrearEstructura();
        }

        // Definición de la estructura del ManteTRel
        private void CrearEstructura()
        {
            // Events
            this._Error_Validar_Valor += new _Error_Validar_Valor_Handler(DocumentoCargaDetalle__Error_Validar_Valor);

            // Definir la base
            this._DataBase = "ACADEMIA";
            this._Tabla = "d_doccarga";
            this._Condicion = "";
            this._Titulo_Browser = "Buscar Alumnos";

            ewCampoTRel def_Ejercicio = this._AddCampoTRel("_Ejercicio", "Ejercicio");
            def_Ejercicio._AnchoColumna = 7;
            def_Ejercicio._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Ejercicio._Editable = true;
            def_Ejercicio._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Ejercicio._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Ejercicio._ExpandirPunto = false;
            def_Ejercicio._FormatString = "";
            def_Ejercicio._PermiteDuplicados = true;
            def_Ejercicio._TipoColumna = gridColumnsTypes.Texto;
            def_Ejercicio._Titulo = "EJERCICIO";
            def_Ejercicio._Updatable = true;
            def_Ejercicio._Validar_Asignar_Cargando = false;
            def_Ejercicio._Validar_Dato_BaseDatos = "";
            def_Ejercicio._Validar_Dato_Campos = "";
            def_Ejercicio._Validar_Dato_CampoTRel_Asignar = "";
            def_Ejercicio._Validar_Dato_Clave = "";
            def_Ejercicio._Validar_Dato_Tabla = "";
            def_Ejercicio._Visible = false;
            
            ewCampoTRel def_Empresa = this._AddCampoTRel("_Empresa", "Empresa");
            def_Empresa._AnchoColumna = 7;
            def_Empresa._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Empresa._Editable = true;
            def_Empresa._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Empresa._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Empresa._ExpandirPunto = false;
            def_Empresa._FormatString = "";
            def_Empresa._PermiteDuplicados = true;
            def_Empresa._TipoColumna = gridColumnsTypes.Texto;
            def_Empresa._Titulo = "EMPRESA";
            def_Empresa._Updatable = true;
            def_Empresa._Validar_Asignar_Cargando = false;
            def_Empresa._Validar_Dato_BaseDatos = "";
            def_Empresa._Validar_Dato_Campos = "";
            def_Empresa._Validar_Dato_CampoTRel_Asignar = "";
            def_Empresa._Validar_Dato_Clave = "";
            def_Empresa._Validar_Dato_Tabla = "";
            def_Empresa._Visible = false;
            
            ewCampoTRel def_Numero = this._AddCampoTRel("_Numero", "Numero");
            def_Numero._AnchoColumna = 7;
            def_Numero._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Numero._Editable = true;
            def_Numero._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Numero._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Numero._ExpandirPunto = false;
            def_Numero._FormatString = "";
            def_Numero._PermiteDuplicados = true;
            def_Numero._TipoColumna = gridColumnsTypes.Texto;
            def_Numero._Titulo = "NUMERO";
            def_Numero._Updatable = true;
            def_Numero._Validar_Asignar_Cargando = false;
            def_Numero._Validar_Dato_BaseDatos = "";
            def_Numero._Validar_Dato_Campos = "";
            def_Numero._Validar_Dato_CampoTRel_Asignar = "";
            def_Numero._Validar_Dato_Clave = "";
            def_Numero._Validar_Dato_Tabla = "";
            def_Numero._Visible = false;
            
            ewCampoTRel def_Linea = this._AddCampoTRel("_Linea", "Linea");
            def_Linea._AnchoColumna = 7;
            def_Linea._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Linea._Editable = true;
            def_Linea._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Linea._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Linea._ExpandirPunto = false;
            def_Linea._FormatString = "";
            def_Linea._PermiteDuplicados = true;
            def_Linea._TipoColumna = gridColumnsTypes.Entero;
            def_Linea._Titulo = "LINEA";
            def_Linea._Updatable = true;
            def_Linea._Validar_Asignar_Cargando = false;
            def_Linea._Validar_Dato_BaseDatos = "";
            def_Linea._Validar_Dato_Campos = "";
            def_Linea._Validar_Dato_CampoTRel_Asignar = "";
            def_Linea._Validar_Dato_Clave = "";
            def_Linea._Validar_Dato_Tabla = "";
            def_Linea._Visible = false;
            
            ewCampoTRel def_Alumnos = this._AddCampoTRel("_Alumnos", "Alumnos");
            def_Alumnos._AnchoColumna = 7;
            def_Alumnos._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Alumnos._Editable = true;
            def_Alumnos._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Alumnos._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Alumnos._ExpandirPunto = false;
            def_Alumnos._FormatString = "";
            def_Alumnos._PermiteDuplicados = true;
            def_Alumnos._TipoColumna = gridColumnsTypes.Texto;
            def_Alumnos._Titulo = "Alumnos";
            def_Alumnos._Updatable = true;
            def_Alumnos._Validar_Asignar_Cargando = true;
            def_Alumnos._Validar_Dato_BaseDatos = "ACADEMIA";
            def_Alumnos._Validar_Dato_Campos = "NOMBRE";
            def_Alumnos._Validar_Dato_CampoTRel_Asignar = "_Nombreal";
            def_Alumnos._Validar_Dato_Clave = "CODIGO";
            def_Alumnos._Validar_Dato_Tabla = "alumnos";
            def_Alumnos._Visible = true;
            def_Alumnos._Browser = new sage.ew.botones.btBrowser();
            def_Alumnos._Browser._Campos = "Codigo,Nombre";
            def_Alumnos._Browser._Campo_Predet = "Nombre";
            def_Alumnos._Browser._Clave = "CODIGO";
            def_Alumnos._Browser._DataBase = "ACADEMIA";
            def_Alumnos._Browser._Tabla = "alumnos";
            def_Alumnos._Browser._Titulo = "Buscar Alumnos";
            def_Alumnos._Browser._Titulos_Campos = "Código,Nombre";
            def_Alumnos._Mante = new sage.ew.botones.btMante();
            def_Alumnos._Mante._NombreManteNet = "ALUMNOS";
            
            ewCampoTRel def_Nombreal = this._AddCampoTRel("_Nombreal", "");
            def_Nombreal._AnchoColumna = 20;
            def_Nombreal._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Nombreal._Editable = false;
            def_Nombreal._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Nombreal._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Nombreal._ExpandirPunto = false;
            def_Nombreal._FormatString = "";
            def_Nombreal._PermiteDuplicados = true;
            def_Nombreal._TipoColumna = gridColumnsTypes.Texto;
            def_Nombreal._Titulo = "Nombre";
            def_Nombreal._Updatable = false;
            def_Nombreal._Validar_Asignar_Cargando = false;
            def_Nombreal._Validar_Dato_BaseDatos = "";
            def_Nombreal._Validar_Dato_Campos = "";
            def_Nombreal._Validar_Dato_CampoTRel_Asignar = "";
            def_Nombreal._Validar_Dato_Clave = "";
            def_Nombreal._Validar_Dato_Tabla = "";
            def_Nombreal._Visible = true;
            
            ewCampoTRel def_Nif = this._AddCampoTRel("_Nif", "Nif");
            def_Nif._AnchoColumna = 12;
            def_Nif._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Nif._Editable = true;
            def_Nif._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Nif._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Nif._ExpandirPunto = false;
            def_Nif._FormatString = "";
            def_Nif._PermiteDuplicados = true;
            def_Nif._TipoColumna = gridColumnsTypes.Texto;
            def_Nif._Titulo = "N.I.F.";
            def_Nif._Updatable = true;
            def_Nif._Validar_Asignar_Cargando = false;
            def_Nif._Validar_Dato_BaseDatos = "";
            def_Nif._Validar_Dato_Campos = "";
            def_Nif._Validar_Dato_CampoTRel_Asignar = "";
            def_Nif._Validar_Dato_Clave = "";
            def_Nif._Validar_Dato_Tabla = "";
            def_Nif._Visible = true;
            

        }

		// Captura el error al validar un valor introducido.
        private void DocumentoCargaDetalle__Error_Validar_Valor(string errorMessage)
        {
            if (_Error_Validar_DocumentoCargaDetalle != null)
            {
                _Error_Validar_DocumentoCargaDetalle(errorMessage);
                _Refresh();
            }
        }

        /// <summary>
        /// Establecer valores de claves
        /// </summary>
        public override void _Load()
        {
            DocumentoCarga document = (DocumentoCarga)_ewMantePrincipal;
            
			                this._Claves._Ejercicio._Valor = document._Ejercicio;
                this._Claves._Empresa._Valor = document._Empresa;
                this._Claves._Numero._Valor = document._Numero;


            base._Load();
        }

        /// <summary>
        /// Campos clave para registros únicos y carga de registros
        /// </summary>
        public class Clave : IClaves
        {
                /// <summary>
                /// Ejercicio
                /// </summary>
                public ClaveTRel _Ejercicio { get; set; }
                
                /// <summary>
                /// Empresa
                /// </summary>
                public ClaveTRel _Empresa { get; set; }
                
                /// <summary>
                /// Numero
                /// </summary>
                public ClaveTRel _Numero { get; set; }
                
                /// <summary>
                /// Linea
                /// </summary>
                public ClaveTRel _Linea { get; set; }
                


                /// <summary>
                /// Inicializa una nueva instancia de la clase
                /// </summary>
                public Clave()
                {
                    // Definición de las propiedades de cada una de les claves

                    // Ejercicio
                    _Ejercicio = new ClaveTRel();
                    _Ejercicio._EsFiltro = true;
                
                    // Empresa
                    _Empresa = new ClaveTRel();
                    _Empresa._EsFiltro = true;
                
                    // Numero
                    _Numero = new ClaveTRel();
                    _Numero._EsFiltro = true;
                
                    // Linea
                    _Linea = new ClaveTRel();
                    _Linea._EsCampoLinea = true;
                

                }
        }

        /// <summary>
        /// Definir la estructura de las líneas
        /// </summary>
        public class Linia : ILinTRel
        {
        /// <summary>
        /// _Ejercicio
        /// </summary>
		
        public string _Ejercicio
        {
            get
            {
                 return _privateEjercicio;
            }
            set
            {
                _privateEjercicio = value;
            }
        }
        private string _privateEjercicio = "";

        /// <summary>
        /// _Empresa
        /// </summary>
		
        public string _Empresa
        {
            get
            {
                 return _privateEmpresa;
            }
            set
            {
                _privateEmpresa = value;
            }
        }
        private string _privateEmpresa = "";

        /// <summary>
        /// _Numero
        /// </summary>
		
        public string _Numero
        {
            get
            {
                 return _privateNumero;
            }
            set
            {
                _privateNumero = value;
            }
        }
        private string _privateNumero = "";

        /// <summary>
        /// _Linea
        /// </summary>
		
        public Int32 _Linea
        {
            get
            {
                 return _privateLinea;
            }
            set
            {
                _privateLinea = value;
            }
        }
        private Int32 _privateLinea = 0;

        /// <summary>
        /// _Alumnos
        /// </summary>
		[ReportProperty("Alumnos", "", "Alumnos")]
        public string _Alumnos
        {
            get
            {
                 return _privateAlumnos;
            }
            set
            {
                if (_privateAlumnos.Trim() != value.Trim())
                {

                    if (loParent != null)
                    {
                        object loNewValor;
                        if (loParent.CamposTRel_Validar_Valor("_Alumnos", value, this, out loNewValor))
                        {
                            value = _privateAlumnos;
                        }
                        else if (loNewValor != null)
                        {
                            value = Convert.ToString(loNewValor);
                        }
                    }
                }

                if (_privateAlumnos.Trim() != value.Trim())
                {
                    _privateAlumnos = value;
                    loParent._Exportar_Null();
                }
;
            }
        }
        private string _privateAlumnos = "";

        /// <summary>
        /// _Nombreal
        /// </summary>
		[ReportProperty("Nombreal", "", "Nombre")]
        public string _Nombreal
        {
            get
            {
                 return _privateNombreal;
            }
            set
            {
                _privateNombreal = value;
            }
        }
        private string _privateNombreal = "";

        /// <summary>
        /// _Nif
        /// </summary>
		[ReportProperty("Nif", "", "N.I.F.")]
        public string _Nif
        {
            get
            {
                 return _privateNif;
            }
            set
            {
                _privateNif = value;
            }
        }
        private string _privateNif = "";

		 

            private DocumentoCargaDetalle loParent;
            /// <summary>
            /// Objeto padre a la instancia.
            /// </summary>
            public object _Parent
            {
                get { return loParent; }
                set { loParent = (DocumentoCargaDetalle)value; }
            }

            /// <summary>
            /// Inicializa una nueva intancia de la clase
            /// </summary>
            public Linia()
            {

            }

            /// <summary>
            /// Devuelve si la línea está completa
            /// </summary>
            /// <returns></returns>
            public bool Fila_Plena()
            {
                bool lbFilaPlena = true;

                //lbFilaPlena = !string.IsNullOrWhiteSpace(campo);

                return lbFilaPlena;
            }
        }
    }

    }
}