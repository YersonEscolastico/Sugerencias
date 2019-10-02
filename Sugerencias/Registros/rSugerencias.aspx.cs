using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yCarDealerSFM.Utilitarios;

namespace Sugerencias.Registros
{
    public partial class rSugerencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {
                if (!Page.IsPostBack)
                {
                    int id = Utils.ToInt(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
                        var registro = repositorio.Buscar(id);

                        if (registro == null)
                        {
                            Utils.ShowToastr(this.Page, "Registro no existe", "Error", "error");
                        }
                        else
                        {
                            LlenaCampos(registro);
                        }
                    }
                }
            }
        }



        protected void Limpiar()
        {
            SugerenciaIdTextBox.Text = "0";
            FechaTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected Entidades.Sugerencias LlenaClase(Entidades.Sugerencias sugerencias)
        {
            sugerencias.SugerenciaId = Utils.ToInt(SugerenciaIdTextBox.Text);
            sugerencias.Descripcion = DescripcionTextBox.Text;
            sugerencias.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return sugerencias;
        }

        private void LlenaCampos(Entidades.Sugerencias sugerencias)
        {
            SugerenciaIdTextBox.Text = sugerencias.SugerenciaId.ToString();
            DescripcionTextBox.Text = sugerencias.Descripcion;
            FechaTextBox.Text = sugerencias.Fecha.ToString("yyyy-MM-dd");
        }

        protected bool ValidarNombres(Entidades.Sugerencias sugerencias)
        {
            bool validar = false;
            Expression<Func<Entidades.Sugerencias, bool>> filtro = p => true;
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {
                if (sugerencias.Descripcion == item.Descripcion)
                {
                    Utils.ShowToastr(this.Page, "Ya ha sido creado", "Error", "error");
                    return validar = true;
                }
            }

            return validar;
        }



        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
            Entidades.Sugerencias sugerencias = repositorio.Buscar(Utils.ToInt(SugerenciaIdTextBox.Text));
            return (sugerencias != null);
        }



   
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
            Entidades.Sugerencias sugerencias = new Entidades.Sugerencias();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }
            sugerencias = LlenaClase(sugerencias);
            if (ValidarNombres(sugerencias))
            {
                return;
            }
            else
            {

                if (sugerencias.SugerenciaId == 0)
                {

                    if (Utils.ToInt(SugerenciaIdTextBox.Text) > 0)
                    {
                        Utils.ShowToastr(this.Page, "SugerenciaId debe estar en 0", "Revisar", "error");
                        return
                            ;
                    }
                    else
                    {
                        paso = repositorio.Guardar(sugerencias);
                        Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                        Limpiar();
                    }
                }
                else
                {
                    if (ExisteEnLaBaseDeDatos())
                    {
                        paso = repositorio.Modificar(sugerencias);
                        Utils.ShowToastr(this.Page, "Modificado con exito!!", "Modificado", "success");
                        Limpiar();
                    }
                    else
                        Utils.ShowToastr(this.Page, "Este sugerencia no existe", "Error", "error");
                }
            }
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
            var usuario = repositorio.Buscar(Utils.ToInt(SugerenciaIdTextBox.Text));

            if (usuario != null)
            {
                Limpiar();
                LlenaCampos(usuario);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this.Page, "No existe", "Error", "error");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utils.ToInt(SugerenciaIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(SugerenciaIdTextBox.Text);
                RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();
                if (repositorio.Eliminar(id))
                {

                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");
            }
        }
    }
}