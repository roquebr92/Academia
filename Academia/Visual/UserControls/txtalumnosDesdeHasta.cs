using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sage.ew.global;
using sage.ew.txtbox.UserControls;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Filtro desde - hasta para agencias
    /// </summary>
    public partial class txtalumnosDesdeHasta : txtFiltroBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public txtalumnosDesdeHasta()
        {
            this._Init();
        }

        /// <summary>
        /// Constructor con parámetro _Editando
        /// </summary>
        /// <param name="tlEditando"></param>
        public txtalumnosDesdeHasta(bool tlEditando = false)
            : base(tlEditando)
        {
            this._Init();
        }

        /// <summary>
        /// Método común para el constructor de la clase
        /// </summary>
        public override void _Init()
        {
            base._Init();

            _VariableFiltro = "alumnos";

            this._oFiltroDesde = new txtalumnos();
            this._oFiltroHasta = new txtalumnos();

            _Parametrizacion_Demorada();
        }
    }
}
