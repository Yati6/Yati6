<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profilePic.aspx.cs" Inherits="web_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Profile picture</title>
    <script>
        function check() {
            if (document.getElementById("picUrl").value.length > 1000) {
                document.getElementById("warning").innerHTML = "the url is to long (max length is 1,000 characters)"
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br /><br />
    <div style="margin:auto;width:50%;margin-bottom:369px;">
        <form method="post" onsubmit="return check()" action="" style="background-color:aliceblue;border-radius: 25px;text-align: center;font-size: 50px;">
            <br />
            <h1 style="margin-block-end:10px;">change profile picture</h1>
            <w id="warning" style="color:red;font-size:40px;"></w><br />
            <label for="picUrl">Enter desierd profile picture URL</label><br />
            <input placeholder="https://images..." style="margin-bottom:20px;width:1000px;font-size:40px;height:auto" type="text" name="picUrl" id="picUrl" /><br />
            <input type="submit" name="submit" id="submit" class="resetAndSumbit" style="margin-bottom:20px;background-color:greenyellow;" />
        </form>
    </div>
</asp:Content>

