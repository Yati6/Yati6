using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_profile : System.Web.UI.Page {
    public string msg = "";
    public string userPic = "<img onclick=\"image()\" alt='defult profile picture' style=\"height: 180px;width:auto;\" src = '../images/defualtPic.png' />";
    protected void Page_Load(object sender, EventArgs e) {
        if ((string)Session["userName"] != "guest")
        {
            string fileName = "Database.mdf";
            string sql = "select profilePic from Tbl where UserName = '" + Session["userName"] + "';";
            DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
            userPic = (string)table.Rows[0]["profilePic"];
        }
        if (Request.Form["signOut"] != null) {
            Session["userName"] = "guest";
            Session["admin"] = "False";
            Response.Redirect("main.aspx");
        }
        userPic = userPic.Replace("height: 180px;", "height: 400px;");
        if (Request.Form["submitChange"] != null) {
            string fileName = "Database.mdf";
            if (Request.Form["columns"] == "UserName") {
                string sqlSelect = "select * from Tbl where UserName = '" + Request.Form["value"] + "'";
                DataTable tableSelect = MyAdoHelper.ExecuteDataTable(fileName, sqlSelect);
                int length = tableSelect.Rows.Count;
                if (length > 0) {
                    msg = "userName already taken";
                } else {
                    string sqlInsert = "INSERT INTO TblC (UserName,password,name,age,gender,Manger,profilePic) VALUES('" + Request.Form["userName"] + "','" + Request.Form["password"] + "','" + Request.Form["fullName"] + "'," + Request.Form["age"] + ",'" + Request.Form["gender"] + "','False','<img onclick=\"image()\" style=\"height: 180px; width:auto;\" src = \"../images/defualtPic.png\" />');";
                    DataTable tableInsert = MyAdoHelper.ExecuteDataTable(fileName, sqlInsert);
                    Session["userName"] = Request.Form["value"];
                    Response.Redirect("main.aspx");
                }
            } else {
                string sql = "UPDATE Tbl SET " + Request.Form["columns"] + "='" + Request.Form["value"] + "'WHERE UserName ='" + (string)Session["userName"] + "';";
                DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
                Response.Redirect("main.aspx");
            }
        }
    }
}