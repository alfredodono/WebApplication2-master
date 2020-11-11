using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AlertsHRI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {

                lblId.Text = "welcome " + Session["User"];
            }
            else
            {
                Response.Redirect("default.aspx");
            }
            string usuario = "" + Session["User"];
            if (usuario == "scp")
            {
                BtnUsers.Visible = true;
            }
            else
            {
                BtnUsers.Visible = false;
            }
            BindGrid();
        }
        String q = DateTime.Today.ToString();
        public String query = "select A.id_answer as 'ID',R.Name_HRI as 'NameHRI', (case id_Machine when 0 then A.Machine_Name else M.Nombre end) as 'Machine_Name',A.equip_esp as 'EquipoEspecial',I.Question as 'question', A.Date as 'Date', Q.Status as 'status',foto as 'foto' from Users U inner join UHI H on U.id_user=H.id_user inner join Answer A on A.id_HRI=H.id_HRI inner join QStatus Q on A.Status = Q.idStatus inner join ima I on I.id_foto = A.id_foto inner join HRI R on H.id_HRI=R.id_HRI left join[LUIS AGUILAR].[ADESCPDB].[dbo].[tMachines] M on M.ID = A.id_Machine ";

        private void BindGrid()
        {
            //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {//declaramos el query
                using (SqlCommand cmd = new SqlCommand(query))
                {//declaramos un adaptador sql
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {//hacemos la coneccion
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);//llenamos los  valores
                            gdvAnswer.DataSource = dt;// "" ""
                            gdvAnswer.DataBind(); //"" ""
                        }
                    }
                }
            }
        }
        protected void BtnAlerts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertsHRI.aspx");
        }

        protected void btnHomes_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome.aspx");
        }

        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }

        protected void btnHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRIManager.aspx");
        }

        protected void BtnControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlHRI.aspx");
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("default.aspx");
        }
    }
}