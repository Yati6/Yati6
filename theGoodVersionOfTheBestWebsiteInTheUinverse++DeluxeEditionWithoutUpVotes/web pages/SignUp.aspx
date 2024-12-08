<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Sign up</title>
    <script>
        function check(){
            var password = document.getElementById("password").value;
            var username = document.getElementById("userName").value;
            document.getElementById("warning").innerHTML = "";
            if (password == "" || username == "" || document.getElementById("fullName").value == "" || document.getElementById("age").value == "") {
                document.getElementById("warning").innerHTML = "Please fill the required fields";
                return false;
            } else if (password.length < 4) {
                document.getElementById("warning").innerHTML = "The password is too short";
                return false;
            } else if (password.includes("=") || username.includes("=")) {
                document.getElementById("warning").innerHTML = "Password and username can't have "+'"="';
                return false;
            } else if (username.includes("'") || username.includes('"')) {
                document.getElementById("warning").innerHTML = 'username cant have " or ' + "'";
                return false;
            }else {
                document.getElementById("warning").innerHTML = "";
            }
            return true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="text-align:center; font-size: 100px;margin-top:34px;margin-bottom:4px;">
        Sign up
    </h1>
    <form class="SignIn" method="post" onsubmit="return check()" action="" >
        <w id="warning" style="color:red;font-size:40px;"><%=msg %></w><br />
        <label for="userName">username</label>
        <input maxlength="15" type="text" name="userName" id="userName" /><br />
        <label for="password">Password</label>
        <input maxlength="100" style="margin-top:8px" type="password" name="password" id="password" /><br />

        <label for="fullName">full name</label>
        <input maxlength="50" style="margin-top:8px" type="text" name="fullName" id="fullName" /><br />

        <div1>
            <label style="margin-top: 50px;" for="gender">gender:</label><br />
            <input style="margin-top: 30px;" type="radio" id="gender" name="gender" value="M" />Male<br />
            <input type="radio" id="gender" name="gender" value="F" />Female<br />
            <input type="radio" id="gender" name="gender" value="O" />Other<br />
        </div1><br />

        <label for="age">age</label>
        <input style="font-size:20px;" type="number" name="age" id="age" min="3" max="120" />
        <br /><br /><br />


        <div2>
            <label for="codeLanguages">code languages you know/learn:</label><br />
            <input type="checkbox" id="codeLanguages" name="codeLanguages" value="java" />java
            <input style="margin-left:57px;" type="checkbox" id="codeLanguages" name="codeLanguages" value="AssemblyLanguage" />Assembly language<br />
            <input type="checkbox" id="codeLanguages" name="codeLanguages" value="python" />python
            <input type="checkbox" id="codeLanguages" name="codeLanguages" value="C" />C<br />
            <input type="checkbox" id="codeLanguages" name="codeLanguages" value="C#" />c#
            <input style="margin-left:95px;" type="checkbox" id="codeLanguages" name="codeLanguages" value="VisualBasic" />VisualBasic.Net<br />
            <input type="checkbox" id="codeLanguages" name="codeLanguages" value="C++" />c++
            <input style="margin-left:64px;" type="checkbox" id="codeLanguages" name="codeLanguages" value="JavaScript" />JavaScript<br />
        </div2><br /><br <br /><br /><br /><br /><br />

        <input class="resetAndSumbit" style="background-color: red;" type="reset" id="reset" name="reset" />
        <input class="resetAndSumbit" style="background-color:greenyellow;" type="submit" id="submit" name="submit" />

    </form>
</asp:Content>

