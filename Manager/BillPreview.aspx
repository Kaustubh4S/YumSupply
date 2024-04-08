<%@ Page Title="Bill Preview" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="BillPreview.aspx.cs" Inherits="Manager_BillPreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">
        function printpanel() {
            var panel1 = document.getElementById("<%=Panel1.ClientID%>");
            var printWindow = window.open('', '', 'height=3500,width=2480');
            printWindow.document.write('<html><head><title>Bill</title>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(panel1.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
</script>
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="return printpanel();" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server">
        <style>
        body {
            background-color: #F6F6F6;
            margin: 0;
            padding: 0;
        }

        h1, h2, h3, h4, h5, h6 {
            margin: 0;
            padding: 0;
        }

        p {
            margin: 0;
            padding: 0;
        }

        .container {
            width: 80%;
            margin-right: auto;
            margin-left: auto;
        }

        .brand-section {
            background-color: #0d1033;
            padding: 10px 40px;
        }

        .logo {
            width: 50%;
        }

        .row {
            display: flex;
            flex-wrap: wrap;
        }

        .col-6 {
            width: 50%;
            flex: 0 0 auto;
        }

        .text-white {
            color: #fff;
        }

        .company-details {
            float: right;
            text-align: right;
        }

        .body-section {
            padding: 16px;
            border: 1px solid gray;
        }

        .heading {
            font-size: 20px;
            margin-bottom: 08px;
        }

        .sub-heading {
            color: #262626;
            margin-bottom: 05px;
        }

        table {
            background-color: #fff;
            width: 100%;
            border-collapse: collapse;
        }

            table thead tr {
                border: 1px solid #111;
                background-color: #f2f2f2;
            }

            table td {
                vertical-align: middle !important;
                text-align: center;
            }

            table th, table td {
                padding-top: 08px;
                padding-bottom: 08px;
            }

        .table-bordered {
            box-shadow: 0px 0px 5px 0.5px gray;
        }

            .table-bordered td, .table-bordered th {
                border: 1px solid #dee2e6;
            }

        .text-right {
            text-align: end;
        }

        .w-20 {
            width: 20%;
        }

        .float-right {
            float: right;
        }
    </style>
        <div class="container">
            <div class="brand-section">
                <div class="row">
                    <div class="col-6">
                        <h1 class="text-white">YumSupply</h1>
                    </div>
                    <div class="col-6">
                        <div class="company-details">
                            <p class="text-white">Sangameshwar College</p>
                            <p class="text-white">Solapur</p>
                            <p class="text-white">+91 93735 09181</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="body-section">
                <div class="row">
                    <div class="col-6">
                        <h2 class="heading">Invoice No.:
                            <asp:Label ID="lblInv" runat="server" Text=""></asp:Label></h2>
                        <p class="sub-heading">
                            Order Date:
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        </p>
                        <p class="sub-heading">
                            Biller:
                            <asp:Label ID="lblBiller" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <div class="col-6">
                        <p class="sub-heading">
                            Full Name:
                            <asp:Label ID="lblCustName" runat="server" Font-Bold="True"></asp:Label>
                        </p>
                        <p class="sub-heading">
                            Address:
                            <asp:Label ID="lblAdd" runat="server" Text=""></asp:Label>
                        </p>
                        <p class="sub-heading">
                            Phone Number:
                            <asp:Label ID="lblMob" runat="server" Font-Bold="True"></asp:Label>
                        </p>
                        <p class="sub-heading">
                            Taluka,City,State:
                            <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>

            <div class="body-section">
                <h3 class="heading">Ordered Items</h3>
                <br>
                <asp:Repeater ID="RepeatInformation" runat="server">
                    <HeaderTemplate>
                        <table class="table-bordered tblcolor">
                            <tr>
                                <b>
                                    <td>Product  
                                    </td>
                                    <td class="w-20">Price
                                    </td>
                                    <td class="w-20">Quantity
                                    </td>
                                    <td class="w-20">Amount
                                    </td>
                                </b>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tblrowcolor">
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.ProductName")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Price")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Quantity")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Amount")%>  
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.ProductName")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Price")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Quantity")%>  
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container,"DataItem.Amount")%>  
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <%--<SeparatorTemplate>
                                <tr>
                                    <td>
                                        <hr />
                                    </td>
                                    <td>
                                        <hr />
                                    </td>
                                    <td>
                                        <hr />
                                    </td>
                                    <td>
                                        <hr />
                                    </td>
                                </tr>
                            </SeparatorTemplate>--%>
                </asp:Repeater>
                <table class="table-bordered tblcolor">
                    <tr>
                        <td class="text-right">Net Quantity</td>
                        <td>
                            <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
                        </td>

                        </td>
                            <td class="text-right">Net Amount</td>
                        <td>
                            <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="text-right">Discount</td>
                        <td>
                            <asp:Label ID="lblDisc" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3" class="text-right">Grand Total</td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <br />
                <h3 class="heading">Payment Status: Paid</h3>
                <h3 class="heading">Payment Mode: Cash on Delivery</h3>
            </div>

            <div class="body-section">
                <p>
                    &copy; Copyright 2024 - YumSupply. All rights reserved. 
                <%--<a href="https://www.fundaofwebit.com/" class="float-right">www.fundaofwebit.com</a>--%>
                </p>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

