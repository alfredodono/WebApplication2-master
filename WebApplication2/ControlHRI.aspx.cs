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
    public partial class ControlHRI : System.Web.UI.Page
    {

        //nos carga la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //aqui checa si tenemos alguna inicion iniciada si no nos redirecciona directo al login
            if (Session["User"] != null)//checamos si hay alguna session
            {
                //nos muestra el nombre del usuario en la aprte superior derecha
                lblId.Text = "welcome " + Session["User"];
            }
            else
            {
                //si no tenemos alguna session iniciada nos direcciona al login 
                Response.Redirect("default.aspx");
            }

            if (!this.IsPostBack)
            {
                //si recarga la pagina  actualiza los registros
                this.BindGrid();
            }
            //guardamos el nombre del usuario actual
            string usuario = "" + Session["User"];
            if (usuario == "scp")// cmparamos si es el administrador SCP
            {
                //nos muestra la opcion de ditar usuarios
                BtnUsers.Visible = true;
            }
            else
            {
                //no nos la muestra
                BtnUsers.Visible = false;
            }
            //definimos los campos donde mostraremos los mensajes
            lblmensaje.Text = "";
            jolosoy.Text = "";

            txtUser.Attributes.Add("readonly", "readonly");//definimos este campo para poder manipularlo sin interrupciones
            txtHRI.Attributes.Add("readonly", "readonly");//    ""          ""          ""              ""
        }

        private void BindGrid()//aqui solo actualiza las tablas para mostrar cualquier modificacion
        {


            //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {//declaramos el query
                using (SqlCommand cmd = new SqlCommand("Select I.id_uhi as 'ID', U.n_user as 'User', H.Name_HRI as 'HRI' from Users U inner join UHI I on I.id_user=U.id_user inner join HRI H on I.id_HRI=H.id_HRI "))
                {//declaramos un adaptador sql
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {//hacemos la coneccion
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);//llenamos los  valores
                            TablaRel.DataSource = dt;// "" ""
                            TablaRel.DataBind(); //"" ""
                        }
                    }
                }
            }
            //hacemos lo mismo que la parte anterior pero con otra tabla
            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_user as 'ID', n_user as 'Usuario' from dbo.users "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cons;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tablaus.DataSource = dt;
                            tablaus.DataBind();

                        }
                    }
                }
            }
            //lo mismo que anteriormente pero con otra tabla
            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_HRI as 'ID', Name_HRI as 'HRI' from dbo.hri "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cons;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdvHRI.DataSource = dt;
                            gdvHRI.DataBind();

                        }
                    }
                }
            }

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            int customerId = Convert.ToInt32(TablaRel.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM UHI WHERE id_uhi = @CustomerId"))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblmensaje.Text = "Eliminado Con Exito";
                }
            }

            BindGrid();
        }


        //Inician los Redireccionaminetos del menu

        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }
        protected void BtnHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRImanager.aspx");
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void BtnControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlHRI.aspx");
        }

        protected void gdvHRI_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int customerId = Convert.ToInt32(TablaRel.DataKeys[e.RowIndex].Values[0]);
            Response.Redirect("details.aspx?Parameter=" + customerId);


        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("default.aspx");
        }
        //Terminan los direccionamientos del menu


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select I.id_uhi as 'ID', U.n_user as 'User', H.Name_HRI as 'HRI' from Users U inner join UHI I on I.id_user=U.id_user inner join HRI H on I.id_HRI=H.id_HRI where U.n_user LIKE '%" + TextBox2.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            TablaRel.DataSource = dt;
                            TablaRel.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select I.id_uhi as 'ID', U.n_user as 'User', H.Name_HRI as 'HRI' from Users U inner join UHI I on I.id_user=U.id_user inner join HRI H on I.id_HRI=H.id_HRI where U.n_user LIKE '%" + TextBox2.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            TablaRel.DataSource = dt;
                           TablaRel.DataBind();
                        }
                    }
                }
            }
        }

        protected void txbUsuarios_TextChanged(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_user as 'ID', n_user as 'Usuario' from dbo.users where n_user LIKE '%" + txbUsuarios.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tablaus.DataSource = dt;
                            tablaus.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_user as 'ID', n_user as 'Usuario' from dbo.users where U.n_user LIKE '%" + txbUsuarios.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tablaus.DataSource = dt;
                            tablaus.DataBind();
                        }
                    }
                }
            }
        }

        protected void tablaus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(tablaus.DataKeys[e.RowIndex].Values[0]);

            txtUser.Text = customerId.ToString();
            
           
        }


        protected void txbHRI_TextChanged(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_HRI as 'ID', Name_HRI as 'HRI' from dbo.hri where Name_HRI LIKE '%" + txbHRI.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdvHRI.DataSource = dt;
                            gdvHRI.DataBind();
                        }
                    }
                }
            }
        }

        protected void gdvHRI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(gdvHRI.DataKeys[e.RowIndex].Values[0]);

            txtHRI.Text = customerId.ToString();

        }


        protected void btnrel_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());
            con.Open();

            if(txtUser.Text=="" || txtHRI.Text=="")
            {
                lblmensaje.Text = "hay campos sin llenar";
            }
            else
            {

            
            int quepex = Convert.ToInt32(txtUser.Text);
            int quepox = Convert.ToInt32(txtHRI.Text);
            
            String query = "Select count (*) from dbo.UHI where id_HRI= '" + quepox + "' and id_user= '"+quepex+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            String output = cmd.ExecuteScalar().ToString();
            if(output=="1")
            {
                lblmensaje.Text = "Ya existe esa relacion";
                txtHRI.Text = "";
                txtUser.Text = "";
            }
            else
            {
               
                query = "Insert into dbo.UHI (id_HRI, id_user) values ('" + quepox + "' , '" + quepex + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
              

                BindGrid();
                lblmensaje.Text = "Guardado Con Exito";

                txtUser.Text = "";
                txtHRI.Text = "";
            }
                con.Close();

            }
        }

        protected void BtnAlerts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertsHRI.aspx");
        }
    }
}