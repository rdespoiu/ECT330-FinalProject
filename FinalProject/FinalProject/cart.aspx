<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="FinalProject.cart" %>

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
            <asp:TableCell><img src="/Assets/testshoe.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Sportiva TC Pro Rock Shoes</a></asp:TableCell>
            <asp:TableCell>$180.00</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="actionButton" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
    <div id="bottomLeft">
        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: $720.00"></asp:Label>
        <br />
        <asp:Label ID="lblShipping" runat="server" Text="Free Shipping!"></asp:Label>
    </div>

    <div id="bottomRight">
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="actionButton" />
    </div>
</asp:Content>
