using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yCarDealerSFM.Utilitarios;

namespace Sugerencias.Consultas
{
    public partial class cSugerencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static List<Entidades.Sugerencias> Buscar(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Entidades.Sugerencias, bool>> filtro = p => true;
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
            List<Entidades.Sugerencias> list = new List<Entidades.Sugerencias>();

            int id = Utils.ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://Id
                    filtro = p => p.SugerenciaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 2://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = FiltroDropDownList.SelectedIndex;
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);

            DatosGridView.DataSource = Buscar(index, CriterioTextBox.Text, desde, hasta);
            DatosGridView.DataBind();
        }

        public static List<Entidades.Sugerencias> Lista(Expression<Func<Entidades.Sugerencias, bool>> Filtro)
        {
            Filtro = r => true;
            RepositorioBase<Entidades.Sugerencias> Repositorio = new RepositorioBase<Entidades.Sugerencias>();
            List<Entidades.Sugerencias> sugerencias = new List<Entidades.Sugerencias>();
            sugerencias = Repositorio.GetList(Filtro);
            return sugerencias;
        }
    }
}