using System;
using CRUD.ENTIDADES;
using CRUD.BUSINESS;

namespace CRUD.WebAplication
{
    public partial class CrudForm : System.Web.UI.Page
    {
        private BandaBusiness objBandaBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            objBandaBusiness = new BandaBusiness();
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String mensaje = "";
            BandaClass objBanda = objBandaBusiness.readBandaXiD(Convert.ToInt32(txtIdBanda.Text), out mensaje);
            if (objBanda != null)
            {
                txtNombre.Text = objBanda.StrNombre;
                txtTipo.Text = objBanda.StrTipo;
            }
            lblMensaje.Text = mensaje;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = objBandaBusiness.deleteBanda(Convert.ToInt32(txtIdBanda.Text));
                limpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
            
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtTipo.Text))
            {
                BandaClass objBanda = new BandaClass();
                objBanda.StrNombre = txtNombre.Text;
                objBanda.StrTipo = txtTipo.Text;
                lblMensaje.Text = objBandaBusiness.insertBandasp(objBanda);
                limpiarCampos();
            }
            else {
                lblMensaje.Text = "Digite Nombre y Tipo.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BandaClass objBanda = new BandaClass();
            objBanda.StrNombre = txtNombre.Text;
            objBanda.StrTipo = txtTipo.Text;
            objBanda.Ibanda = Convert.ToInt32(txtIdBanda.Text);
            lblMensaje.Text = objBandaBusiness.updateBanda(objBanda);
            limpiarCampos();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        public void limpiarCampos() {
            txtIdBanda.Text = "";
            txtNombre.Text = "";
            txtTipo.Text = "";
            GrVBandas.DataBind();
        }
    }
}