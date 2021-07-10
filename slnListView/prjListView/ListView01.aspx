<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListView01.aspx.cs" Inherits="prjListView.ListView01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-12 col-md-4">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
        <ItemTemplate>
            <div class="col-12 col-md-4">
                <div class="img-thumbnail" style="margin-top:10px;">
                        <img src='<%# Eval("圖示", "images/{0}") %>' 
                            class="img-fluid" style="max-width:100%"  />
                        <h4><%# Eval("品名") %></h4>
                        <p>單價：<%# Eval("單價") %></p>
                        <asp:Button ID="Button1" runat="server" 
                            Text="刪除" CssClass="btn btn-danger"
                            CommandName="刪除" 
                            CommandArgument='<%# Eval("編號") %>' 
                            OnClientClick="return confirm('確定要刪除嗎?')"
                            />
                        <a href='EditProduct.aspx?id=<%# Eval("編號") %>' class="btn btn-warning">編輯</a>
                </div>
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <div  class="row" runat="server">
                <span id="itemPlaceholder" runat="server"></span>
            </div>
        </LayoutTemplate>
    </asp:ListView>

    <div style="margin-top:30px;">
        <asp:Button ID="btnPrev" runat="server" Text="上一頁" class="btn btn-info" OnClick="btnPrev_Click" />
        <asp:Button ID="btnNext" runat="server" Text="下一頁" class="btn btn-info" OnClick="btnNext_Click" />
        <asp:Label ID="lblPage" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lblPageInfo" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
