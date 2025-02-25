#region Referencias WindowsForms

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

#endregion Referencias WindowsForms

#region Referencias Sage50

//Acceso a Base de Datos
//Referencia en : C:\Sage50_3\Sage50Term\Librerias\sage.ew.db.dll
using sage.ew.db;

//Acceso a variables globales
//Referencia en : C:\Sage50_3\Sage50Term\Librerias\sage.50.exe
using sage.ew.global;

//Objetos visuales (filtros y opciones)=
//Referencia en : C:\Sage50_3\Sage50Term\Librerias\sage.50.exe
using sage.ew.objetos;

//Clases utiles de listados
//Referencia en : C:\Sage50_3\Sage50Term\Librerias\sage.50.exe
using sage.ew.listados;
using sage.ew.listados.Clases;
using sage.ew.listados.Listados;
using sage.ew.functions;

#endregion Referencias Sage50

/// <summary>
/// Namespace del Add-on para la clase de negocio listadoAlumnosPorCurso
/// </summary>
namespace sage.addons.Academia.Negocio.Listados
{
    /// <summary>
    /// Clase de negocio listadoAlumnosPorCurso
    /// </summary>
    public class listadoAlumnosPorCurso : sage.ew.listados.Clases.Listados
    {
        private bool _imprimirVertical = false;
        /// <summary>
        /// Definicio del nombre de report a utilizar en la impresión del listado
        /// </summary>
        public override String _ReportFile
        {
            get
            { 
                    if(_imprimirVertical)
                {
                    return "listadoalumnosporcurso1.report";
                }
                    else
                {
                    return "listadoalumnosporcursoHorizontal1.report";
                }
            
               
            }
        }

        /// <summary>
        /// Método de obtención de los datos específico para el listado
        /// </summary>
        /// <returns>Datatable con los datos</returns>
        public override DataTable _DataTable()
        {
            //Las opciones 
            //lImprimirvertical y nbCursoProfesorcomb
            _imprimirVertical = _Opcion_Logico("lImprimirvertical");
            int lnOpcion = _Opcion_Entero("nCursoProfesorcomb");
            string orderBy = "Order by PROFESORES";

            if(lnOpcion == 0) 
            {
                orderBy = "Order by CURSOS";
            }

            DataTable ldtResult = new DataTable();

            //leemos los filtos 
            string lcFiltros = "";

            //fecha, cliente 

            lcFiltros = _Filtro_Fecha(_Filtros, _Tipo_Filtro_Fecha.Fecha, "cab", "FECHA");
            lcFiltros += _Filtro_String(_Filtros, _Tipo_Filtro_String.Cliente, "cab", "CLIENTE");

            string sql = $@"select cab.FECHA 'Fecha', cab.CURSOS 'Cod. Curso', nom.NOMBRE 'Nombre Curso', cab.CLIENTE 'Cliente', cli.NOMBRE 'Nombre Cliente',cab.PROFESORES 'Cod. Profesor', pro.NOMBRE 'Nombre Profesor'
            from {DB.SQLDatabase("academia", "c_doccarga")} cab 
            left join {DB.SQLDatabase("clientes")} cli on cab.CLIENTE=cli.CODIGO
            left join {DB.SQLDatabase("academia", "cursos")} nom on cab.CURSOS=nom.CODIGO
            left join {DB.SQLDatabase("academia", "profesores")} pro on cab.PROFESORES=pro.CODIGO 
            where 
            1=1{lcFiltros}
            {orderBy}
            ";

            bool ok = DB.SQLExec(sql,ref ldtResult);

            if (!ok)
            {
                FUNCTIONS._MessageBox("Sql mal formateada");
                ldtResult = new DataTable();

            }
            return ldtResult;
        }
    }
}
