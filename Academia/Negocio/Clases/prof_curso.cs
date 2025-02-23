using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sage.ew.ewbase;
using sage.ew.interficies;

namespace sage.addons.Academia.Negocio.Clases
{
    
    /// <summary>
    /// Clase para tabla relacionada
    /// </summary>
    public class prof_curso : ewManteTRel<prof_curso.Linia, prof_curso.Clave>
    {
        /// <summary>
        /// Se dispara al añadir un nuevo registro cuando el DataSource no es un DataTable
        /// </summary>
        public delegate void _Error_Validar_prof_curso_Handler(string tcErrorMessage);

        /// <summary>
        /// Se dispara al añadir un nuevo registro cuando el DataSource no es un DataTable
        /// </summary>
        public event _Error_Validar_prof_curso_Handler _Error_Validar_prof_curso;

        /// <summary>
        /// Inicializa una nueva intancia de la clase
        /// </summary>
        public prof_curso()
        {
            CrearEstructura();
        }

        /// <summary>
        /// Inicializa una nueva intancia de la clase y carga los registros correspondientes al código del mantenimiento asociado
        /// </summary>
        public prof_curso(string codigo)
        {
            CrearEstructura();
        }

        // Definición de la estructura del ManteTRel
        private void CrearEstructura()
        {
            // Events
            this._Error_Validar_Valor += new _Error_Validar_Valor_Handler(prof_curso__Error_Validar_Valor);

            // Definir la base
            this._DataBase = "ACADEMIA";
            this._Tabla = "prof_curso";
            this._Condicion = "";
            this._Titulo_Browser = "Buscar Curso";

            ewCampoTRel def_Profesor = this._AddCampoTRel("_Profesor", "Profesor");
            def_Profesor._AnchoColumna = 7;
            def_Profesor._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Profesor._Editable = true;
            def_Profesor._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Profesor._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Profesor._ExpandirPunto = false;
            def_Profesor._FormatString = "";
            def_Profesor._PermiteDuplicados = true;
            def_Profesor._TipoColumna = gridColumnsTypes.Texto;
            def_Profesor._Titulo = "PROFESOR";
            def_Profesor._Updatable = true;
            def_Profesor._Validar_Asignar_Cargando = false;
            def_Profesor._Validar_Dato_BaseDatos = "";
            def_Profesor._Validar_Dato_Campos = "";
            def_Profesor._Validar_Dato_CampoTRel_Asignar = "";
            def_Profesor._Validar_Dato_Clave = "";
            def_Profesor._Validar_Dato_Tabla = "";
            def_Profesor._Visible = false;
            
            ewCampoTRel def_Clavelinea = this._AddCampoTRel("_Clavelinea", "Clavelinea");
            def_Clavelinea._AnchoColumna = 7;
            def_Clavelinea._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Clavelinea._Editable = true;
            def_Clavelinea._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Clavelinea._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Clavelinea._ExpandirPunto = false;
            def_Clavelinea._FormatString = "";
            def_Clavelinea._PermiteDuplicados = true;
            def_Clavelinea._TipoColumna = gridColumnsTypes.Entero;
            def_Clavelinea._Titulo = "CLAVELINEA";
            def_Clavelinea._Updatable = true;
            def_Clavelinea._Validar_Asignar_Cargando = false;
            def_Clavelinea._Validar_Dato_BaseDatos = "";
            def_Clavelinea._Validar_Dato_Campos = "";
            def_Clavelinea._Validar_Dato_CampoTRel_Asignar = "";
            def_Clavelinea._Validar_Dato_Clave = "";
            def_Clavelinea._Validar_Dato_Tabla = "";
            def_Clavelinea._Visible = false;
            
            ewCampoTRel def_Curso = this._AddCampoTRel("_Curso", "Curso");
            def_Curso._AnchoColumna = 7;
            def_Curso._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Curso._Editable = true;
            def_Curso._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Curso._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Curso._ExpandirPunto = false;
            def_Curso._FormatString = "";
            def_Curso._PermiteDuplicados = true;
            def_Curso._TipoColumna = gridColumnsTypes.Texto;
            def_Curso._Titulo = "Curso";
            def_Curso._Updatable = true;
            def_Curso._Validar_Asignar_Cargando = true;
            def_Curso._Validar_Dato_BaseDatos = "ACADEMIA";
            def_Curso._Validar_Dato_Campos = "NOMBRE";
            def_Curso._Validar_Dato_CampoTRel_Asignar = "_Definicion";
            def_Curso._Validar_Dato_Clave = "CODIGO";
            def_Curso._Validar_Dato_Tabla = "cursos";
            def_Curso._Visible = true;
            def_Curso._Browser = new sage.ew.botones.btBrowser();
            def_Curso._Browser._Campos = "Codigo,Nombre";
            def_Curso._Browser._Campo_Predet = "Nombre";
            def_Curso._Browser._Clave = "CODIGO";
            def_Curso._Browser._DataBase = "ACADEMIA";
            def_Curso._Browser._Tabla = "cursos";
            def_Curso._Browser._Titulo = "Buscar Curso";
            def_Curso._Browser._Titulos_Campos = "Código,Nombre";
            def_Curso._Mante = new sage.ew.botones.btMante();
            def_Curso._Mante._NombreManteNet = "CURSOS";
            
            ewCampoTRel def_Definicion = this._AddCampoTRel("_Definicion", "");
            def_Definicion._AnchoColumna = 15;
            def_Definicion._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Definicion._Editable = false;
            def_Definicion._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Definicion._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Definicion._ExpandirPunto = false;
            def_Definicion._FormatString = "";
            def_Definicion._PermiteDuplicados = true;
            def_Definicion._TipoColumna = gridColumnsTypes.Texto;
            def_Definicion._Titulo = "Definicion";
            def_Definicion._Updatable = false;
            def_Definicion._Validar_Asignar_Cargando = false;
            def_Definicion._Validar_Dato_BaseDatos = "";
            def_Definicion._Validar_Dato_Campos = "";
            def_Definicion._Validar_Dato_CampoTRel_Asignar = "";
            def_Definicion._Validar_Dato_Clave = "";
            def_Definicion._Validar_Dato_Tabla = "";
            def_Definicion._Visible = true;
            
            ewCampoTRel def_Fecha = this._AddCampoTRel("_Fecha", "Fecha");
            def_Fecha._AnchoColumna = 7;
            def_Fecha._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Fecha._Editable = true;
            def_Fecha._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Fecha._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Fecha._ExpandirPunto = false;
            def_Fecha._FormatString = "";
            def_Fecha._PermiteDuplicados = true;
            def_Fecha._TipoColumna = gridColumnsTypes.Fecha;
            def_Fecha._Titulo = "Fecha";
            def_Fecha._Updatable = true;
            def_Fecha._Validar_Asignar_Cargando = false;
            def_Fecha._Validar_Dato_BaseDatos = "";
            def_Fecha._Validar_Dato_Campos = "";
            def_Fecha._Validar_Dato_CampoTRel_Asignar = "";
            def_Fecha._Validar_Dato_Clave = "";
            def_Fecha._Validar_Dato_Tabla = "";
            def_Fecha._Visible = true;
            
            ewCampoTRel def_Notas = this._AddCampoTRel("_Notas", "Notas");
            def_Notas._AnchoColumna = 12;
            def_Notas._AutoModeSizeColumna = DataGridViewAutoSizeColumnMode.None;
            def_Notas._Editable = true;
            def_Notas._Error_Duplicados = "Ha introducido un valor que ya está asignado a otro registro. No se permiten valores duplicados en este campo.";
            def_Notas._Error_Validar_Dato = "Ha introducido un valor que no se ha encontrado en su mantenimiento origen.";
            def_Notas._ExpandirPunto = false;
            def_Notas._FormatString = "";
            def_Notas._PermiteDuplicados = true;
            def_Notas._TipoColumna = gridColumnsTypes.Texto;
            def_Notas._Titulo = "Notas";
            def_Notas._Updatable = true;
            def_Notas._Validar_Asignar_Cargando = false;
            def_Notas._Validar_Dato_BaseDatos = "";
            def_Notas._Validar_Dato_Campos = "";
            def_Notas._Validar_Dato_CampoTRel_Asignar = "";
            def_Notas._Validar_Dato_Clave = "";
            def_Notas._Validar_Dato_Tabla = "";
            def_Notas._Visible = true;
            

        }

