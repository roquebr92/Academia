using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using sage.ew.ewbase;
using sage.ew.formul.Forms;
using sage.ew.interficies;
using sage.ew.db;
using sage.ew.ewbase.Attributes;

namespace sage.addons.Academia.Negocio.Mantes
{
    /// <summary>
    /// Extensión para el mantenimiento de clientes
    /// </summary>
    public class ManteExtProfesoresAcademia : _ExtensionMante
    {
        // Objeto de negocio del mantenimiento principal
        private ewMante mantePrincipal = null;

        // Formulario del mantenimiento
        private FormMante formMante = null;
		
        // Contiene si el registro existe en la tabla
        private bool rowexist = false;

        /// <summary>
        /// Referencia al UserControl asociado a esta clase
        /// </summary>
        public Visual.UserControls.AcademiaPROFESORES usercontrolTabManteBase = null;


        #region ManteTRels

        /// <summary>
        /// Instancia del ManteTRel de prof_curso
        /// </summary>
        public Negocio.Clases.prof_curso ManteTRelprof_curso = null;



        #endregion ManteTRels



        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public ManteExtProfesoresAcademia(sage.ew.interficies.IMante _mantePrincipal)
            : this()
        {
            this._Mante = _mantePrincipal;

            // Asociar mantenimientos de tablas relacionadas
            Negocio.Clases.prof_curso mtrelprof_curso = new Negocio.Clases.prof_curso();
            this.ManteTRelprof_curso = mtrelprof_curso;
            this._Mante._AddManteTRel(mtrelprof_curso);

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public ManteExtProfesoresAcademia()
        {
            this._Tabla = "";
            this._DataBase = "";
            this._Clave = "";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase y asigna objetos
        /// </summary>
        public ManteExtProfesoresAcademia(FormMante toForm)
            : this()
        {
            #region Código generado por el asistente de componentes. No borrar.

            formMante = toForm;
            mantePrincipal = toForm._ewMante;

            #endregion Código generado por el asistente de componentes. No borrar.
        }

        /// <summary>
        /// Se dispara cuando se cargan los datos en el mantenimiento principal
        /// </summary>
        /// <returns></returns>
        public override bool _Load()
        {
            bool llOk = base._Load();

            if (llOk && _eBeforeAfter == TipoExecute.After)
            {

                string whereclause = GetWhereClause();
                string sql = "";

                if (!string.IsNullOrWhiteSpace(sql))
                {
                    DataTable prof_cursoresult = new DataTable();
                    llOk = DB.SQLExec(sql, ref prof_cursoresult);

                    if (llOk && prof_cursoresult.Rows.Count > 0)
                    {


                        rowexist = true;
                    }
                    else
                    {
                        rowexist = false;
                    }
                }

                if (usercontrolTabManteBase != null)
                {
                    usercontrolTabManteBase._Binding();
                }
            }

            return llOk;
        }

        /// <summary>
        /// Se dispara cuando se va crea un nuevo registro
        /// </summary>
        /// <param name="tcCodigo"></param>
        /// <returns></returns>
        public override bool _New(string tcCodigo = "")
        {
            bool llOk = base._New(tcCodigo);

            if (llOk && _eBeforeAfter == TipoExecute.After)
            {

                if (usercontrolTabManteBase != null)
                {
                    usercontrolTabManteBase._Binding();
                    usercontrolTabManteBase._BloquearControles(false);
                }
            }

            return llOk;        
        }

        /// <summary>
        /// Guardar el registro actual
        /// </summary>
        /// <returns></returns>
        public override bool _Save()
        {
            bool llOk = base._Save();

            if (llOk && _eBeforeAfter == TipoExecute.After)
            {
                string sql = "";
				string whereclause = GetWhereClause();

                if (rowexist)
                {
                    sql =  "";
                }
                else
                {
                    sql =  "";
                }

                if (!string.IsNullOrWhiteSpace(sql))
                {
                    llOk = DB.SQLExec(sql);
                }
            }

            return llOk;
        }

        /// <summary>
        /// Eliminar el registro actual
        /// </summary>
        /// <returns></returns>
        public override bool _Delete()
        {
            bool llOk = base._Delete();

            if (llOk && _eBeforeAfter == TipoExecute.After)
            {
                string sql = "";
				string whereclause = GetWhereClause();

                sql = "";

                if (!string.IsNullOrWhiteSpace(sql))
                {
                    llOk = DB.SQLExec(sql);
                }
            }

            return llOk;
        }

        /// <summary>
        /// Bloquear controles de las extensiones de los mantes
        /// </summary>
        /// <param name="tlReadOnly"></param>
        public override void _Bloquear_Controles(bool tlReadOnly)
        {
            if (usercontrolTabManteBase != null)
            {
                usercontrolTabManteBase._BloquearControles(tlReadOnly);
            }
        }		
    }

    /// <summary>
    /// Clase para la extensión de los formularios
    /// </summary>
    public class FormManteExtProfesoresAcademia : _ExtensionFormMante
    {
        //private FormMante _oFormMante = null;
        private ManteExtProfesoresAcademia extensionMante = null;

        /// <summary>
        /// Iniciarliza una nueva instancia de la clase
        /// </summary>
        /// <param name="_formMante"></param>
        /// <param name="toAddon"></param>
        public FormManteExtProfesoresAcademia(FormMante _formMante, IModulo toAddon)
            : base(_formMante, toAddon)
        {
            #region Código generado por el asistente de componentes. No borrar.

            extensionMante = (ManteExtProfesoresAcademia)_ExtensionMante;

            if (extensionMante == null)
                return;

            Visual.UserControls.AcademiaPROFESORES extensionFormMante = new Visual.UserControls.AcademiaPROFESORES(extensionMante);
			extensionMante.usercontrolTabManteBase = extensionFormMante;
                        extensionMante.ManteTRelprof_curso._Grid = extensionMante.usercontrolTabManteBase.Controls["mantegridprof_curso"];
extensionMante._Load();

            _AgregarTabAddon(extensionFormMante);

            #endregion Código generado por el asistente de componentes. No borrar.
        }
    }
}
