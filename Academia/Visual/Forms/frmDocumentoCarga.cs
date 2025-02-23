using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sage.ew.formul.Forms;
using sage.ew.formul;
using sage.ew.db;
using sage.ew.global;
using sage.ew.docventatpv;
using sage.ew.cliente;
using Sage.ES.S50.NuevoEjercicio.Clases;
using sage.ew.functions;
using sage.ew.listados.Clases;


namespace sage.addons.Academia.Visual.Forms
{
    public partial class frmDocumentoCarga : FormBaseDocumento
    {
        private string _empresa = EW_GLOBAL._GetVariable("wc_empresa").ToString();
        private string _ejercicio = EW_GLOBAL._GetVariable("wc_any").ToString();

        /// <summary>
        /// Clase de negocio del documento
        /// </summary>
        public dynamic Documento
        {
            get
            {
                if (_oDocumento == null)
                {
                    Documento = new Negocio.Documentos.DocumentoCarga();
                }

                return _oDocumento;
            }
            set
            {
                _Constructor_Base(value);

                _oDocumento._FormMante = this;
                btBrowDocumentoCarga1._Documento = value;
                btNavegacion._Navegacion = Documento.Navegacion;
                _oDocumento._Detalle._Grid = mantegridLinies;
            }
        }
		
        /// <summary>
        /// Objeto cabecera del documento
        /// </summary>
        public ew.ewbase.ewMante _ewMante;

        /// <summary>
        /// Inicializa una nueva intancia de la clase
        /// </summary>
        public frmDocumentoCarga()
        {
            InitializeComponent();

			this._Pantalla = "frmDocumentoCarga";


            this.ewtextboxNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ewtextboxNumero_KeyPress);
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
        }        

        /// <summary>
        /// Constructor base
        /// </summary>
        /// <param name="toDocumento"></param>
        protected override void _Constructor_Base(dynamic toDocumento)
        {
            _ewMante = toDocumento;

            base._Constructor_Base((Negocio.Documentos.DocumentoCarga)toDocumento);

            // Enlazar controles
            _Binding();
        }

        /// <summary>
        /// Enlazar controles de la cabecera
        /// </summary>
        protected override void _Binding()
        {
            if (this.DesignMode)
                return;

            base._Binding();

            if (ewtextboxNumero.DataBindings["Text"] != null)
                ewtextboxNumero.DataBindings[0].ReadValue();
            else
                ewtextboxNumero.DataBindings.Add("Text", Documento, "_Numero", true);

            if (txtFecha.DataBindings["Value"] != null)
                txtFecha.DataBindings[0].ReadValue();
            else
                txtFecha.DataBindings.Add("Value", Documento, "_Fecha", true);

            if (txtCliente.DataBindings["_Codigo"] != null)
                txtCliente.DataBindings[0].ReadValue();
            else
                txtCliente.DataBindings.Add("_Codigo", Documento, "_Cliente", true);

            if (txtProfesores.DataBindings["_Codigo"] != null)
                txtProfesores.DataBindings[0].ReadValue();
            else
                txtProfesores.DataBindings.Add("_Codigo", Documento, "_Profesores", true);

            if (txtCursos.DataBindings["_Codigo"] != null)
                txtCursos.DataBindings[0].ReadValue();
            else
                txtCursos.DataBindings.Add("_Codigo", Documento, "_Cursos", true);

            if (ewnumericupdownHoras.DataBindings["Value"] != null)
                ewnumericupdownHoras.DataBindings[0].ReadValue();
            else
                ewnumericupdownHoras.DataBindings.Add("Value", Documento, "_Horas", true);

            if (ewtextboxNumeroalbaran.DataBindings["Text"] != null)
                ewtextboxNumeroalbaran.DataBindings[0].ReadValue();
            else
                ewtextboxNumeroalbaran.DataBindings.Add("Text", Documento, "_Numeroalbaran", true);

            if (ewtextboxSerie.DataBindings["Text"] != null)
                ewtextboxSerie.DataBindings[0].ReadValue();
            else
                ewtextboxSerie.DataBindings.Add("Text", Documento, "_Serie", true);

            if (ewtextboxEjercicioalbaran.DataBindings["Text"] != null)
                ewtextboxEjercicioalbaran.DataBindings[0].ReadValue();
            else
                ewtextboxEjercicioalbaran.DataBindings.Add("Text", Documento, "_Ejercicioalbaran", true);



        }
		
