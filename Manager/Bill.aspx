<%@ Page Title="Generate Bill" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Bill.aspx.cs" Inherits="Manager_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Generate Bill</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-3">
        <table class="w-100 mt-3">
            <tr class="w-25">
                <td colspan="2">
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlCust" runat="server" CssClass="btn btn-secondary dropdown-toggle w-75">
                        </asp:DropDownList>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto">
                        <span>Date</span>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="w-75" ValidationGroup="ConfirmBeforeAdd" CausesValidation="True" TextMode="Date" onkeyup="disableFuturxeDates()"></asp:TextBox>
                        <script type="text/javascript">
                            function disableFutureDates() {
                                var dateTextBox = document.getElementById('<%= txtDate.ClientID %>');
        var currentDate = new Date();
        var maxDate = new Date(currentDate);  // Set your desired maximum date

        // Disable future dates
        dateTextBox.max = maxDate.toISOString().split('T')[0];

        // Set the initial value to today's date
        dateTextBox.value = currentDate.toISOString().split('T')[0];
    }
                        </script>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="form-data justify-content-center col-auto mt-4">
                        <asp:DropDownList ID="ddlBrands" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle w-75" OnSelectedIndexChanged="ddlBrands_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>

                <td>
                    <div class="form-data justify-content-center col-auto mt-4">
                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle w-75" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>

                <td>
                    <div class="form-data justify-content-center col-auto mt-4">
                        <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle w-75" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Price</span>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="w-75" TextMode="Number" ValidationGroup="ConfirmBeforeAdd"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price should not be Empty" ControlToValidate="txtPrice" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Quantity</span>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="w-75" TextMode="Number" ValidationGroup="ConfirmBeforeAdd"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtQty_FilteredTextBoxExtender" runat="server" BehaviorID="txtQty_FilteredTextBoxExtender" TargetControlID="txtQty" ValidChars="1234567890" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Quantity should not be Empty" ControlToValidate="txtQty" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Remaining Quantity</span>
                        <asp:TextBox ID="txtRemQty" runat="server" CssClass="w-75" TextMode="Number" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="form-data">
                        <center>
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary mt-4" OnClick="btnAdd_Click" Text="Add" ValidationGroup="ConfirmBeforeAdd" />
                            <asp:Label ID="lblMsg" runat="server" ForeColor="#3399FF"></asp:Label>
                            </center>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <br />
    <div class=" card-body text-dark bg-light mb-4">
        <asp:GridView ID="grdBillView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" AllowSorting="True" OnRowCommand="grdBillView_RowCommand">
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="BrandID" HeaderText="Brand ID" Visible="False" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                <asp:BoundField DataField="CateID" HeaderText="Category ID" Visible="False" />
                <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="NetAmout" HeaderText="Net Amout" />
                <asp:ButtonField CommandName="Del" Text="Remove" HeaderText="Remove" />
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

        <table class="w-100">
            <tr>
                <td>
                    <div class="form-data">
                        Toatal Quantity :
                        <asp:Label ID="lblQty" runat="server" Font-Bold="True" />
                    </div>
                </td>

                <td>
                    <div class="form-data">
                        Total Net Amount :
                        <asp:Label ID="lblAmt" runat="server" Font-Bold="True" />
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div class="form-data">
        <center>
        <asp:Button ID="btmSubmit" runat="server" CssClass="btn btn-primary mt-4" OnClick="btmSubmit_Click" Text="Submit" CausesValidation="False" />
        <asp:Label ID="lblSubmitMsg" runat="server" ForeColor="#3399FF"></asp:Label>
        </center>
    </div>
</asp:Content>

