<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="web_pages_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>profile</title>
    <script>
        function check() {
            var columns = document.getElementById("columns").value;
            var newValue = document.getElementById("value").value;
            var warning = document.getElementById("warning");
            if (newValue == "") {
                warning.innerHTML = "Please fill the required fields";
                warning.style.display = "block";
                return false;
            } else if (newValue.length < 4 && columns == "password") {
                warning.innerHTML = "The password is too short";
                warning.style.display = "block";
                return false;
            } else if (newValue.includes("=")) {
                warning.innerHTML = "Password and username can't have " + '"="';
                warning.style.display = "block";
                return false;
            } else if ((newValue.includes("'") || newValue.includes('"')) && columns == "UserName") {
                warning.innerHTML = 'username cant have " or ' + "'";
                warning.style.display = "block";
                return false;
            } else {
                warning.style.display = "none";
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center;">
        <%=userPic %>
        <h1 style="font-size:150px;margin-block-start: 0.1em;margin-block-end: 0.1em;"><%= Session["userName"] %></h1>
    </div>
    <form style="margin-left:1000px;" method="post" onsubmit="return check()" action="">
        <w style="font-size:40px;color:red;" id="warning"><br /><%=msg %></w>
        <h1 style="margin-block-start: 0.2em;font-size:60px;">update information:</h1>
        <label style="font-size:50px" for="columns">value type:</label>
        <select name="columns" id="columns" style="height:40px; width:300px; font-size:30px;">
            <option value="password">password</option>
            <option value="UserName">username</option>
            <option value="name">name</option>
        </select><br />
        <label style="font-size:50px" for="value">new value:</label>
        <input type="text" id="value" name="value" style="margin-bottom:50px;height:40px; width:300px; font-size:30px;" /><br />
        <input class="resetAndSumbit" style="margin-left:40px;margin-right:40px;background-color:red;" type="reset" />
        <input class="resetAndSumbit" style="margin-bottom:30px;background-color:greenyellow;" type="submit" name="submitChange" id="submitChange" /><br />
        </form>
        <form method="post" action="" style="text-align:center;width:100%;">
            <input type="submit" id="signOut" name="signOut" onclick="" class="resetAndSumbit" style="background-color: red;" value="Sign out">
        </form>
</asp:Content>

