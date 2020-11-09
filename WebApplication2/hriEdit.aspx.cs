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
    public partial class hriEdit : System.Web.UI.Page
    {

        String HRI,a;

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
            pregunta();

        }


        private void pregunta()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_hri from dbo.ima where id_foto='" + HRI + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                      //  txtUser.Text = sdr["c"].ToString();
                        a = sdr["id_hri"].ToString();
                        //  int b = Convert.ToInt32(a);
                      //  if (a =="True")
                      //  {
                      //      Cb1.Checked = true;
                      //  }
                      //  else
                      //  {
                         //   Cb1.Checked = false;
                       // }

                    }
                    con.Close();

                }
            }
        }

        private void BindGrid()
        {




            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select id_hri As 'id' , Question As 'Question', picture As 'Picture' , req as 'required'  from dbo.ima where id_foto='" + HRI + "'"))
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
            Response.Redirect("HRICreate.aspx?Parameter=" + a);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String user = txtUser.Text.ToUpper();
            string query;
            int a;
            if (Cb1.Checked)
            {
                a = 1;
            }
            else
            {
                a = 0;
            }

            if(fuimage.HasFile)
            {
                using (Stream fs = fuimage.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            if (txtUser.Text == String.Empty)
                            {
                                query = "update dbo.ima set  Picture=@Picture, req=@req where id_foto=@id_Foto";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {

                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Picture", bytes);
                                    cmd.Parameters.AddWithValue("@req", a);
                                    cmd.Parameters.AddWithValue("@id_Foto", HRI);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            else
                            {
                                query = "update dbo.ima set Question=@Question, Picture=@Picture, req=@req where id_foto=@id_Foto";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {

                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Question", user);
                                    cmd.Parameters.AddWithValue("@Picture", bytes);
                                    cmd.Parameters.AddWithValue("@req", a);
                                    cmd.Parameters.AddWithValue("@id_Foto", HRI);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            
                        }
                    }
                }

            }
            else
            {
                using (Stream fs = fuimage.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            if(txtUser.Text == String.Empty)
                            {
                                query = "update dbo.ima set req=@req where id_foto=@id_Foto";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {

                                    cmd.Connection = con;
                       

                                    cmd.Parameters.AddWithValue("@req", a);
                                    cmd.Parameters.AddWithValue("@id_Foto", HRI);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }else
                            {
                                query = "update dbo.ima set Question=@Question, req=@req where id_foto=@id_Foto";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {

                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Question", user);

                                    cmd.Parameters.AddWithValue("@req", a);
                                    cmd.Parameters.AddWithValue("@id_Foto", HRI);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                           
                        }
                    }
                }
            }


            BindGrid();



        }

        protected void gdvusuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(gdvusuarios.DataKeys[e.RowIndex].Values[0]);



            Response.Redirect("hriEdit.aspx?Parameter=" + customerId);
        }
    }
}