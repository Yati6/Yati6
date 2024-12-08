using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public String user;
    public String userPic = "<img alt='defult profile picture' style=\"height: 180px;width:auto;\" src = '../images/defualtPic.png' />";
    public String managerPage = "";
    public String linkLog = "\r\n            <td>\r\n                <h2><a class=\"pageLink\" href=\"SignIn.aspx\">Sign in</a></h2>\r\n            </td>";
    protected void Page_Load(object sender, EventArgs e)
    {
        user = (string)Session["userName"];
        if (user != "guest") {
            string fileName = "Database.mdf";
            string sql = "select profilePic from Tbl where UserName = '" + Session["userName"] + "';";
            DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
            if (table.Rows.Count == 1) {
                userPic = (string)table.Rows[0]["profilePic"];
            }
            linkLog = "\r\n            <td>\r\n                <h2 style=\"margin-block-start: 0.5em;margin-block-end: 0.5em;\"><a class=\"pageLink\" href=\"feed.aspx\">Questions</a></h2>\r\n            </td>";
            user = "<a class='pageLink' href='profile.aspx'>" + (string)Session["userName"] + "</a>";
        }
        if ((string)Session["admin"] == "True")
            managerPage= "\r\n            <td>\r\n                <h2 style=\"margin-block-start: 0.5em;margin-block-end: 0.5em;\"><a class=\"pageLink\" href=\"ManagerPage.aspx\">Manger page</a></h2>\r\n            </td>";
            
    }
}//Session["userPic"] = "<img style=\"height: 168px;width:auto;\" src = '../images/defualtPic.png' />";
