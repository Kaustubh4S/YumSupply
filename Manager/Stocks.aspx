<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Stocks.aspx.cs" Inherits="Manager_Stocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Stocks</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-3">
        <table class="w-100 mt-3">
            <tr class="w-25">
                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>

                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td rowspan="3">
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
