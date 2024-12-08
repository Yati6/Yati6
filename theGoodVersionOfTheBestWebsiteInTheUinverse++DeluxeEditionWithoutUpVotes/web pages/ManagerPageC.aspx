<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerPageC.aspx.cs" Inherits="web_pages_ManagerPageQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        manger page
    </title>
    <script>
        function relocate(where) {
            if (where == 'u') {
                window.location.href = "ManagerPage.aspx";
            } else if (where == 'q') {
                window.location.href = "ManagerPageQ.aspx";
            } else if (where == 'c') {
                window.location.href = "ManagerPageC.aspx";
            } else {
                window.location.href = "ManagerPageC.aspx?id=" + where;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="margin-bottom:50px;" class="BigTitle">
    manger page
    </h1><br />
    <div style="text-align:center;">
        <button style="margin-right: 50px;" role="button" class="mangerpageButoons" type="button" onclick="relocate('u')">Users</button>
        <button style="width:400px;margin-right: 50px;" role="button" class="mangerpageButoons" type="button" onclick="relocate('q')">Questions</button>
        <button style="width:450px;" role="button" class="mangerpageButoons" type="button" onclick="relocate('c')">Comments</button>
    </div>
    <h1 style="font-size:100px;">Comments/Answers: (<%=commentCount %>)</h1>
    <h1>
        <%=commentList %>
    </h1>
    <form method="post" action="">
        
        <h1 style="font-size:100px">delete comment:</h1>
        <label style="font-size:75px;" for="delete">comment's ID:</label><br />
        <input type="text" name="delete" id="delete" style="height:80px; width:400px; font-size:50px;" />
        <input class="resetAndSumbit" style="height:86px;background-color:greenyellow;" type="submit" name="submitDelete" id="submitDelete" />

        <h1 style="font-size:100px">ban user</h1>
        <label style="font-size:75px;" for="ban">user's username:</label><br />
        <input type="text" name="ban" id="ban" style="height:80px; width:400px; font-size:50px;" />
        <input class="resetAndSumbit" style="height:86px;background-color:greenyellow;" type="submit" name="submitBan" id="submitBan" />
        
        <h1 style="font-size:100px">change value</h1>
        <label style="font-size:50px" for="username">ID:</label>
        <input type="text" id="IDNumber" name="IDNumber" style="height:40px; width:300px; font-size:30px;" /><br />
        <label style="font-size:50px" for="columns">value type:</label>
        <select name="columns" id="columns" style="height:40px; width:300px; font-size:30px;">
            <option value="title">title</option>
            <option value="description">description</option>
            <option value="maker">maker</option>
            <option value="ToId">ToId</option>
        </select><br />
        <label style="font-size:50px" for="value">new value:</label>
        <input type="text" id="value" name="value" style="height:40px; width:300px; font-size:30px;" /><br />
        <input class="resetAndSumbit" style="background-color:greenyellow;" type="submit" name="submitChange" id="submitChange" />
        <h1>You can't change question's IDNumber</h1>

        <h1 style="font-size:100px">Message</h1>
        <input type="text" name="message" id="message" style="height:80px; width:400px; font-size: 1.5em;" />
        <input class="resetAndSumbit" style="background-color:greenyellow;" type="submit" name="submitMessage" id="submitMessage" />
    </form>
    <h1>*change in the data base isn't shown instantly you may need to refresh the page to see it (you can press the "users" butoon to refresh)</h1>
</asp:Content>

