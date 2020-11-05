using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("welcome.aspx");
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ToString());
            con.Open();
            String query = "Select count (*) from dbo.users where n_user= '"+txtuser.Text + "' and n_pass= '" + txtpassword.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            String output = cmd.ExecuteScalar().ToString();
            if(output=="1")
            {
                Session["User"] = txtuser.Text;
                Response.Redirect("welcome.aspx");
            }

            else
            {
                Response.Write("your username and password is wrong ?");
            }

        }
    }
}