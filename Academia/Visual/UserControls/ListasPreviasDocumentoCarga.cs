using sage.ew.docsven;
using sage.ew.formul.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sage.addons.Academia.Visual.UserControls
{
    /// <summary>
    /// Lista previa
    /// </summary>
    public class ListasPreviasDocumentoCarga : ListasPreviasDocsDocumentosOtros
    {
        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public ListasPreviasDocumentoCarga(string tcClass, Type toTipoObjeto, string tcPantalla)
            : base(tcClass, toTipoObjeto, tcPantalla)
        {
            //Tipo de documento
            this._TipoDocumento = eTipoDocumento.DocumentoBase;
        }

        /// <summary>
        /// Rellena las propiedades necesarias para el browser
        /// </summary>
        public override void PopulateBrowser()
        {
            //Tipo de documento
            this._TipoDocumento = eTipoDocumento.DocumentoBase;

            // Botón browser
            btBrowDocuments = new sage.addons.Academia.Visual.UserControls.btBrowDocumentoCarga();

            //Parte comun
            base.PopulateBrowser(btBrowDocuments);
        }
    }

}
