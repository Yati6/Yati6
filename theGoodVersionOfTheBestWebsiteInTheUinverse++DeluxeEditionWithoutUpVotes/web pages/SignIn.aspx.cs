using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheWebsite_Default : System.Web.UI.Page
{
    public string user = "";
    public string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];

            string fileName = "Database.mdf";
            string sql = "select * from Tbl where UserName = '" + userName + "' and password = '" + password + "'";
            DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
            int length = table.Rows.Count;
            if (length <= 0)
            {
                msg = "userName or password is incorrect";
            }
            else
            {
                
                Session["userName"] = userName;

                string sql2 = "select * from Tbl where UserName = '" + userName + "' and Manger = 'True'";
                DataTable table2 = MyAdoHelper.ExecuteDataTable(fileName, sql2);
                int length2 = table2.Rows.Count;
                if (length2 > 0)
                    Session["admin"] = "True";
                Response.Redirect("main.aspx");

            }

        }
    }
}