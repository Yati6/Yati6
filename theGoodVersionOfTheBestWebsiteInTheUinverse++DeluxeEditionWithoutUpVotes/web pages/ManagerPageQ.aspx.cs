using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_ManagerPageQ : System.Web.UI.Page {
    public string questionList = "";
    public string questionCount;
    protected void Page_Load(object sender, EventArgs e) {
        string fileName = "Database.mdf";
        string sql = "select * from TblQ;";
        DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        int length = table.Rows.Count;

        if (length > 0) {
            questionList += "<table style='width: 2500px;' class='manage' >";
            questionList += "<tr>";

            questionList += "<th class='manage'>ID</th>";
            questionList += "<th class='manage'>Maker</th>";
            questionList += "<th style='width: 500px;' class='manage'>Question</th>";
            questionList += "<th class='manage'>Description</th>";
            questionList += "<th class='manage'>Tags</th>";
            questionList += "<th class='manage'>Comments</th>";

            questionList += "</tr>";

            for (int i = 0; i < length; i++) {

                questionList += "<tr>";

                questionList += "<td style='height: 178px;' class='manage'>" + table.Rows[i]["IDNumber"] + "</td>";
                questionList += "<td style='height: 178px;' class='manage tablemaker'>" + table.Rows[i]["maker"] + "</td>";
                questionList += "<td class='manage TableQuestion'>" + table.Rows[i]["question"] + "</td>";
                questionList += "<td class='manage TableDsecription'>" + table.Rows[i]["description"] + "</td>";
                questionList += "<td class='manage tableTags'>" + table.Rows[i]["tags"] + "</td>";
                questionList += "<td class='manage'><button onclick=\"relocate("+ table.Rows[i]["IDNumber"] + ")\" style=\"margin-right: 50px;width:150px;font-size:50px;\" role=\"button\" class=\"mangerpageButoons\" type=\"button\">click <br /> me</button></td>";

                questionList += "</tr>";

            }
            questionList += "</table>";
            questionCount = length.ToString();

        }
        if (Request.Form["submitDelete"] != null)
        {
            int id = length - 1;
            string sql2 = "DELETE FROM TblQ WHERE IDNumber = '" + Request.Form["delete"] + "';";
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
            string sql3 = "UPDATE TblQ SET " + Request.Form["columns"] + "='" + Request.Form["value"] + "'WHERE IDNumber ='" + Request.Form["IDNumber"] + "';";
            table = MyAdoHelper.ExecuteDataTable(fileName, sql3);
        }
    }
}