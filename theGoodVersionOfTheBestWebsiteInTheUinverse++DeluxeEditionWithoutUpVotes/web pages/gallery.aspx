<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
    gallery
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="margin:20px;font-size:100px;text-align:center;">
        Join us because we programmers help each other
    </h1>
    <div>
        <img class="pictureInGallery" src="../images/helping.jpeg" />
        <img class="pictureInGallery" src="../images/helping2.jpeg" />
        <img class="pictureInGallery" src="../images/helping3.jpg" />
    </div>
    <h1 style="margin:20px;font-size:100px;text-align:center;">
        Any one can choose to be a programmer!
    </h1>
    <div>
        <img class="pictureInGallery" src="../images/childProgrammer.png" />
        <img class="pictureInGallery" src="../images/teenagerProgrammer.png" />
        <img class="pictureInGallery" src="../images/oldProgrammer.png" />
    </div>
</asp:Content>

