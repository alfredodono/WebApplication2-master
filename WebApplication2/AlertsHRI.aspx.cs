using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
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

            if (!Page.IsPostBack)
            {
                txtfrom.Text = DateTime.Today.ToString("yyyy-MM-dd");
                DateTime manana = DateTime.Today.AddDays(1);
                Txtto.Text = manana.ToString("yyyy-MM-dd");
            }
           

           BindGrid();
        }
        String q = DateTime.Today.ToString();
        public String query = "select A.id_answer as 'ID',R.Name_HRI as 'NameHRI', (case id_Machine when 0 then A.Machine_Name else M.Nombre end) as 'Machine_Name',A.equip_esp as 'EquipoEspecial',I.Question as 'question', A.Date as 'Date', Q.Status as 'status',foto as 'foto' from Users U inner join UHI H on U.id_user=H.id_user inner join Answer A on A.id_HRI=H.id_HRI inner join QStatus Q on A.Status = Q.idStatus inner join ima I on I.id_foto = A.id_foto inner join HRI R on H.id_HRI=R.id_HRI left join[LUIS AGUILAR].[ADESCPDB].[dbo].[tMachines] M on M.ID = A.id_Machine ";

        private void BindGrid()

        {
           if (dpcheck.Text == "OK")
            {
                //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                {//declaramos el query
                    using (SqlCommand cmd = new SqlCommand(query + "where n_user = '" + Session["User"] + "' and Date between '" + txtfrom.Text + "' and '" + Txtto.Text + "' and q.idStatus ='1'"))
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
            }else
            {


            if (dpcheck.Text== "No Check")
            {
                   
                //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                {//declaramos el query
                    using (SqlCommand cmd = new SqlCommand(query + "where n_user = '" + Session["User"] + "' and Date between '" + txtfrom.Text + "' and '" + Txtto.Text + "' and q.idStatus ='2'"))
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
                }else
                {
                    if (dpcheck.Text == "Check")
                    {
                        //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                        {//declaramos el query
                            using (SqlCommand cmd = new SqlCommand(query + "where n_user = '" + Session["User"] + "' and Date between '" + txtfrom.Text + "' and '" + Txtto.Text + "' and q.idStatus ='3'"))
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

                    if(dpcheck.Text == "All")
                    {
                        //tomamos el valor de la coneccion a la base de datos definida anteriormente en el web.config  
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
                        {//declaramos el query
                            using (SqlCommand cmd = new SqlCommand(query + "where n_user = '" + Session["User"] + "' and Date between '" + txtfrom.Text + "' and '" + Txtto.Text + "'"))
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

        protected void txtfrom_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void dpcheck_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
            
    }

        protected void gdvAnswer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // txterror.Text = "revise personalmente no hay imagen";
            int customerId = Convert.ToInt32(gdvAnswer.DataKeys[e.RowIndex].Values["ID"]);
            string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
            
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Update Answer set Status= 3 where id_answer = @CustomerId and Status=@status"))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@status", '2');
                    cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindGrid();

                    }
                }
            
           

           
        }


        protected void gdvAnswer_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (dr["status"].ToString()== "No Check")
                {
                  //  string ImmageURl = "~/img/check1.png";
                  //  (FindControl("hol") as System.Web.UI.WebControls.Image).ImageUrl = ImmageURl;
                }
                if (dr["foto"].ToString()=="")
                {
                    
                    
                }
                else
                {
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);
                    (e.Row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
                }
            }
        }

        protected void gdvAnswer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int customerId = Convert.ToInt32(gdvAnswer.DataKeys[e.RowIndex].Values[0]);
         
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select foto from dbo.answer where id_answer='" + customerId + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr["foto"].ToString() == "")
                        {
                            Image2.ImageUrl = "~/img/aaaa.png";
                            txterror.Text = "revise personalmente no hay imagen";
                        }else
                        {
                            txterror.Text = "";
                            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])sdr["foto"]);
                            (FindControl("image2") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
                        }

                        



                    }
                    con.Close();

                }
            }





            
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;

            string constr = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select foto from dbo.answer where id_answer=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr["foto"].ToString() == "")
                        {
                            txterror.Text = "no hay imagen disponible para descargar ";
                        }
                        else
                        {
                            bytes = (byte[])sdr["foto"];
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = "image/jpg";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=jalese.jpg");
                            Response.BinaryWrite(bytes);
                            Response.Flush();
                            Response.End();
                        }
                        

                    }
                    con.Close();
                }
            }
            
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(query + "where n_user = '" + Session["User"] + "' and Date between '" + txtfrom.Text + "' and '" + Txtto.Text + "'" + " and R.Name_HRI LIKE '%" + TextBox5.Text + "%'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdvAnswer.DataSource = dt;
                            gdvAnswer.DataBind();
                        }
                    }
                }
            }
        }
    }
}