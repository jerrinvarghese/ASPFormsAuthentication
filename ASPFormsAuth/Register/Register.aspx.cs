using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPFormsAuth
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=SUYPC070;Initial Catalog=Step2017;User Id=sa;Password=Suyati123;");
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            con = new SqlConnection("Data Source=SUYPC070;Initial Catalog=Step2017;User Id=sa;Password=Suyati123;");
            con.Open();
            var un = txtUserName.Text;
            var pswd = txtPwd.Text;
            var cpswd = txtCPwd.Text;

            if(pswd!=cpswd)
            {
                Label1.Text = "Password Not Matching";
            }
            var em = txtEmail.Text;
            
            cmd = new SqlCommand("insert into ASPRegister(UserName,Password,Email,AttemptsLeft,IsLocked) values ('"+ un + "', '"+pswd+"', '"+em+ "','"+3+"','"+0 + "')", con);
            cmd.ExecuteNonQuery();

        }
    }
}