        /// <summary>
        /// Carga el documento
        /// </summary>
        /// <param name="taParams"></param>
        /// <returns></returns>
        public override bool _Init(object[] taParams)
        {
            if (Documento == null)
            {
                return false;
            }

            // Asignar valores clave
            if (taParams.Count() > 0)
            {
                string numero = taParams[0].ToString();

                if (!string.IsNullOrWhiteSpace(numero))
                {
                    Documento._Numero = numero;
                }
            }

            return true;
        }

        /// <summary>
        /// Muestra el formulario
        /// </summary>
        public override void _Show()
        {
            if (Documento == null)
            {
                return;
            }

            base._Show();
        }

        /// <summary>
        /// Método base para crear un nuevo documento
        /// </summary>
        protected override void _Nuevo_Documento()
        {
            if (Save())
            {
                base._Nuevo_Documento();
            }
        }

        /// <summary>
        /// Bloquear controles
        /// </summary>
        protected override void _Bloquear_Controles()
        {
            bool bloquearControles = (_EstadoDocumento != EstadosDocumento.HayDocumento);

            base._Bloquear_Controles();

            mantegridLinies._ReadOnly = bloquearControles;
            ewtextboxNumero.ReadOnly = !bloquearControles;
            txtFecha.Enabled = !bloquearControles;
            txtCliente._ReadOnly = bloquearControles;
            txtProfesores._ReadOnly = bloquearControles;
            txtCursos._ReadOnly = bloquearControles;
            ewnumericupdownHoras.ReadOnly = bloquearControles;
            ewtextboxNumeroalbaran.ReadOnly = bloquearControles;
            ewtextboxSerie.ReadOnly = bloquearControles;
            ewtextboxEjercicioalbaran.ReadOnly = bloquearControles;

        }

