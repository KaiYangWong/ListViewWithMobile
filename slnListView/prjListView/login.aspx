<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="prjListView.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理者登入區</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top:30px;">

           <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-body bg-primary">
                            <h4 style="color:white;">管理者登入區</h4>
                        </div>
                        <div class="card-body">

                            帳號<asp:TextBox ID="txtUId" runat="server" class="form-control" required></asp:TextBox>
                            <br />
                            密碼<asp:TextBox ID="txtPwd" runat="server" class="form-control" required TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:Button ID="btnLogin" runat="server" Text="登入" class="btn btn-primary" OnClick="btnLogin_Click"    />
                           
                            <br />
                            <asp:Label ID="lblShow" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <br />

                        </div>
                     </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
