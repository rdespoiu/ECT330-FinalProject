﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="FinalProject.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <!--Second label will update from server with number of items in cart-->
    <asp:Label ID="lblCart" runat="server" Text="Your Cart"></asp:Label>
    <asp:Label ID="lblCartQuantity" runat="server" Text="(1 item)" CssClass="cartQuantity"></asp:Label>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <!--Table will be populated from user cart cookies. Current item is a placeholder for design //RID-->
    <asp:Table ID="tblCart" runat="server">
        <asp:TableRow>
            <asp:TableHeaderCell>Image</asp:TableHeaderCell>
            <asp:TableHeaderCell>Product Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Cost</asp:TableHeaderCell>
            <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>Remove</asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
    <div id="bottomLeft">
        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: $"></asp:Label>
        <br />
        <asp:Label ID="lblShipping" runat="server" Text="Free Shipping!"></asp:Label>
    </div>

    <div id="bottomRight">
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="actionButton" OnClick="Checkout" />
    </div>
</asp:Content>
