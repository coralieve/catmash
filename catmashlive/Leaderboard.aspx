<%@ Page Title="Leaderboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="catmashlive.Leaderboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Classement</h2>
   <asp:Repeater runat="server" ID="allCats" DataMember="Cat" OnItemDataBound="allCats_ItemDataBound">
       <HeaderTemplate>
           <div><ul>
       </HeaderTemplate>
       <ItemTemplate>
          <li class="liRpt">
             <strong>&nbsp; <%# Container.ItemIndex + 1 %>&nbsp;</strong>
              <asp:Image runat="server" Width="70px" ID="imgCat" />
         </li>  
       </ItemTemplate>
       <FooterTemplate>
           </ul></div>
       </FooterTemplate>
   </asp:Repeater>
</asp:Content>
