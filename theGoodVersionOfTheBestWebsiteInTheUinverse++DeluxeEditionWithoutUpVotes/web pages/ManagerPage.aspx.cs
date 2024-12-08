using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string userList = "";
    public string usersCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        string fileName = "Database.mdf";
        string sql = "select * from Tbl;";
        DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        int length = table.Rows.Count;

        if (length > 0)
        {
            userList += "<table style='width: 2500px;' class='manage' >";
            userList += "<tr>";

            userList += "<th class='manage'>profile picture</th>";
            userList += "<th class='manage'>UserName</th>";
            userList += "<th class='manage passwordAndName'>password</th>";
            userList += "<th class='manage passwordAndName'>name</th>";
            userList += "<th class='manage'>age</th>";
            userList += "<th class='manage'>gender</th>";
            userList += "<th class='manage'>Manger</th>";

            userList += "</tr>";

            for (int i = 0; i < length; i++)
            {
                userList += "<tr>";

                userList += "<td class='manage'>" + table.Rows[i]["profilePic"] + "</td>";
                userList += "<td class='manage'>" + table.Rows[i]["UserName"] + "</td>";
                userList += "<td class='manage passwordAndName'>" + table.Rows[i]["password"] + "</td>";
                userList += "<td class='manage passwordAndName'>" + table.Rows[i]["name"] + "</td>";
                userList += "<td class='manage'>" + table.Rows[i]["age"] + "</td>";
                userList += "<td class='manage'>" + table.Rows[i]["gender"] + "</td>";
                userList += "<td class='manage'>" + table.Rows[i]["Manger"] + "</td>";

                userList += "</tr>";

            }
            userList += "</table>";
            usersCount = length.ToString();

        }
        if (Request.Form["submitBan"] != null) {
            string sql2 = "DELETE FROM Tbl WHERE UserName = '" + Request.Form["ban"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql2);
        }
        if (Request.Form["submitMessage"] != null)
        {
            Application["msg"] = Request.Form["message"];
        }
        if (Request.Form["submitChange"] != null)
        {
            string sql3 = "UPDATE Tbl SET " + Request.Form["columns"] + "='"+ Request.Form["value"] +"'WHERE UserName ='" + Request.Form["username"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql3);
        }
    }
}