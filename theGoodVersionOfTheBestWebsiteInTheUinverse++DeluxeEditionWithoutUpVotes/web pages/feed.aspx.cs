using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_pages_Default : System.Web.UI.Page
{
    public string questionList = "";
    public int questionCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        string fileName = "Database.mdf";
        string sql = "select * from TblQ;";
        DataTable table = MyAdoHelper.ExecuteDataTable(fileName, sql);
        int length = table.Rows.Count;

        if (length > 0) {
            for (int h = 0; h < length; h++) {
                for (int i = 0; i < length; i++) {
                    questionList += "<tr style=\"height:300px;border:solid;\">\r\n                <td onclick=\"relocate2(" + table.Rows[i]["IDNumber"] + ")\" style=\"cursor: pointer;border:solid;width:1300px;\">\r\n                    <h1 style=\"width:1200px;font-size:65px;margin-block-start:0;margin-block-end:20px;overflow-wrap: break-word;\">" + table.Rows[i]["question"] + "</h1>\r\n                    <h1 class=\"description\" style=\"\" >" + table.Rows[i]["description"] + "</h1>\r\n                </td>\r\n                <td style=\"font-size:50px;border:solid;position: relative;\">\r\n                    <h6 class=\"tags\">" + table.Rows[i]["tags"] + "</h6><br />\r\n                </td>\r\n            </tr>";
                }
            }
            questionCount = length;

        }
    }
}