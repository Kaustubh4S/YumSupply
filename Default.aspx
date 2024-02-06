<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yum Supply</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/YumSupplyLogoICO.ico" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link href="Content/defaultLogin.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container  mt-5 ">
            <div class="row d-flex justify-content-center">
                <div class="col-md-5 mar">
                    <div class="card px-5 py-5" id="form1">
                        <div class="form-data">
                            <div class="forms-inputs mb-4">
                                <span>UserName</span>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="w-100" TextMode="SingleLine" Required></asp:TextBox>
                                <div class="invalid-feedback">A valid UserName is required!</div>
                            </div>
                            <div class="forms-inputs mb-4">
                                <span>Password</span>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="w-100" TextMode="Password" Required></asp:TextBox>
                                <div class="invalid-feedback">Password must be 8 character!</div>
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-dark w-100" OnClick="btnLogin_Click" />
                            </div>
                            <div id="divError" visible="false" runat="server" class="alert alert-danger d-flex align-items-center" role="alert">
                                <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
                                    <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
                                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
                                    </symbol>
                                </svg>
                                <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:">
                                    <use xlink:href="#exclamation-triangle-fill" />
                                </svg>
                                <div>
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
