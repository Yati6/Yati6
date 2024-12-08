using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_Default : System.Web.UI.Page
{
    public int length;
    public string msg;
    
    protected void Page_Load(object sender, EventArgs e) {
        if (Request.Form["submit"] != null) {
                string fileName = "Database.mdf";
                string sql = "select * from TblQ;";
                DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
                length = table.Rows.Count;
                string sqlAdd = "insert into TblQ (IDNumber,question,description,tags,maker) VALUES(" + ((int)table.Rows[length - 1]["IDNumber"]+1) + ",'" + Request.Form["question"] + "','" + Request.Form["description"] + "','" + Request.Form["tags"] + "','" + Session["userName"] +"');";
                DataTable tableAdd = MyAdoHelper.ExecuteDataTable(fileName, sqlAdd);
                Response.Redirect("feed.aspx");
            
        }
    }
}