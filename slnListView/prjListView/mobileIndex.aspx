<%@ Page Title="產品分類" Language="C#" MasterPageFile="~/SiteMobile.Master" AutoEventWireup="true" CodeBehind="mobileIndex.aspx.cs" Inherits="prjListView.mobileIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div data-role="content">
    <div style="text-align:center;">
        <img src="images/banner.jpg" style="max-width:95%;" />
        <p>最優質的雲端應用程式課程</p>
    </div>

    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <ul  data-role="listview" data-inset="true" >
                <li id="itemPlaceholder" runat="server"></li>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <a href='mobileProducts.aspx?cid=<%# Eval("類別編號") %>' data-ajax="false">
                    <%# Eval("類別名稱") %>
                    <span class="ui-li-count"><%# Eval("數量") %></span>
                </a>
            </li>
        </ItemTemplate>
    </asp:ListView>
</div>


</asp:Content>
