<%@ Page Title="Users" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Manager_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
    <style type="text/css">
        .switch {
            position: relative;
            display: inline-block;
            width: 50px;
            height: 24px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2196F3;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Manage Users</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-4">
        <table class="w-100">
            <tr class="m-5">
                <td>
                    <div class="form-data forms-inputs col-auto mt-2">
                        <span>User Full Name</span>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="w-75" TextMode="SingleLine"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtFullName_FilteredTextBoxExtender" runat="server" BehaviorID="txtFullName_FilteredTextBoxExtender" TargetControlID="txtFullName" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNM qwertyuioplkjhgfdsazxcvbnm" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName" Display="Dynamic" ErrorMessage="Full Name can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="form-data forms-inputs col-auto mt-2">
                        <span>UserName</span>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="w-75" TextMode="SingleLine"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtUserName_FilteredTextBoxExtender" runat="server" BehaviorID="txtUserName_FilteredTextBoxExtender" TargetControlID="txtUserName" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm0123456789" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="UserName can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Enter Password</span>
                        <asp:TextBox ID="txtPassword1" runat="server" CssClass="w-75" TextMode="Password" required></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-data forms-inputs col-auto  mt-4">
                        <span>Confirm Password</span>
                        <asp:TextBox ID="txtPassword2" runat="server" CssClass="w-75" TextMode="Password" required></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-data justify-content-center col-auto  mt-4">
                        <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="SqlDataSource2" DataTextField="RoleName" DataValueField="RoleID" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="-1">~Select Role~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Roles] ORDER BY [RoleName]"></asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div class="form-data justify-content-center col-auto  mt-4">
                        <%--<label class="switch">
                            <asp:CheckBox ID="chkOnOff" runat="server" Checked="true" />
                            <%--<span class="slider round"></span>
               
                        </label>--%>

                        <asp:CheckBox ID="chbActive" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chbActive_CheckedChanged" />
                        <asp:Label ID="lblActive" runat="server">User Active</asp:Label>

                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <center>
                    <div class="form-data">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary mt-4" OnClick="btnAdd_Click" Text="Add" />
                            <asp:Label ID="lblMsg" runat="server" ForeColor="#3399FF"></asp:Label>
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
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </div>
                    </div>
                    </div>
                        </center>
                </td>
            </tr>
        </table>
    </div>

    <div class=" card-body text-dark bg-light mb-4">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT Users.UserID, Users.FullName, Users.UserName, Users.Password, Roles.RoleName, Users.Dated, Users.Active FROM Roles INNER JOIN Users ON Roles.RoleID = Users.RoleId"></asp:SqlDataSource>
        <asp:GridView ID="grdUsers" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="UserID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdUsers_RowCommand" AllowSorting="True">
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="RoleName" />
                <asp:BoundField DataField="Dated" HeaderText="Dated" SortExpression="Dated" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:TemplateField HeaderText="Active" SortExpression="Active">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' Enabled="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField CommandName="up" HeaderText="Update" ShowHeader="True" Text="Update" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>

