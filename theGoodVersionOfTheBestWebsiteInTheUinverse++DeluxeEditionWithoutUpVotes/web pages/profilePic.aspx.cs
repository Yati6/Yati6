using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Request.Form["submit"] != null) {

            string fileName = "Database.mdf";
            string sql = "UPDATE Tbl SET profilePic = '<img onclick=\"image()\" style=\"height: 180px; width: auto;\"  src=\"" + Request.Form["picUrl"] +"\" />'WHERE UserName ='"+ Session["userName"] +"';";
            DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        }
    }
}