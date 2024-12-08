<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="questionCreator.aspx.cs" Inherits="web_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>question creator</title>
    <script>
        function check() {
            if (document.getElementById("question").value.length == 0) {
                document.getElementById("questionWarning").innerHTML = "there is no question";
                return false;
            } else {
                document.getElementById("questionWarning").innerHTML = "";
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="text-align:center;font-size:100px;">What is you'r question?</h1><br /><br />
    <form style="width: 1000px;margin: auto;" onsubmit="return check()"  method="post" action="">
        <label style="font-size:75px;" for="question" >question: <h id="questionWarning" name="questionWarning" style="font-size:65px;color:red;"><h></label><br />
        <textarea style="resize: vertical;min-height:150px;font-size:50px;height:150px;width:1000px;" maxlength="60" type="text" name="question" id="question" placeholder="Write your question or the title for your question here"></textarea>

        <label style="font-size:75px;" for="description" >description:</label><br />
        <textarea style="resize: vertical;min-height:400px;font-size:35px;height:400px;width:1000px;" maxlength="10000" type="text" name="description" id="description" placeholder="Write the description and Extend on the question here. you can put the code that you have the problem/question with/about here."></textarea>
   
        <label style="font-size:70px;" for="tags">Add tags:</label></label><br />
        <textarea style="resize: vertical;min-height:100px;font-size:40px;height:100px;width:1000px;" maxlength="90" type="text" name="tags" id="tags" placeholder="Write tags here, put an # before each tag like this #Java #gameDevlopment"></textarea>
        <br />
        <input type="submit" id="submit" name="submit" class="resetAndSumbit" style="background-color:greenyellow;margin-left:300px;" />
        <input class="resetAndSumbit" style="background-color: red;" type="reset" id="reset" name="reset" />
    </form>
</asp:Content>

