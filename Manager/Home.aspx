<%@ Page Title="Home ~Manager" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Manager_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">DashBoard Manager</h6>
        <hr />
    </div>
    <style>
        .card {
            --bs-card-spacer-y: 1rem;
            --bs-card-spacer-x: 1rem;
            --bs-card-title-spacer-y: 0.5rem;
            --bs-card-border-width: 0;
            --bs-card-border-color: rgba(0, 0, 0, 0.125);
            --bs-card-border-radius: 1rem;
            --bs-card-box-shadow: 0 0 2rem 0 rgba(136, 152, 170, 0.15);
            --bs-card-inner-border-radius: 1rem;
            --bs-card-cap-padding-y: 0.5rem;
            --bs-card-cap-padding-x: 1rem;
            --bs-card-cap-bg: #fff;
            --bs-card-cap-color:;
            --bs-card-height:;
            --bs-card-color:;
            --bs-card-bg: #fff;
            --bs-card-img-overlay-padding: 1rem;
            --bs-card-group-margin: 0.75rem;
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            height: var(--bs-card-height);
            word-wrap: break-word;
            background-color: var(--bs-card-bg);
            background-clip: border-box;
            border: var(--bs-card-border-width) solid var(--bs-card-border-color);
            border-radius: var(--bs-card-border-radius);
        }

        .card-body {
            flex: 1 1 auto;
            padding: var(--bs-card-spacer-y) var(--bs-card-spacer-x);
            color: var(--bs-card-color);
        }

        .p-3 {
            padding: 1rem !important;
        }

        .text-uppercase {
            text-transform: uppercase !important;
        }

        .row {
            --bs-gutter-x: 1.5rem;
            --bs-gutter-y: 0;
            display: flex;
            flex-wrap: wrap;
            margin-top: calc(-1 * var(--bs-gutter-y));
            margin-right: calc(-.5 * var(--bs-gutter-x));
            margin-left: calc(-.5 * var(--bs-gutter-x));
        }

        .text-sm {
            line-height: 1.5;
        }

        .font-weight-bold {
            font-weight: 600 !important;
        }

        .font-weight-bolder {
            font-weight: 700 !important;
        }

        .text-success {
            color: #2dce89 !important;
        }

        .col-xl-3 {
            flex: 0 0 auto;
            width: 25%;
        }
    </style>
    <div class="d-flex justify-content-center align-items-center" style="margin-top:100px; margin-left: 150px;">
        <div class="container-fluid py-4">
            <div class="row">
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Brands.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Brands</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblBrands" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Category.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Categories</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblCategory" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Products.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Products</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblProducts" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--  <div class="col-xl-3 col-sm-6">
                <p class="mb-0">
                    <span class="text-danger text-sm font-weight-bolder">-2%</span>
                    since last quarter
                </p>
                <p class="mb-0">
                    <span class="text-success text-sm font-weight-bolder">+3%</span>
                    since last week
                </p>--%>

            <div class="row mt-4">
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Stocks.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Imported Products Quantity</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblInQty" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Stocks.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Selled Products Quantity</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblOutQty" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                    <div class="card" onclick="window.location.href='Reports.aspx';">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-8">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-uppercase font-weight-bold">Total Remaining Products Quantity</p>
                                        <h5 class="font-weight-bolder">
                                            <asp:Label ID="lblTotalStock" runat="server" />
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
