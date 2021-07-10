<%@ Page Title="類別管理" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prjListView.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-body bg-info">
                            <h4 style="color:white;">類別管理</h4>
                        </div>
                        <div class="card-body">

                            類別名稱<asp:TextBox ID="txtCategory" runat="server" class="form-control"></asp:TextBox>
                            <br />

                            <asp:Button ID="btnCreate" runat="server" Text="新增" class="btn btn-info" OnClick="btnCreate_Click"   />
                           
                            <br /><br />

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="更新" CssClass="btn btn-primary" />
                                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" CssClass="btn" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="Button3" runat="server" CommandName="Delete" Text="刪除" CssClass="btn btn-danger" />
                                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" CssClass="btn btn-warning" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="類別編號">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Bind("類別編號") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Bind("類別編號") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="類別名稱">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("類別名稱") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("類別名稱") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="bg-info" ForeColor="White" />
                            </asp:GridView>

                        </div>
                     </div>
                </div>
            </div>

</asp:Content>
