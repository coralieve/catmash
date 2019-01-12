<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormCatGame.aspx.cs" Inherits="catmashlive.WebFormCatGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <tr>
                                <td>&nbsp;</td>
                            </tr>
    <div class="row"  style="text-align:center">
        <div class="col-md-6 parent" style="vertical-align:middle">
            <asp:ImageButton runat="server" ID="btnLeftCat" CssClass="parent img" OnClick="leftCat_Click" width="400" ImageAlign="Middle" style="border: solid"/>

        </div>
        <div class="col-md-6 parent" style="vertical-align:middle">

            <asp:ImageButton runat="server" id="btnRightCat" CssClass="parent img" OnClick="rightCat_Click" width="400" ImageAlign="Middle" style="border: solid"/>
        </div>
    </div>
    <div class="row"  style="text-align:center">
   
            <asp:Button runat="server" Text="Aucun" id="nextCats" OnClick="nextCats_Click" />
       
    </div>
</asp:Content>