		// Captura el error al validar un valor introducido.
        private void prof_curso__Error_Validar_Valor(string errorMessage)
        {
            if (_Error_Validar_prof_curso != null)
            {
                _Error_Validar_prof_curso(errorMessage);
                _Refresh();
            }
        }

        /// <summary>
        /// Establecer valores de claves
        /// </summary>
        public override void _Load()
        {
            
            
			                this._Claves._Profesor._Valor = this._ewMantePrincipal._Codigo;

            base._Load();
        }

        /// <summary>
        /// Campos clave para registros únicos y carga de registros
        /// </summary>
        public class Clave : IClaves
        {
                /// <summary>
                /// Profesor
                /// </summary>
                public ClaveTRel _Profesor { get; set; }
                
                /// <summary>
                /// Clavelinea
                /// </summary>
                public ClaveTRel _Clavelinea { get; set; }
                


                /// <summary>
                /// Inicializa una nueva instancia de la clase
                /// </summary>
                public Clave()
                {
                    // Definición de las propiedades de cada una de les claves

                    // Profesor
                    _Profesor = new ClaveTRel();
                    _Profesor._EsFiltro = true;
                
                    // Clavelinea
                    _Clavelinea = new ClaveTRel();
                    _Clavelinea._EsCampoLinea = true;
                

                }
        }

