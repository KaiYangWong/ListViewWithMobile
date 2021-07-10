<%@ Page Title="產品資料" Language="C#" MasterPageFile="~/SiteMobile.Master" AutoEventWireup="true" CodeBehind="mobileProducts.aspx.cs" Inherits="prjListView.mobileProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div data-role="content">
        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
               <ul data-role="listview" data-inset="true">
                    <li runat="server" id="itemPlaceholder"></li>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <img src='Images/<%# Eval("圖示") %>' />
                    <h2>
                        <%# Eval("品名") %>
                    </h2>
                    <p>
                        單價：<%# Eval("單價") %>
                    </p>
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                無此項類別產品
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>