        /// <summary>
        /// Método base para eliminar un documento
        /// </summary>
        protected override void _Borrar_Documento(bool llPreguntar = true)
        {
            base._Borrar_Documento(llPreguntar);

            switch (_EstadoDocumento)
            {
                case EstadosDocumento.DocumentoBloqueado:
                    break;
                case EstadosDocumento.EntrandoNuevo:
                    break;
                case EstadosDocumento.HayDocumento:
                    break;
                case EstadosDocumento.NoHayDocumento:
                    ewtextboxNumero.Focus();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Carga del documento
        /// </summary>
        public void _Cargar_Documento()
        {
            // Comprobar si el documento se puede abandonar
            if ((_EstadoDocumento != EstadosDocumento.NoHayDocumento) && !_oDocumento._Abandonar_Documento())
            {
                return;
            }

            _EstadoDocumento = EstadosDocumento.HayDocumento;

            _Binding();

            _Bloquear_Controles();

            _Refrescar_Observaciones();
        }

        /// <summary>
        /// Volver a mostrar los datos del documento
        /// </summary>
        public void _Refresh()
        {
            _Binding();
        }

        /// <summary>
        /// Método virtual para establecer un mensaje de error en cualquier control.
        /// </summary>
        /// <param name="tcBinding"></param>
        /// <param name="tcMensaje"></param>
        public void _SetError_OnControl(string tcBinding, string tcMensaje)
        {

        }

        // Guardo el documento actual
        private bool Save()
        {
            bool llOk = true;

            if (Documento != null)
            {
                llOk = this.Documento._Save();
            }

            return llOk;
        }

        // Prapara para un nuevo documento
        private void New()
        {
            if (Documento != null)
            {
                this.Documento._New();
            }

            ewtextboxNumero.Focus();
        }

        // Captura del botón nuevo
        private void btNuevo_Click(object sender, EventArgs e)
        {
            New();
        }

        // Captura Enter para disparar la carga del documento
        private void ewtextboxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(ewtextboxNumero.Text))
                {
                    Documento._Suma_Numero();
                }
                else
                {
                    Documento._Numero = ewtextboxNumero.Text;                    
                }

                Documento._Load();
            }
        }

        // Muestra el formulario
        private void frmServeis_Shown(object sender, EventArgs e)
        {
            // Forzamos el foco al número
            ewtextboxNumero.Focus();
        }

		// Click del botón opciones
        private void btOpciones_Click(object sender, EventArgs e)
        {

        }

        private void btn_albaran_Click(object sender, EventArgs e)
        {
            //Leemos todos los datos de este documento y creamos albaran de venta para el cliente
            string empresa = this._cEmpresa;
            string tarifaPredet = EW_GLOBAL._GetVariable("wc_tarifapret").ToString();
            string seriPredet = EW_GLOBAL._GetVariable("wc_letra").ToString();
             //fopa = EW_GLOBAL._GetVariable("wc_fopa").ToString();

            if (!string.IsNullOrEmpty(ewtextboxNumeroalbaran.Text))
            {
                //mostramos
                Listados oListado = new Listados();
                oListado._Navegar(Listados.Pantalla.AlbaVen, new List<string> { { empresa }, { ewtextboxNumeroalbaran.Text }, { ewtextboxSerie.Text } });

            }
            else
            {
                //creamos  el albaran 
                string fopa = string.Empty;
                Cliente ocliente = new Cliente(txtCliente._Codigo);
                fopa = ocliente._FormaPago;

                if (string.IsNullOrEmpty(fopa))
                {
                    fopa = EW_GLOBAL._GetVariable("wc_fopa").ToString();
                }
                string cliente = txtCliente._Codigo;

                DataTable dt_detalle = new DataTable();
                string sql = $@"SELECT horas FROM {DB.SQLDatabase("Academia", "c_doccarga")}
               WHERE numero = {DB.SQLString(ewtextboxNumero.Text)}
               and empresa = {DB.SQLString(_empresa)}
               and ejercicio = {DB.SQLString(_ejercicio)}";
                bool ok = DB.SQLExec(sql, ref dt_detalle);
                if (ok && dt_detalle.Rows.Count > 0)
                {
                    //Creamos el albaran 
                    ewDocVentaTPV oCabecera = new ewDocVentaTPV();
                    oCabecera._New(_empresa);
                    oCabecera._Cabecera._Cliente = cliente;
                    //oCabecera._Cabecera._Vendedor = Vendedor;
                    oCabecera._Cabecera._Tarifa = tarifaPredet;
                    oCabecera._Cabecera._FormaPago = fopa;

                    //recorremos el detalle 
                    for (int i = 0; i < dt_detalle.Rows.Count; i++)
                    {
                        ewDocVentaLinTPV oLinea = oCabecera._AddLinea();
                        oLinea._Unidades = Convert.ToDecimal(dt_detalle.Rows[i]["horas"]);
                        oLinea._Save();
                    }
                    ok = oCabecera._Save();

                    if (ok)
                    {
                        FUNCTIONS._MessageBox("Albaran creado correctamente");
                        ewtextboxNumeroalbaran.Text = oCabecera._Numero;
                        ewtextboxSerie.Text = oCabecera._Letra;
                        ewtextboxEjercicioalbaran.Text = oCabecera._Cabecera._Ejercicio;
                        //this.Documento._Albaran = oCabecera._Numero;
                        this.Documento._Serie = oCabecera._Letra;
                        this.Documento._Ejercicioalbaran = oCabecera._Cabecera._Ejercicio;





                    }

                }

            }

         
        }
    }
}