        /// <summary>
        /// Definir la estructura de las líneas
        /// </summary>
        public class Linia : ILinTRel
        {
        /// <summary>
        /// _Profesor
        /// </summary>
		
        public string _Profesor
        {
            get
            {
                 return _privateProfesor;
            }
            set
            {
                _privateProfesor = value;
            }
        }
        private string _privateProfesor = "";

        /// <summary>
        /// _Clavelinea
        /// </summary>
		
        public Int32 _Clavelinea
        {
            get
            {
                 return _privateClavelinea;
            }
            set
            {
                _privateClavelinea = value;
            }
        }
        private Int32 _privateClavelinea = 0;

        /// <summary>
        /// _Curso
        /// </summary>
		
        public string _Curso
        {
            get
            {
                 return _privateCurso;
            }
            set
            {
                if (_privateCurso.Trim() != value.Trim())
                {

                    if (loParent != null)
                    {
                        object loNewValor;
                        if (loParent.CamposTRel_Validar_Valor("_Curso", value, this, out loNewValor))
                        {
                            value = _privateCurso;
                        }
                        else if (loNewValor != null)
                        {
                            value = Convert.ToString(loNewValor);
                        }
                    }
                }

                if (_privateCurso.Trim() != value.Trim())
                {
                    _privateCurso = value;
                    loParent._Exportar_Null();
                }
;
            }
        }
        private string _privateCurso = "";

        /// <summary>
        /// _Definicion
        /// </summary>
		
        public string _Definicion
        {
            get
            {
                 return _privateDefinicion;
            }
            set
            {
                _privateDefinicion = value;
            }
        }
        private string _privateDefinicion = "";

        /// <summary>
        /// _Fecha
        /// </summary>
		
        public DateTime _Fecha
        {
            get
            {
                 return _privateFecha;
            }
            set
            {
                _privateFecha = value;
            }
        }
        private DateTime _privateFecha = DateTime.Now;

        /// <summary>
        /// _Notas
        /// </summary>
		
        public string _Notas
        {
            get
            {
                 return _privateNotas;
            }
            set
            {
                _privateNotas = value;
            }
        }
        private string _privateNotas = "";

		 

            private prof_curso loParent;
            /// <summary>
            /// Objeto padre a la instancia.
            /// </summary>
            public object _Parent
            {
                get { return loParent; }
                set { loParent = (prof_curso)value; }
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
