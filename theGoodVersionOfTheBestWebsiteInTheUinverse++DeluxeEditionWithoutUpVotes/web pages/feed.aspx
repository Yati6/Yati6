<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="feed.aspx.cs" Inherits="web_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        questions
    </title>
    <script>
        function relocate() {
            window.location.href = "questionCreator.aspx";
        }
        function relocate2(value) {
            location.href = 'opendQuestion.aspx?id=' + value;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <button onclick="relocate()" type="button" id="create" name="create" style="position:absolute;margin:50px;background-color: mintcream;border: solid;text-align: center;display: inline-block;color:black; font-size: 75px; border-radius: 50%; width: 100px; height: 100px;">+</button><br />
    <h1 style="position:absolute; margin-top:50px;margin-left:160px;font-size:50px;">← make a question</h1>
    <h1 class="BigTitle">Questions</h1>
    <div style="margin:auto;background-color:azure;width:1500px;" name="content" id="content">
        <table border="1" style="border:solid;">
            <%=questionList %>
        </table>
    </div>
</asp:Content>

