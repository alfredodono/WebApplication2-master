using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication2
{
    public partial class HriCreate : System.Web.UI.Page
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
              //  this.BindGrid();
               // HRI = Request.QueryString["Parameter"].ToString();
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
            HRI = Request.QueryString["Parameter"].ToString();
            BindGrid();
           
        }

        private void BindGrid()
        {

         

           
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("Select id_foto As 'id' , Question As 'Question', picture As 'Picture' , req as 'required'  from dbo.ima where id_HRI='" + HRI + "'"))
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
          
           


           
        }
           protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Picture"]);
                (e.Row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
            }
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
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.ima WHERE id_foto = @CustomerId"))
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
     

        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }
        protected void BtnHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRImanager.aspx");
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRImanager.aspx");
        }



        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvusuarios.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowUpdating(object sender, EventArgs e)
        {

            Response.Redirect("hriEdit.aspx?Parameter=" + HRI);




        }

        protected void OnCancel(object sender, EventArgs e)
        {
            gdvusuarios.EditIndex = -1;
            this.BindGrid();
        }


        protected void btnVol_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRIManager.aspx");
        }

        protected void btnvolHRI_Click(object sender, EventArgs e)
        {
            Response.Redirect("Details.aspx?Parameter=" + HRI);
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if(txtUser.Text=="" )
            {
                jolosoy.Text = "falta ingresar un campo";
            }
            else
            
            {
                if (fuimage.HasFile)
                {
                    String user = txtUser.Text.ToUpper();

                    int a;
                    if (Cb1.Checked)
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }


                    using (Stream fs = fuimage.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string query = "Insert into dbo.ima values (@Question, @Picture, @id_HRI, @active, @req)";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Question", user);
                                    cmd.Parameters.AddWithValue("@Picture", bytes);
                                    cmd.Parameters.AddWithValue("@id_HRI", HRI);
                                    cmd.Parameters.AddWithValue("@active", '1');
                                    cmd.Parameters.AddWithValue("@req", a);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }


                    BindGrid();
                }
                else
                {
                    jolosoy.Text = "falta subir alguna imagen";
                }
           
            
            }

        }

        protected void gdvusuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(gdvusuarios.DataKeys[e.RowIndex].Values[0]);



            Response.Redirect("hriEdit.aspx?Parameter=" + customerId);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome.aspx");
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