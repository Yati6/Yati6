using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class web_pages_Default : System.Web.UI.Page {
    public string question;
    public string description;
    public string tags;
    public int upVotes;
    public string maker;
    public string commentSection = "";
    public string id;
    public string QUESTION;
    protected void Page_Load(object sender, EventArgs e) {
        string id = Request.QueryString["id"];
        string fileName = "Database.mdf";
        string sql5 = "select * from TblC ORDER BY Id desc;";
        DataTable table5 = MyAdoHelper.ExecuteDataTable(fileName, sql5);
        int length5 = table5.Rows.Count;
        string sql = "select * from TblQ where IDNumber = " + id + ";";
        DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        int length = table.Rows.Count;
        if (length > 1) {
            //if eror
            Response.Redirect("feed.aspx");
        } else {
            question = (string)table.Rows[0]["question"];
            description = (string)table.Rows[0]["description"];
            tags = (string)table.Rows[0]["tags"];
            maker = (string)table.Rows[0]["maker"];
        }
        string sql2 = "select * from TblC where ToId = " + id + " ORDER BY Id desc;";
        DataTable table2 = MyAdoHelper.ExecuteDataTable(fileName, sql2);
        int length2 = table2.Rows.Count;
        QUESTION = "<div style=\"margin-bottom:60px;\" id=\""+id+"\">\r\n        <h1 style=\"text-align:center;width:1300px;font-size:100px;\">"+question+"</h1>\r\n        <h1 style=\"font-size:50px;margin-block-end: 0;\">by "+maker+"</h1>\r\n        <p style=\"width:1300px;margin-block-start: 0.5em;\">"+description+"</p>\r\n        ";
        if (length2 > 0) {
            for (int i = 0; i < length2; i++) {
                if ((string)table2.Rows[i]["description"] != "") {
                    commentSection += "<div style=\"margin-bottom:60px;\" id='" + table2.Rows[i]["Id"] + "'><h1 style='font-size:75px;margin-block-end: 0;margin-block-start: 0.4em;'>" + (string)table2.Rows[i]["title"] + "</h1><h1 style='font-size:53px;margin-block-start: 0.2em;margin-block-end: 0.2em;'> by " + (string)table2.Rows[i]["maker"] + "</h1>";
                    commentSection += "<p style=\"width:1300px;margin-block-start: 0.2em;\">";
                    commentSection += (string)table2.Rows[i]["description"] + "</p>";
                    string sql4 = "select * from TblC where ToId = " + table2.Rows[i]["Id"] + " ORDER BY Id desc;";
                    DataTable table4 = MyAdoHelper.ExecuteDataTable(fileName, sql4);
                    int length4 = table4.Rows.Count;
                    for (int j = 0; j < length4; j++) {
                        commentSection += "<div style='border-top-color: gray;width:1240px;margin-left:60px;margin-bottom: 20px;margin-top: 20px;' class='topBorder'><h1 style=\"margin-block-start: 0.4em;font-size:40px;margin-block-end: 0;\">by " + table4.Rows[j]["maker"] + "</h1><p style=\"width:1240px;margin-block-start: 0.3em;margin-block-end: 0.5em;\">" + (string)table4.Rows[j]["title"] + "</p></div>";
                    }
                    commentSection += "<div style='width:1300px;text-align:center;margin-top:0;'><button class='button-19' onclick=\"commentPopup(" + table2.Rows[i]["Id"] + ")\" style=\"width:400px;font-size:50px;margin-top:20px;\">comment</button></div>";
                    commentSection += "</div>";
                } else {
                    QUESTION += "<div style='border-top-color: gray;width:1240px;margin-left:60px;margin-bottom: 20px;margin-top: 20px;' class='topBorder'><h1 style=\"margin-block-start: 0.4em;font-size:40px;margin-block-end: 0;\">by " + table2.Rows[i]["maker"] + "</h1><p style=\"width:1240px;margin-block-start: 0.3em;margin-block-end: 0.5em;\">" + (string)table2.Rows[i]["title"] + "</p></div>";
                }
            }
        }
        QUESTION += "<div style='width:1300px;text-align:center;margin-top:0;'><button class='button-19' onclick=\"answerPopup()\" style=\"margin-right: 20px;margin-top:20px;width:400px;font-size:50px;\">answer</button>\r\n        <button class='button-19' onclick=\"commentPopup(" + id+ ")\" style=\"margin-left: 20px;margin-top:20px;width:400px;font-size:50px;\">comment</button>\r\n       </div> </div>";

        if (Request.Form["submitA"] != null) {
            string sql3 = "INSERT INTO TblC(Id,title,description,maker,ToId) VALUES(" + ((int)table5.Rows[length5 - 1]["Id"] - 1) + ",'" + Request.Form["title"] + "','" + Request.Form["description"] + "','" + Session["userName"] + "'," + id + ")";
            DataTable table3 = MyAdoHelper.ExecuteDataTable(fileName, sql3);
        }
        if (Request.Form["submitC"] != null) {
            int where = Int32.Parse(Request.Form["where"]);
            string sql3 = "INSERT INTO TblC(Id,title,description,maker,ToId) VALUES(" + ((int)table5.Rows[length5 - 1]["Id"] - 1) + ",'" + Request.Form["comment"] + "','','" + Session["userName"]+ "'," + where + ")";
            DataTable table3 = MyAdoHelper.ExecuteDataTable(fileName, sql3);
        }
    }
}