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
    public partial class usuarios : System.Web.UI.Page
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

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
            string usuario = ""+Session["User"];
            if (usuario == "scp")
            {
                BtnUsers.Visible = true;
            }
            else
            {
                BtnUsers.Visible = false;
            }
            lblmensaje.Text = "";
            jolosoy.Text="";
            
            
        }

        private void BindGrid()
        {

            

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_user As 'id' , n_user As 'Usuario', n_pass As 'Password'   from dbo.users "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdvusuarios.DataSource = dt;
                            gdvusuarios.DataBind();
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
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gdvusuarios.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("default.aspx");
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int customerId = Convert.ToInt32(gdvusuarios.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE id_user = @CustomerId"))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
           // if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gdvusuarios.EditIndex)
           // {
            //    (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["OnClick"] = "return confirm('Estas Seguro de Eliminar esto');";
           // }
        }

        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }
        protected void BtnHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRImanager.aspx");
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvusuarios.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string id = (row.Cells[0].Controls[0] as TextBox).Text;
            string Usuario = (row.Cells[1].Controls[0] as TextBox).Text;
            string Password = (row.Cells[2].Controls[0] as TextBox).Text;
            

            con.Open();
            String query = "Update dbo.users set n_user='" + Usuario  + "', n_pass='" + Password  + "' where id_user='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
           
            gdvusuarios.EditIndex = -1;
            this.BindGrid();
            
           // Response.Write("Usuario Guardado Con Exito");
            
           

        }

        protected void OnCancel(object sender, EventArgs e)
        {
            gdvusuarios.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());
            if (txtPass.Text == txtPass2.Text)
            {
                con.Open();
                String query = "Select count (*) from dbo.users where n_user= '" + txtUser.Text+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                String output = cmd.ExecuteScalar().ToString();
              
                if (output == "1")
                {
                    //Response.Write("El usuario ya existe ?");
                    lblmensaje.Text = "El usuario ya existe ?";
                    jolosoy.Text = "";
                } else
                {
                    
                     query = "Insert into dbo.users (n_user, n_pass) values ('" + txtUser.Text + "' , '" + txtPass.Text + "')";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                  //  Response.Write("Usuario Guardado Con Exito");
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtPass2.Text = "";


                    lblmensaje.Text = "Usuario Guardado Con Exito";
                    jolosoy.Text = "";

                }

                this.BindGrid();

            }
            else
            {
               // Response.Write("la contraseña no coincide");
                //label2.Text = "la contraseña no coincide";
                jolosoy.Text = "la contraseña no coincide";
                lblmensaje.Text = "";
            }

            




        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome.aspx");
        }
    }
}