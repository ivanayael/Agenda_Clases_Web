using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EQ40VQ5;Initial Catalog=Alumnos; Integrated Security =true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnBorrar.Enabled = false;
                LlenarGridView();
                ddlClases();
            }

        }
        public void Limpiar()
        {
            hfIDClase.Value = "";
            btnBorrar.Enabled = false;
            lblSuccess.Text = "";
            lblError.Text = "";
            txtCantidad.Text = txtFecha.Text = txtHora.Text = "";
            ddlModalidad.SelectedIndex = -1;
            ddlAlumno.SelectedIndex = -1;

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(sqlcon.State == ConnectionState.Closed)
                sqlcon.Open ();
            SqlCommand sqlcmd = new SqlCommand("dbo.ClaseCrearOActualizar", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", (hfIDClase.Value == "" ? 0 : Convert.ToInt32(hfIDClase.Value)));
            sqlcmd.Parameters.AddWithValue ("@modalidad",ddlModalidad.SelectedItem.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@fecha",txtFecha.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@horas",txtHora.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@cantidad",txtCantidad.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@id_alumno",Convert.ToInt32(ddlAlumno.SelectedItem.Value));
            sqlcmd.ExecuteNonQuery();
            String IdClase = hfIDClase.Value;
            sqlcon.Close();
            Limpiar();
            if (IdClase == "")
                lblSuccess .Text = "Clase creada correctamente";
            else
                lblSuccess.Text = "Clase actualizada correctamente";
            LlenarGridView();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void LlenarGridView()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.ClaseViewAll", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            sqlcon.Close();
            gvClases.DataSource = DT;
            gvClases.DataBind();

        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            btnBorrar.Enabled = true;
            int ClaseID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.ClaseViewbyID", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@id", ClaseID);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            sqlcon.Close();
            hfIDClase.Value = ClaseID.ToString();
            ddlModalidad.SelectedItem.Text= DT.Rows[0]["modalidad"].ToString();
            txtFecha.Text = DT.Rows[0]["fecha"].ToString();
            txtHora.Text = DT.Rows[0]["horas"].ToString();
            txtCantidad.Text = DT.Rows[0]["cantidad"].ToString();
            ddlAlumno.SelectedValue = DT.Rows[0]["id_alumno"].ToString();
            btnAgregar.Text = "Actualizar";
            btnAgregar.Enabled = true ;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("dbo.ClaseDeletebyID", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id",Convert.ToInt32(hfIDClase.Value));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Limpiar();
            LlenarGridView();
            lblSuccess.Text = "clase borrada";
        }

        public void ddlClases()
        {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("SELECT id, nombre as alumno FROM alumno order by nombre", sqlcon);
                    {
                        sqlcmd.CommandType = CommandType.Text;
                        ddlAlumno.DataSource = sqlcmd.ExecuteReader();
                        ddlAlumno.DataTextField = "alumno";
                        ddlAlumno.DataValueField = "id";
                        ddlAlumno.DataBind();
                        sqlcon.Close();
                    }
            
            
        }


      
    }
}