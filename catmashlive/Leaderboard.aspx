<%@ Page Title="Leaderboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="catmashlive.Leaderboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Classement</h2>
   <asp:ListView runat="server" ID="cats" ItemType="catmashlive.Cat" SelectMethod="GetRankedCats"  GroupItemCount="5">

       <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                   <a href="<%#:Item.url%>">
                                        <img src="<%#:Item.url%>"
                                            width="100"  style="border: solid" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                        <span>
                                            <center><%# ((ListViewDataItem)Container).DataItemIndex+1 %></center>
                                        </span>
                                    </a>
                                    <br />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
   </asp:ListView>
</asp:Content>
