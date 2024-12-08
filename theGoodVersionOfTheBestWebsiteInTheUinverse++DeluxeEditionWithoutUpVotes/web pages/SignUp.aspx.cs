using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] !=null) {
            string userName = Request.Form["userName"];
            string fileName = "Database.mdf";
            string sqlSelect = "select * from Tbl where UserName = '" + userName + "'";
            DataTable tableSelect = MyAdoHelper.ExecuteDataTable(fileName, sqlSelect);
            int length = tableSelect.Rows.Count;
            if (length > 0)
            {
               msg = "userName already taken";
            }else
            {
                    string sqlInsert = "INSERT INTO Tbl (UserName,password,name,age,gender,Manger,profilePic) VALUES('" + Request.Form["userName"] + "','" + Request.Form["password"] + "','" + Request.Form["fullName"] + "'," + Request.Form["age"] + ",'" + Request.Form["gender"] + "','False','<img onclick=\"image()\" style=\"height: 180px; width:auto;\" src = \"../images/defualtPic.png\" />');";
                    DataTable tableInsert = MyAdoHelper.ExecuteDataTable(fileName, sqlInsert);
                    Session["userName"] = userName;
                    Response.Redirect("main.aspx");
            }
            
        }
    }
}