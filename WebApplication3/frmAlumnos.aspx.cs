using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class frmClases : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-EQ40VQ5;Initial Catalog=Alumnos; Integrated Security =true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnBorrar.Enabled = false;
                LlenarGridView();
            }

        }
        public void Limpiar()
        {
            hfIDAlumno.Value = "";
            txtEmail.Text = txtNombre.Text = txtTelefono.Text = "";
            btnBorrar.Enabled = false;
            lblSuccess.Text = "";
            lblError.Text = "";

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(sqlcon.State == ConnectionState.Closed)
                sqlcon.Open ();
            SqlCommand sqlcmd = new SqlCommand("dbo.AlumnoCrearOActualizar", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue ("@id",(hfIDAlumno.Value==""?0:Convert.ToInt32(hfIDAlumno.Value)));
            sqlcmd.Parameters.AddWithValue ("@nombre",txtNombre.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@telefono",txtTelefono.Text.Trim());
            sqlcmd.Parameters.AddWithValue ("@email",txtEmail.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            String IdAlumno = hfIDAlumno.Value;
            sqlcon.Close();
            Limpiar();
            if (IdAlumno == "")
                lblSuccess .Text = "Alumno creado correctamente";
            else
                lblSuccess.Text = "Alumno actualizado correctamente";
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.AlumnoViewAll", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            sqlcon.Close();
            gvAlumnos.DataSource = DT;
            gvAlumnos.DataBind();

        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            btnBorrar.Enabled = true;
            int AlumnoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.AlumnoViewbyID", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@id", AlumnoID);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            sqlcon.Close();
            hfIDAlumno.Value = AlumnoID.ToString();
            txtNombre.Text = DT.Rows[0]["nombre"].ToString();
            txtTelefono.Text = DT.Rows[0]["telefono"].ToString();
            txtEmail.Text = DT.Rows[0]["email"].ToString();
            btnAgregar.Text = "Actualizar";
            btnAgregar.Enabled = true ;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("dbo.AlumnoDeletebyID", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id",Convert.ToInt32(hfIDAlumno.Value));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Limpiar();
            LlenarGridView();
            lblSuccess.Text = "Alumno borrado";
        }

    }
}
