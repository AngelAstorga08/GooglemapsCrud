using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace CrudUbicacionesAEAM
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicacionesBLL oUbicacionesBLL;
        ubicacionesDAL oUbicacionesDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarUbicaciones();
                txtLat.Text = "27.368838973721562";
                txtLong.Text = "-109.93231695168663";
            }
        }

        public void ListarUbicaciones() 
        {
            oUbicacionesDAL = new ubicacionesDAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }

        public ubicacionesBLL datosUbicacion() 
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicacionesBLL();
            if (gvUbicaciones.SelectedRow != null)
            {
                oUbicacionesBLL.ID = int.Parse(gvUbicaciones.SelectedRow.Cells[1].Text);
            }
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();

        }
        protected void Limpiar_click(object sender, EventArgs e)
        {
            txtID.Value = null;
            txtUbicacion.Text = "";
            txtLat.Text = "0";
            txtLong.Text = "0";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        protected void SeleccionarUbicacion(object sender, EventArgs e)
        {
            var tabla = new DataTable();
            oUbicacionesDAL = new ubicacionesDAL();

            tabla = oUbicacionesDAL.Seleccionar(datosUbicacion());

            txtID.Value = tabla.Rows[0].ItemArray[0].ToString();
            txtUbicacion.Text = tabla.Rows[0].ItemArray[1].ToString();
            txtLat.Text = tabla.Rows[0].ItemArray[2].ToString();
            txtLong.Text = tabla.Rows[0].ItemArray[3].ToString();

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }
    }
}