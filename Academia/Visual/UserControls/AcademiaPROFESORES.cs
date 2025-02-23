using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

using sage.ew.interficies;
using sage.ew.ewbase;
using sage.ew.db;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Clase para añadir un control de usuario a una página de un mantenimiento
    /// </summary>
    public partial class AcademiaPROFESORES : UserControl, ITabMante
    {
        /// <summary>
        /// Objeto de Negocio responsable del tratamiento de las tarjetas
        /// </summary>
        public _ExtensionMante extensionMante;

        /// <summary>
        /// Inicializa un nueva instancia de la clase
        /// </summary>
        public AcademiaPROFESORES()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa un nueva instancia de la clase
        /// </summary>
        public AcademiaPROFESORES(_ExtensionMante _extensionMante)
        {
            InitializeComponent();

            extensionMante = _extensionMante;
        }

        /// <summary>
        /// Método para el enlace de controles y datos
        /// </summary>
        public void _Binding()
        {
            
        }

        /// <summary>
        /// Método para bloquear los controles del UserControl
        /// </summary>
        /// <param name="tlReadOnly"></param>
        public void _BloquearControles(bool tlReadOnly)
        {
         this.mantegridprof_curso._ReadOnly = tlReadOnly;
   
        }

        /// <summary>
        /// Objeto del mantenimiento principal
        /// </summary>
        public ew.ewbase.ewMante _ewMante { get; set; }
        /// <summary>
        /// Objeto de Negocio asociado al usercontrol
        /// </summary>
        public ew.objetos.UserControls.Mantegrid mantegridprof_curso;

        private void InitializeComponent()
        {


this.mantegridprof_curso = new sage.ew.objetos.UserControls.Mantegrid();
                        this.SuspendLayout();
            // //
            // mantegridprof_curso
            //
            this.mantegridprof_curso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.mantegridprof_curso.Location = new System.Drawing.Point(0, 0);
            this.mantegridprof_curso.Name = "mantegridprof_curso";
            this.mantegridprof_curso.Size = new System.Drawing.Size(511, 294);
            this.mantegridprof_curso.TabIndex = 0;

            // AcademiaPROFESORES
            // 
            this.Name = "AcademiaPROFESORES";
            this.Size = new System.Drawing.Size(514, 297);
this.Controls.Add(this.mantegridprof_curso);
                        this.ResumeLayout(false);


            





			
        }
		

    }
}
