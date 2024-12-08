<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="opendQuestion.aspx.cs" Inherits="web_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        <%=question%>
    </title>
    <script>
        function checkC() {
            document.getElementById('NotextC').style.display = 'none';
            document.getElementById('incluedsC').style.display = 'none';
            if (document.getElementById('comment').value.length < 1) {
                document.getElementById('NotextC').style.display = 'block';
                return false;
            } else if (document.getElementById('comment').value.includes("'")) {
                document.getElementById('incluedsC').style.display = 'block';
                return false;
            }
            return true;
        }
        function checkA() {
            document.getElementById('NotextA').style.display = 'none';
            document.getElementById('incluedsA').style.display = 'none';
            if (document.getElementById('title').value.length < 1) {
                document.getElementById('NotextA').style.display = 'block';
                return false;
            } else if (document.getElementById('title').value.includes("'") || document.getElementById('description').value.includes("'")) {
                document.getElementById('incluedsA').style.display = 'block';
                return false;
            }
            return true;
        }
        var is = false;
        function removeAnswerPopup() {
            document.getElementById('formA').style.display = 'none';
        }
        function answerPopup() {
            document.getElementById('formA').style.display = 'block';
            document.getElementById('formC').style.display = 'none';
        }
        function removeCommentPopup() {
            document.getElementById('formC').style.display = 'none';
        }
        function commentPopup(where) {
            document.getElementById(where).appendChild(document.getElementById('formC'));
            document.getElementById('formA').style.display = 'none';
            document.getElementById('formC').style.display = 'block';
            document.getElementById('where').value = where;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div style="margin:auto;width:1300px;overflow-wrap: break-word;">
        <%=QUESTION %>
        <form onsubmit="return checkA()" method="post" action="" style="display:none; text-align:center;width:1300px;" id="formA">
            <h1 style="display:none;color:red;font-size:40px;" id="NotextA" color="red">there is no text</h1>
            <h1 style="display:none;color:red;font-size:40px;" id="incluedsA" color="red">cant have ' in the text</h1>
            <h1 style="font-size:75px;">
                title:
            </h1>
            <textarea id="title" name="title" style="resize: vertical;min-height:130px;width:1300px;height:130px;font-size:55px;" maxlength="70" placeholder="write the title of the answer here:"></textarea>
            
            <h1 style="font-size:75px;">
                description
            </h1>
            <textarea id="description" name="description" style="margin-bottom:50px;resize: vertical;min-height:200px;width:1300px;height:330px;font-size:38px;" maxlength="3000" placeholder="If you need write the description of the answer here:"></textarea>
            
            <button onclick="removeAnswerPopup()" class="resetAndSumbit" style="width:300px;height:120px;font-size:60px;margin-right: 50px;background-color: red;" type="button" id="cancelA" name="cancelA">cancel</button>
            <input class="resetAndSumbit" style="width:300px;height:120px;font-size:60px;margin-left: 50px;background-color:greenyellow;" type="submit" id="submitA" name="submitA" />
        </form>
        <form method="post" onsubmit="return checkC()" action="" style="display:none; text-align:center;width:1300px;" id="formC">
            <h1 style="display:none;color:red;font-size:40px;" id="NotextC" color="red">there is no text</h1>
            <h1 style="display:none;color:red;font-size:40px;" id="incluedsC" color="red">cant have ' in the text</h1>
            <input type="hidden" value="" id="where" name="where" />
            <h1 style="font-size:65px;">
                comment:
            </h1>
            <textarea name="comment" id="comment" style="resize: vertical;margin-bottom:40px;min-height:130px;width:1300px;height:137px;font-size:35px;" maxlength="200" placeholder="write your comment here:"></textarea>
            
            <button onclick="removeCommentPopup()" class="resetAndSumbit" style="width:300px;height:120px;font-size:60px;margin-right: 50px;background-color: red;" type="button" id="cancelC" name="cancelC">cancel</button>
            <input class="resetAndSumbit" style="width:300px;height:120px;font-size:60px;margin-left: 50px;background-color:greenyellow;" type="submit" id="submitC" name="submitC" />
        </form>
        <%=commentSection %>
    </div>
</asp:Content>