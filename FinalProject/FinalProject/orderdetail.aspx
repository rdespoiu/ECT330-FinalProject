<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="orderdetail.aspx.cs" Inherits="FinalProject.orderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/orderdetail.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblOrder" runat="server" Text="Placeholder test"></asp:Label></p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <asp:Table ID="tblOrderDetail" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell><b>Product Name</b></asp:TableCell>
            <asp:TableCell><b>Quantity</b></asp:TableCell>
            <asp:TableCell><b>Price</b></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
    <div id="orderDetailBottom">
        <div id="orderDetailBottomLeft">
            <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
        </div>

        <div id="orderDetailBottomRight">
            <asp:Button ID="btnBack" runat="server" Text="Back to Orders" CssClass="backButton" />
        </div>
    </div>
</asp:Content>
