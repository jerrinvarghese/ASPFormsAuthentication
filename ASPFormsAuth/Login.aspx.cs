using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPFormsAuth
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rd;
        SqlDataReader rd2;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=SUYPC070;Initial Catalog=Step2017;User Id=sa;Password=Suyati123;");
            con.Open();
            SetUsersFree();
        }

        public void SetUsersFree()
        {
            
            var time = Convert.ToString(DateTime.Now);
            SqlCommand cmd2 = new SqlCommand("update ASPRegister set AttemptsLeft=10,IsLocked=0,LockedFreeTime=NULL,LockedTime=NULL where '" + time + "'> LockedFreeTime", con);
            cmd2.ExecuteNonQuery();
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            
           
            //if (FormsAuthentication.Authenticate(txtUserName.Text, txtPwd.Text))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkboxPersist.Checked);
            //}
            //else
            //{
            //    Msg.Text = "Invalid User Name and/or Password";
            //}
            
                
                var uname = txtUserName.Text;
                var pswd = txtPwd.Text;
                Session["UserName"]= txtUserName.Text;
                
                cmd = new SqlCommand("select * from ASPRegister where UserName='" + uname + "' AND Password='" + pswd + "'", con);
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Server.Transfer("Welcome.aspx");
                        
                    }
                
                }
               
                else
                {
                var attemptsleft="";
                int islocked = 1;
                int islock;
                rd.Close();
               
                SqlDataAdapter adp = new SqlDataAdapter("select AttemptsLeft,IsLocked from ASPRegister where UserName='" + txtUserName.Text + "'", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
               foreach(DataRow dr in dt.Rows)
                {
                    attemptsleft = dr["AttemptsLeft"].ToString();
                    islocked = Convert.ToInt16(dr["IsLocked"]);
                }

                islock = islocked;
                if (islocked == 1)
                {
                    Response.Redirect("~/Register/LockedPage.aspx");
                }
                else
                {
                    int attmptLeft = Convert.ToInt16(attemptsleft);
                    attmptLeft = attmptLeft - 1;
                    if (attmptLeft <= 0)
                    {
                        var lockedtime = Convert.ToString(DateTime.Now);
                        var lockfreetime = Convert.ToString(DateTime.Now.AddMinutes(2));
                        SqlCommand cmd2 = new SqlCommand("update ASPRegister set AttemptsLeft='" + attmptLeft + "' where UserName='" + txtUserName.Text + "'", con);
                        cmd2.ExecuteNonQuery();
                        SqlCommand cmd3 = new SqlCommand("update ASPRegister set IsLocked='" + 1 + "' where UserName='" + txtUserName.Text + "'", con);
                        cmd3.ExecuteNonQuery();
                        SqlCommand cmd4 = new SqlCommand("update ASPRegister set LockedTime='" + lockedtime + "' where UserName='" + txtUserName.Text + "'", con);
                        cmd4.ExecuteNonQuery();
                        SqlCommand cmd5 = new SqlCommand("update ASPRegister set LockedFreeTime='" + lockfreetime + "' where UserName='" + txtUserName.Text + "'", con);
                        cmd5.ExecuteNonQuery();

                        Response.Redirect("~/Register/LockedPage.aspx");
                    }
                    else
                    {
                        AttemptsLbl.Text = attmptLeft.ToString();
                        SqlCommand cmd2 = new SqlCommand("update ASPRegister set AttemptsLeft='" + attmptLeft + "' where UserName='" + txtUserName.Text + "'", con);
                        cmd2.ExecuteNonQuery();
                    }
                }
                    
            }
               
                         


        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}