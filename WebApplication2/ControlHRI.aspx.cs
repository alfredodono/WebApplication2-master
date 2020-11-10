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
            string usuario = "" + Session["User"];
            if (usuario == "scp")
            {
                BtnUsers.Visible = true;
            }
            else
            {
                BtnUsers.Visible = false;
            }
            lblmensaje.Text = "";
            jolosoy.Text = "";

            txtUser.Attributes.Add("readonly", "readonly");
            txtHRI.Attributes.Add("readonly", "readonly");
        }

        private void BindGrid()
        {



            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select I.id_uhi as 'ID', U.n_user as 'User', H.Name_HRI as 'HRI' from Users U inner join UHI I on I.id_user=U.id_user inner join HRI H on I.id_HRI=H.id_HRI "))
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
            //gdvHRI.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowEditings(object sender, GridViewEditEventArgs e)
        {
            // gdvEsp.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            // gdvHRI.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }

        protected void OnPagings(object sender, GridViewPageEventArgs e)
        {
            //gdvEsp.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string id = (row.Cells[0].Controls[0] as TextBox).Text;
            string hri = (row.Cells[1].Controls[0] as TextBox).Text;
            // string Password = (row.Cells[2].Controls[0] as TextBox).Text;


            con.Open();
            String query = "Update dbo.hri set Name_HRI='" + hri + "' where id_HRI='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            // gdvHRI.EditIndex = -1;
            this.BindGrid();

            // Response.Write("Usuario Guardado Con Exito");



        }

        protected void OnCancel(object sender, EventArgs e)
        {
            // gdvHRI.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnUpdateEsp(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer2"].ToString());

            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string id = (row.Cells[0].Controls[0] as TextBox).Text;
            string Nombre = (row.Cells[1].Controls[0] as TextBox).Text;
            // string Password = (row.Cells[2].Controls[0] as TextBox).Text;


            con.Open();
            String query = "Update dbo.EquipESP set Nombre='" + Nombre + "' where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            // gdvEsp.EditIndex = -1;
            this.BindGrid();

            // Response.Write("Usuario Guardado Con Exito");



        }

        protected void OnCancelEsp(object sender, EventArgs e)
        {
            //gdvEsp.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());

            con.Open();
            String query = "Select count (*) from dbo.hri where Name_HRI= '" + lblmensaje + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                //Response.Write("El usuario ya existe ?");
                lblmensaje.Text = "El hri ya existe ?";
                jolosoy.Text = "";
            }
            else
            {

                query = "Insert into dbo.HRI (Name_HRI) values ('" + lblmensaje + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                //  Response.Write("Usuario Guardado Con Exito");
                // txthri.Text = "";

                lblmensaje.Text = "Creado Con Exito";
                jolosoy.Text = "";

            }

            this.BindGrid();


        }

        protected void btnAddEsp_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer2"].ToString());

            con.Open();
            String query = "Select count (*) from dbo.EquipESP where Nombre= '" + lblmensaje + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                //Response.Write("El usuario ya existe ?");
                lblmensaje.Text = "El EquipoEsp ya existe ?";
                jolosoy.Text = "";
            }
            else
            {

                query = "Insert into dbo.EquipESP (Nombre) values ('" + lblmensaje + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                //  Response.Write("Usuario Guardado Con Exito");
                //txthri.Text = "";

                lblmensaje.Text = "Guardado Con Exito";
                jolosoy.Text = "";

            }

            this.BindGrid();


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
                con.Close();

                BindGrid();
                lblmensaje.Text = "Guardado Con Exito";

                txtUser.Text = "";
                txtHRI.Text = "";
            }

        }
    }
}