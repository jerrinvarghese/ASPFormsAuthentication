using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPFormsAuth
{
    public partial class LockedPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter ad;
        DataTable dt=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var LockFreeTime = "";
            var UserName = Session["UserName"];
            con = new SqlConnection("Data Source=SUYPC070;Initial Catalog=Step2017;User Id=sa;Password=Suyati123;");
            con.Open();
            ad = new SqlDataAdapter("select LockedFreeTime from ASPRegister where UserName='"+UserName+"'", con);
            ad.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                LockFreeTime = dr["LockedFreeTime"].ToString();
            }
            Lbl_Time.Text = LockFreeTime;
            con.Close();
        }
    }
}