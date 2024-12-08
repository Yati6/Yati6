<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="TheWebsite_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Sign in</title>
    <script>
        function check() {
            if (document.getElementById().value.includes("=")) {
                document.getElementById("warning").innerHTML = "userName or password is incorrect";
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="BigTitle" style="margin-block-start:43px;margin-block-end:43px">
        Sign in
    </h1>
    <form style="background-color:aliceblue;border-radius: 25px;" class="SignIn" method="post" onsubmit="return check()" action="">
        <p id="warning" name="warning" style="color:red;margin:0;width:700px;">
            <%=msg %>
        </p>
        <h1 style="margin-block-end:20px;margin-block-start:0;" >username:</h1>
        <input style="border-radius: 25px; width:400px;height:70px;font-size:40px;" placeholder="username" type="text" name="userName" id="userName" /><br />
        <h1 style="margin-block-end:20px;margin-block-start:30px;">password:</h1>
        <input style="margin-bottom:40px;border-radius: 25px;width:400px;height:70px;font-size:40px;" placeholder="password" type="password" name="password" id="password" />
        <br />
        <input style="margin-bottom:40px;width:200px;height:50px;font-size:30px;background-color:darkgreen;" type="submit" name="submit" id="submit" />
    </form>
    <div style="width: 700px;font-size:100px;text-align:center;margin:auto;margin-top:20px;">
        <p style="width:auto;margin:0;margin-block-start: 0;margin-block-end: 0;">
            don't have an account?
        </p>
        <a class="pageLink" href="../web%20pages/SignUp.aspx">
            <h3 style="margin-block-start:0;margin-block-end:10px;color:yellow;">Sign Up</h3>
        </a>
    </div>
</asp:Content>

