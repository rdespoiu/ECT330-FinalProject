<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="FinalProject.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p>My Orders</p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <asp:Table ID="tblOrders" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell><b>Order Date</b></asp:TableCell>
            <asp:TableCell><b>Total Price</b></asp:TableCell>
            <asp:TableCell><b>Order Status</b></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">

</asp:Content>
