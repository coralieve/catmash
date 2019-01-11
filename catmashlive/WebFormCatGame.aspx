<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormCatGame.aspx.cs" Inherits="catmashlive.WebFormCatGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 parent">
            <asp:ImageButton runat="server" ID="btnLeftCat" CssClass="parent img" OnClick="leftCat_Click" />

        </div>
        <div class="col-md-6 parent">

            <asp:ImageButton runat="server" id="btnRightCat" CssClass="parent img" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button runat="server" Text="Aucun" id="nextCats" OnClick="nextCats_Click" />
        </div>
    </div>
</asp:Content>
