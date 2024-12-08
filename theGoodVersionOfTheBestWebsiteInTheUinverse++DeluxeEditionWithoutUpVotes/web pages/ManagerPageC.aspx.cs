using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_ManagerPageQ : System.Web.UI.Page {
    public string commentList = "";
    public string commentCount = "0";
    protected void Page_Load(object sender, EventArgs e) {
        string fileName = "Database.mdf";
        string sql = "select * from TblC;";
        string id = Request.QueryString["id"];
        DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        int length = table.Rows.Count;
        if (id != "" && id!=null) {
            string sql2 = "select * from TblC where ToId = '"+ id + "';";
            DataTable table2 = MyAdoHelper.ExecuteDataTable(fileName, sql2);
            int length2 = table2.Rows.Count;
            if (length2 > 0) {
                commentList += "<table style='width: 2500px;' class='manage' >";
                commentList += "<tr>";

                commentList += "<th class='manage'>ID</th>";
                commentList += "<th class='manage'>ToId</th>";
                commentList += "<th class='manage'>Maker</th>";
                commentList += "<th style='width:900px;' class='manage'>title</th>";
                commentList += "<th style='width:900px;' class='manage'>description</th>";
                commentList += "<th class='manage'>Comments</th>";

                commentList += "</tr>";

                for (int i = 0; i < length2; i++) {

                    commentList += "<tr>";

                    commentList += "<td style='height: 178px;' class='manage'>" + table2.Rows[i]["Id"] + "</td>";
                    commentList += "<td style='height: 178px;' class='manage'>" + table2.Rows[i]["ToId"] + "</td>";
                    commentList += "<td style='height: 178px;' class='manage tablemaker'>" + table2.Rows[i]["maker"] + "</td>";
                    commentList += "<td class='manage TableQuestion'>" + table2.Rows[i]["title"] + "</td>";
                    commentList += "<td style='width:900px;' class='manage TableDsecription'>" + table2.Rows[i]["description"] + "</td>";
                    commentList += "<td class='manage'><button onclick=\"relocate(" + table.Rows[i]["Id"] + ")\" style=\"margin-right: 50px;width:150px;font-size:50px;\" role=\"button\" class=\"mangerpageButoons\" type=\"button\">click <br /> me</button></td>";
                    commentList += "</tr>";

                }
                commentList += "</table>";
                commentCount = length.ToString();
            }
        } else {
            if (length > 0) {
                commentList += "<table style='width: 2500px;' class='manage' >";
                commentList += "<tr>";

                commentList += "<th class='manage'>ID</th>";
                commentList += "<th class='manage'>ToId</th>";
                commentList += "<th class='manage'>Maker</th>";
                commentList += "<th style='width:900px;' class='manage'>title</th>";
                commentList += "<th style='width:900px;' class='manage'>description</th>";
                commentList += "<th class='manage'>Comments</th>";

                commentList += "</tr>";

                for (int i = 0; i < length; i++) {

                    commentList += "<tr>";

                    commentList += "<td style='height: 178px;' class='manage'>" + table.Rows[i]["Id"] + "</td>";
                    commentList += "<td style='height: 178px;' class='manage'>" + table.Rows[i]["ToId"] + "</td>";
                    commentList += "<td style='height: 178px;' class='manage tablemaker'>" + table.Rows[i]["maker"] + "</td>";
                    commentList += "<td class='manage TableQuestion'>" + table.Rows[i]["title"] + "</td>";
                    commentList += "<td style='width:900px;' class='manage TableDsecription'>" + table.Rows[i]["description"] + "</td>";
                    commentList += "<td class='manage'><button onclick=\"relocate(" + table.Rows[i]["Id"] + ")\" style=\"margin-right: 50px;width:150px;font-size:50px;\" role=\"button\" class=\"mangerpageButoons\" type=\"button\">click <br /> me</button></td>";
                    commentList += "</tr>";

                }
                commentList += "</table>";
                commentCount = length.ToString();
            }
        }
        if (Request.Form["submitDelete"] != null)
        {
            string sql2 = "DELETE FROM TblC WHERE Id = '" + Request.Form["delete"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql2);
        }
        if (Request.Form["submitBan"] != null) {
            string sql2 = "DELETE FROM Tbl WHERE UserName = '" + Request.Form["ban"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql2);
        }
        if (Request.Form["submitMessage"] != null) {
            Application["msg"] = Request.Form["message"];
        }
        if (Request.Form["submitChange"] != null) {
            string sql3 = "UPDATE TblC SET " + Request.Form["columns"] + "='" + Request.Form["value"] + "'WHERE Id ='" + Request.Form["IDNumber"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql3);
        }
    }
}