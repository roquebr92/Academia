using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sage.ew.formul.Forms;

namespace sage.addons.Academia.Visual.Forms
{
    public partial class frmalumnos : FormMante
    {
	    /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public frmalumnos()
        {
            InitializeComponent();
        }
		
        /// <summary>
        /// Bindear objetos específicos
        /// </summary>
        protected override void _Binding()
        {
            base._Binding();

            if (ewtextboxNif.DataBindings["Text"] != null)
                ewtextboxNif.DataBindings[0].ReadValue();
            else
                ewtextboxNif.DataBindings.Add("Text", _ewMante, "_Nif", true);

            if (ewtextboxDireccion.DataBindings["Text"] != null)
                ewtextboxDireccion.DataBindings[0].ReadValue();
            else
                ewtextboxDireccion.DataBindings.Add("Text", _ewMante, "_Direccion", true);

            if (ewtextboxTelefono.DataBindings["Text"] != null)
                ewtextboxTelefono.DataBindings[0].ReadValue();
            else
                ewtextboxTelefono.DataBindings.Add("Text", _ewMante, "_Telefono", true);

            if (ewdatetimeFechanacimiento.DataBindings["Value"] != null)
                ewdatetimeFechanacimiento.DataBindings[0].ReadValue();
            else
                ewdatetimeFechanacimiento.DataBindings.Add("Value", _ewMante, "_Fechanacimiento", true);

            if (ewtextboxObservaciones.DataBindings["Text"] != null)
                ewtextboxObservaciones.DataBindings[0].ReadValue();
            else
                ewtextboxObservaciones.DataBindings.Add("Text", _ewMante, "_Observaciones", true);


        }
		
        /// <summary>
        /// Bloquear / desbloquear controles específicos
        /// </summary>
        protected override void _BloquearControles()
        {
            base._BloquearControles();

            // Variable para recoger el valor de bloqueo
            bool bloquearControles = false;

            // Bloquear según el estado del mantenimiento
            switch (_ewMante._Estado)
            {
                case sage.ew.ewbase.ewMante._EstadosMantenimiento.EditandoRegistro:
                case sage.ew.ewbase.ewMante._EstadosMantenimiento.EntrandoNuevo:
                    bloquearControles = false;
                    break;

                case sage.ew.ewbase.ewMante._EstadosMantenimiento.EsperandoCodigo:
                case sage.ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro:
                    bloquearControles = true;
                    break;
                    
                default:
                    bloquearControles = false;
                    break;
            }

            ewtextboxNif.ReadOnly = bloquearControles;
            ewtextboxDireccion.ReadOnly = bloquearControles;
            ewtextboxTelefono.ReadOnly = bloquearControles;
            ewdatetimeFechanacimiento.Enabled = !bloquearControles;
            ewtextboxObservaciones.ReadOnly = bloquearControles;

        }
    }
}
