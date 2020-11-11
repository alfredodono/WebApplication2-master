using System;
using System.Activities;
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

    public partial class Details : System.Web.UI.Page
    {
        String HRI;
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

            if (!this.IsPostBack)
            {
               // this.BindGrid();
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

          HRI = Request.QueryString["Parameter"].ToString();

        }

        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }
        protected void BtnHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRImanager.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("default.aspx");
        }


        private void BindGrid()
        {



                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("Select ID As 'ID', Nombre As 'Nombre' , IP As 'IP', Tipo as 'Type'   from [LUIS AGUILAR].[ADESCPDB].[dbo].[tMachines] "))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                            TablaIp.DataSource = dt;
                            TablaIp.DataBind();
                            //ajuas.DataSource = dt;
                           // ajuas.DataBind();
                        }
                        }
                    }
                }

            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select I.id_IP As 'ID', M.nombre As 'Nombre', M.ip as 'IP', m.tipo As 'Type' FROM IPS I inner join[LUIS AGUILAR].[ADESCPDB].[dbo].[tMachines] M on I.ID_Machine = M.ID where id_HRI = '"+ Request.QueryString["Parameter"].ToString()+"'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cons;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                           gdvIpA.DataSource = dt;
                            gdvIpA.DataBind();
                        }
                    }
                }
            }

            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("select ID As 'ID', Nombre As 'Nombre' from [LUIS AGUILAR].[ADESCPDB].[dbo].[EquipESP]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cons;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GdvEsp.DataSource = dt;
                            GdvEsp.DataBind();
                        }
                    }
                }
            }

            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select I.id_IP As 'ID', M.nombre As 'Nombre' FROM [LUIS AGUILAR].[ADESCPDB].[dbo].[IPS2] I inner join [LUIS AGUILAR].[ADESCPDB].[dbo].[EquipESP] M on I.ID_Machine = M.ID where id_HRI =  '" + Request.QueryString["Parameter"].ToString() + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cons;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdvEspAs.DataSource = dt;
                            gdvEspAs.DataBind();
                        }
                    }
                }
            }
            // try
            // {


            // con.Open();
            //  String query = "Select id_user As 'id', n_user As 'Usuario', n_pass As 'Contraseña'  from dbo.users ";
            // SqlCommand cmd = new SqlCommand(query, con);
            //  SqlDataReader rdr = cmd.ExecuteReader();
            //  gdvusuarios.DataSource = rdr;

            //  gdvusuarios.DataBind();
            //  gdvusuarios.Columns[1].HeaderText = "TextoAMostrarEnLaCabecera";

            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("algo anda mal");
            // }
            // finally
            // {
            //    con.Close();
            // }

        }

      

        protected void FiltroIps(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID As 'ID', Nombre As 'Nombre' , IP As 'IP', Tipo as 'Type'   from [LUIS AGUILAR].[ADESCPDB].[dbo].[tMachines] where  Nombre LIKE'" + TextBox1.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            TablaIp.DataSource = dt;
                            TablaIp.DataBind();
                        }
                    }
                }
            }
        }

        protected void FiltroMaA(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("select id as 'ID', Nombre As 'Nombre' from [LUIS AGUILAR].[ADESCPDB].[dbo].[EquipESP] where  Nombre LIKE'" + TextBox3.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GdvEsp.DataSource = dt;
                            GdvEsp.DataBind();
                        }
                    }
                }
            }
        }

        protected void gdvHRI_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int customerId = Convert.ToInt32(TablaIp.DataKeys[e.RowIndex].Values["ID"]);
            String AJA = Request.QueryString["Parameter"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            con.Open();
         String query = "SelecT count (*) from [LUIS AGUILAR].[ADESCPDB].[dbo].[IPS2] where id_Machine = '" + customerId +"' and id_HRI= '"+AJA+"'";
          SqlCommand cmd = new SqlCommand(query, con);
         String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
           {
                // Response.Write("El usuario ya existe ?");
                // lblmensaje.Text = "El usuario ya existe ?";
                //  jolosoy.Text = "";
                lblmensaje.Text = "ya esta registrado";
           }
           else
            {

                query = "Insert into IPS(id_HRI, id_Machine) values('" + AJA +"', '"+ customerId +"')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
               con.Close();

              lblmensaje.Text="Guardado Con Exito";
            //  txthri.Text = "";

            //  lblmensaje.Text = "Usuario Guardado Con Exito";
            //  jolosoy.Text = "";

             }

            BindGrid();


        }

        protected void GDVEspAd(object sender, GridViewUpdateEventArgs e)
        {

            int customerId = Convert.ToInt32(GdvEsp.DataKeys[e.RowIndex].Values["ID"]);
            String AJA = Request.QueryString["Parameter"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            con.Open();
            String query = "SelecT count (*) from [LUIS AGUILAR].[ADESCPDB].[dbo].[IPS2] where id_Machine = '" + customerId + "' and id_HRI= '" + AJA + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                lblmensaje.Text = "El Equipo ya esta Asignado";
              //  Response.Write("");
                // lblmensaje.Text = "El usuario ya existe ?";
                //  jolosoy.Text = "";
            }
            else
            {

                query = "Insert into [LUIS AGUILAR].[ADESCPDB].[dbo].[IPS2](id_HRI, id_Machine) values('" + AJA + "', '" + customerId + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                lblmensaje.Text = "Equipo guardado con exito";
                //  txthri.Text = "";

                //  lblmensaje.Text = "Usuario Guardado Con Exito";
                //  jolosoy.Text = "";

            }

            BindGrid();


        }


        protected void gdvHRI_borrar(object sender, GridViewUpdateEventArgs e)
        {

            int cid = Convert.ToInt32(gdvIpA.DataKeys[e.RowIndex].Values["ID"]);
            String AJA = Request.QueryString["Parameter"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            con.Open();
            String query;
       
                query = "Delete from IPS where id_IP ='" + cid + "' and id_HRI= '" + AJA + "'";
            SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                lblmensaje.Text="ELIMINADO CON EXITO";
                //  txthri.Text = "";

                //  lblmensaje.Text = "Usuario Guardado Con Exito";
                //  jolosoy.Text = "";

          //  }

            BindGrid();


        }

        protected void gdbEspBS(object sender, GridViewUpdateEventArgs e)
        {

            int cid = Convert.ToInt32(gdvEspAs.DataKeys[e.RowIndex].Values["ID"]);
            String AJA = Request.QueryString["Parameter"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            con.Open();
            String query;

            query = "Delete from [LUIS AGUILAR].[ADESCPDB].[dbo].[IPS2] where id_IP ='" + cid + "' and id_HRI= '" + AJA + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

           lblmensaje.Text="ELIMINADO CON EXITO";
            //  txthri.Text = "";

            //  lblmensaje.Text = "Usuario Guardado Con Exito";
            //  jolosoy.Text = "";

            //  }

            BindGrid();


        }

        protected void btncHRI_Click(object sender, EventArgs e)
        {

            Response.Redirect("HriCreate.aspx?Parameter=" + HRI);
        }

        protected void btnVovler_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRIManager.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void BtnControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlHRI.aspx");
        }

        protected void BtnAlerts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertsHRI.aspx");
        }
    }

    
}
