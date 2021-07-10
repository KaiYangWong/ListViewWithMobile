<%@ Page Title="產品新增" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="prjListView.CreateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-body bg-success">
                            <h4 style="color:white;">產品新增</h4>
                        </div>
                        <div class="card-body">

                            產品編號<asp:TextBox ID="txtProductId" runat="server" class="form-control"></asp:TextBox>

                            <br />
                            類別名稱<asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                            </asp:DropDownList>

                            <br />
                            品名<asp:TextBox ID="txtProductName" runat="server" class="form-control"></asp:TextBox>

                            <br />
                            單價<asp:TextBox ID="txtPrice" runat="server" class="form-control"></asp:TextBox>

                            <br />
                            圖示<asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />

                            <br />
                            <asp:Button ID="btnCreate" runat="server" Text="新增" class="btn btn-success" OnClick="btnCreate_Click"   />
                           
                            <br /><br />
                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="#FF3300"></asp:Label>

                        </div>
                     </div>
                </div>
            </div>

</asp:Content>
